using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Wiggyat : EnemyBase
{
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public string[] makeDecision(Combatant wiggyat)
	{
		string[] what_where = new string[2];

		List<BattlePosition> singlePosition = new List<BattlePosition>();
		bool acted = false;

		if (Random.Range(0, 100) % 7 == 0)
		{
			what_where[0] = "skip";
			what_where[1] = "RC_";//+wiggyat.CURR_POS.ROW_COORD+",CC_"+wiggyat.CURR_POS.COL_COORD;
			acted = true;
			Debug.Log("In it's panick, the Wiggyat forgot what that it panicked. Leaving it uneasy.");
		}

		if (!acted)
		{
			if (Random.Range(0, 100) % 5 == 0 && wiggyat.CURR_POS.ROW_COORD == 2)
			{
				foreach (var position in BattleMaster.instance.PLAYER_SIDE)
				{
					if (position.ROW_COORD == 1)
					{
						wiggyat.ACTION_FIELD.Add(position);
					}
				}
				int index = Random.Range(0, wiggyat.ACTION_FIELD.Count);
				what_where[0] = "attack";
				wiggyat.RUMBLE_FIELD.Clear();
				wiggyat.RUMBLE_FIELD.Add(wiggyat.ACTION_FIELD[index]);

				BattleMaster.instance.attackExecutionTurn(wiggyat.RUMBLE_FIELD, wiggyat.KNOWN_ATTACKS[0]);
			}
			else
			{
				if (Random.Range(0, 100) % 5 == 0)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == 3 && position.PositionID != wiggyat.CURR_POS.PositionID)
						{
							wiggyat.ACTION_FIELD.Add(position);
						}
					}
					int index = Random.Range(0, wiggyat.ACTION_FIELD.Count);
					what_where[0] = "move";
					what_where[1] = wiggyat.ACTION_FIELD[index].PositionID;
				}
				else
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == 2 && position.PositionID != wiggyat.CURR_POS.PositionID)
						{
							wiggyat.ACTION_FIELD.Add(position);
						}
					}
					int index = Random.Range(0, wiggyat.ACTION_FIELD.Count);
					what_where[0] = "move";
					what_where[1] = wiggyat.ACTION_FIELD[index].PositionID;
				}
			}			
		}
		wiggyat.ACTION_FIELD.Clear();
		wiggyat.RUMBLE_FIELD.Clear();

		return what_where;
	}
}
