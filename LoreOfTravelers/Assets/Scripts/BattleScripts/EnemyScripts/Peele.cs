using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peele : Combatant
{
	Combatant peele;

	[SerializeField]
	private List<string> preyItems;

	public List<string> PREY_ITEMS
	{
		get { return preyItems; }
		set { preyItems = value; }
	}





	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public string[] makeDecision(Combatant peele)
	{
		string[] what_where = new string[2];
		bool acted = false;
		bool stay;
		//	bool rumble = false;
		int peeleCount = 0;

		what_where[0] = "skip";
		what_where[1] = "RC_";

		foreach (var figure in BattleMaster.instance.ALL_BATTLE_IDs)
		{
			if (BattleMaster.instance.FIGURES[figure].NAME == "Peele")
			{
				peeleCount++;
			}
		}

		Debug.Log("PEELE COUNT " + peeleCount);
		
		if (peeleCount > 2)
		{
			stay = true;
		}
		else
		{
			stay = false;
		}


		if (stay)
		{
			if (peele.SP < 10)
			{
				what_where[0] = "attack";
				peele.CURR_POS.TEMP_SING_AREA_FIELD.Clear();
				peele.CURR_POS.TEMP_SING_AREA_FIELD.Add(peele.CURR_POS);
				//Debug.Log("WANT TO HEAL");
				BattleMaster.instance.attackExecutionTurn(peele.CURR_POS.TEMP_SING_AREA_FIELD, peele.KNOWN_ATTACKS[1]);
				peele.CURR_POS.TEMP_SING_AREA_FIELD.Clear();
			}

			if (peele.CURR_POS.ROW_COORD == 2)
			{
				foreach (var position in BattleMaster.instance.PLAYER_SIDE)
				{
					if (position.ROW_COORD == 1)
					{
						peele.ACTION_FIELD.Add(position);
					}
				}
				int index = Random.Range(0, peele.ACTION_FIELD.Count);
				what_where[0] = "attack";
				peele.RUMBLE_FIELD.Clear();
				peele.RUMBLE_FIELD.Add(peele.ACTION_FIELD[index]);

				BattleMaster.instance.attackExecutionTurn(peele.RUMBLE_FIELD, peele.KNOWN_ATTACKS[0]);
			}
			if (peele.CURR_POS.ROW_COORD == 3)
			{
				foreach (var position in BattleMaster.instance.ENEMY_SIDE)
				{
					if (position.ROW_COORD == 2 && !position.CURRENTLY_OCCUPIED)
					{
						peele.ACTION_FIELD.Add(position);
					}
				}
				if (peele.ACTION_FIELD.Count > 0)
				{
					int index = Random.Range(0, peele.ACTION_FIELD.Count);
					what_where[0] = "move";
					what_where[1] = peele.ACTION_FIELD[index].PositionID;
				}
				else
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						peele.ACTION_FIELD.Add(position);
					}
					what_where[0] = "attack";

					BattleMaster.instance.attackExecutionTurn(peele.ACTION_FIELD, peele.KNOWN_ATTACKS[2]);
				}
			}
			peele.ACTION_FIELD.Clear();
			peele.RUMBLE_FIELD.Clear();
		}
		else
		{
			if (peele.CURR_POS.ROW_COORD == 3)
			{
				peele.deleteCombatant(peele);
			}
			else
			{
				foreach (var position in BattleMaster.instance.ENEMY_SIDE)
				{
					if (position.ROW_COORD == 3)
					{
						peele.ACTION_FIELD.Add(position);
					}
				}
				int index = Random.Range(0, peele.ACTION_FIELD.Count);
				what_where[0] = "move";
				what_where[1] = peele.ACTION_FIELD[index].PositionID;
			}
		}
		

		return what_where;
	}
}
