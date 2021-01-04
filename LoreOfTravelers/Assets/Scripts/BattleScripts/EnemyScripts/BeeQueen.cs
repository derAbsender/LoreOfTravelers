using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeQueen : MonoBehaviour
{
	public string[] makeDecision(Combatant beeQueen)
	{
		bool acted = false;
		string[] what_where = { "skip", "RC_" };

		beeQueen.ACTION_FIELD.Clear();
		beeQueen.RUMBLE_FIELD.Clear();

		if (beeQueen.SP < beeQueen.SP_MAX * 1/3 || beeQueen.CP < 5)
		{
			Debug.Log("WANT TO HEAL");
			what_where[0] = "attack";
			beeQueen.CURR_POS.TEMP_SING_AREA_FIELD.Clear();
			beeQueen.CURR_POS.TEMP_SING_AREA_FIELD.Add(beeQueen.CURR_POS);
			//
			BattleMaster.instance.attackExecutionTurn(beeQueen.CURR_POS.TEMP_SING_AREA_FIELD, beeQueen.KNOWN_ATTACKS[5]); //REST
			beeQueen.CURR_POS.TEMP_SING_AREA_FIELD.Clear();
			acted = true;
		}

		if (!acted && beeQueen.HP > beeQueen.HP_MAX * 1 / 2)
		{
			int frontCounter = 0;
			/*
			if noone is frontPlayer = shoot
			if front > 1 = wide swing
			if two in col = reaching hit
			else brawl
			*/
			if (beeQueen.CURR_POS.ROW_COORD == 3)
			{
				foreach (var position in BattleMaster.instance.ENEMY_SIDE)
				{
					if (position.ROW_COORD==2)
					{
						beeQueen.ACTION_FIELD.Add(position);
					}
				}
				int index = Random.Range(0, beeQueen.ACTION_FIELD.Count);
				what_where[0] = "move";
				what_where[1] = beeQueen.ACTION_FIELD[index].PositionID;
				acted = true;
			}

			if (!acted)
			{
				foreach (var position in BattleMaster.instance.PLAYER_SIDE)
				{
					if (position.ROW_COORD == 1 && position.CURRENTLY_OCCUPIED)
					{
						frontCounter++;
					}
				}
				if (frontCounter == 0)
				{
					what_where[0] = "attack";
					bool allSwarmed = true;
					foreach (var target in BattleMaster.instance.ALL_BATTLE_IDs)
					{
						if (BattleMaster.instance.FIGURES[target].ALLY)
						{
							beeQueen.ACTION_FIELD.Add(BattleMaster.instance.FIGURES[target].CURR_POS);
							if (!BattleMaster.instance.FIGURES[target].SWARMED)
							{
								allSwarmed = false;
							}
						}
					}
					int index = Random.Range(0, beeQueen.ACTION_FIELD.Count);
					beeQueen.RUMBLE_FIELD.Add(beeQueen.ACTION_FIELD[index]);
					if (allSwarmed)
					{
						Debug.Log("SWARMED SHOOTING");
						BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[1]);
					}
					else
					{
						if (Random.Range(0, 10) % 2 == 0)
						{
							BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[0]);
						}
						else
						{
							Debug.Log("SHOOTING");
							BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[1]);
						}
					}
					acted = true;
				}
				if (!acted && frontCounter > 1 && beeQueen.CURR_POS.ROW_COORD == 2)
				{
					//Wide swing
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 1)
						{
							beeQueen.ACTION_FIELD.Add(position);
						}
					}
					//int index = Random.Range(0, beeQueen.ACTION_FIELD.Count);
					//beeQueen.RUMBLE_FIELD.Add(beeQueen.ACTION_FIELD[index]);
					BattleMaster.instance.attackExecutionTurn(beeQueen.ACTION_FIELD, beeQueen.KNOWN_ATTACKS[2]); //WIDE SWING
					Debug.Log("THEY LINED UP IN FRONT");
					acted = true;
				}
				if (!acted && beeQueen.CURR_POS.ROW_COORD == 2)
				{
					beeQueen.ACTION_FIELD.Clear();
					beeQueen.RUMBLE_FIELD.Clear();
					bool ready = false;

					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 1 && position.CURRENTLY_OCCUPIED)
						{							
							beeQueen.RUMBLE_FIELD.Add(position);
						}
					}
					foreach (var target in beeQueen.RUMBLE_FIELD)
					{
						foreach (var possibleTarget in BattleMaster.instance.PLAYER_SIDE)
						{
							Debug.Log(possibleTarget.PositionID);
							Debug.Log(target.ROW_COORD - 1 == possibleTarget.ROW_COORD);
							Debug.Log(target.COL_COORD == possibleTarget.COL_COORD);
							Debug.Log(possibleTarget.CURRENTLY_OCCUPIED);

							if (target.ROW_COORD - 1 == possibleTarget.ROW_COORD && target.COL_COORD == possibleTarget.COL_COORD && possibleTarget.CURRENTLY_OCCUPIED)
							{
								beeQueen.ACTION_FIELD.Add(target);
								beeQueen.ACTION_FIELD.Add(possibleTarget);
								ready = true;
								break;
							}
						}
						if (ready)
						{
							break;
						}
					}
					if (ready)
					{
						BattleMaster.instance.attackExecutionTurn(beeQueen.ACTION_FIELD, beeQueen.KNOWN_ATTACKS[3]); //REACHING HIT
						Debug.Log("THEY TRY TO PROTECT EACH OTHER!");
						acted = true;
					}					
				}
				if (!acted && beeQueen.CURR_POS.ROW_COORD == 2)
				{
					Debug.Log("THIS ONE DOESNT RESPECT MY AUTHORITY!");
					beeQueen.ACTION_FIELD.Clear();
					beeQueen.RUMBLE_FIELD.Clear();
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 1 && position.CURRENTLY_OCCUPIED)
						{
							beeQueen.ACTION_FIELD.Add(position);
						}
					}
					int index = Random.Range(0, beeQueen.ACTION_FIELD.Count);
					beeQueen.RUMBLE_FIELD.Add(beeQueen.ACTION_FIELD[index]);
					BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[4]); //BRAWL
					Debug.Log(beeQueen.RUMBLE_FIELD[0].PositionID);
					acted = true;
				}
				if (!acted)
				{
					Debug.Log("I SHOOT OF DESPERATION!");
					foreach (var target in BattleMaster.instance.ALL_BATTLE_IDs)
					{
						if (BattleMaster.instance.FIGURES[target].ALLY)
						{
							beeQueen.ACTION_FIELD.Add(BattleMaster.instance.FIGURES[target].CURR_POS);
						}
					}
					int index = Random.Range(0, beeQueen.ACTION_FIELD.Count);
					beeQueen.RUMBLE_FIELD.Add(beeQueen.ACTION_FIELD[index]);

					BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[1]);
					
				}

				beeQueen.ACTION_FIELD.Clear();
				beeQueen.RUMBLE_FIELD.Clear();
			}
		} 
		else if (!acted)
		{
			if (beeQueen.CURR_POS.ROW_COORD == 2)
			{
				foreach (var position in BattleMaster.instance.ENEMY_SIDE)
				{
					if (position.ROW_COORD == 3)
					{
						beeQueen.ACTION_FIELD.Add(position);
					}
				}
				int index = Random.Range(0, beeQueen.ACTION_FIELD.Count);
				what_where[0] = "move";
				what_where[1] = beeQueen.ACTION_FIELD[index].PositionID;
				acted = true;
			}
			else
			{
				if (Random.Range(0,100)%3 != 0)
				{
					Debug.Log("REST");
					what_where[0] = "attack";
					beeQueen.CURR_POS.TEMP_SING_AREA_FIELD.Clear();
					beeQueen.CURR_POS.TEMP_SING_AREA_FIELD.Add(beeQueen.CURR_POS);
					//Debug.Log("WANT TO HEAL");
					BattleMaster.instance.attackExecutionTurn(beeQueen.CURR_POS.TEMP_SING_AREA_FIELD, beeQueen.KNOWN_ATTACKS[5]); //REST
					beeQueen.CURR_POS.TEMP_SING_AREA_FIELD.Clear();
					acted = true;
				}
				else
				{
					Debug.Log("vaguely SHOOTING");
					what_where[0] = "attack";
					bool allSwarmed = true;
					foreach (var target in BattleMaster.instance.ALL_BATTLE_IDs)
					{
						if (BattleMaster.instance.FIGURES[target].ALLY)
						{
							beeQueen.ACTION_FIELD.Add(BattleMaster.instance.FIGURES[target].CURR_POS);
							if (!BattleMaster.instance.FIGURES[target].SWARMED)
							{
								allSwarmed = false;
							}
						}
					}
					int index = Random.Range(0, beeQueen.ACTION_FIELD.Count);
					beeQueen.RUMBLE_FIELD.Add(beeQueen.ACTION_FIELD[index]);
					if (allSwarmed)
					{
						Debug.Log("SHOT");
						BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[1]);
					}
					else
					{
						if (Random.Range(0, 10) % 2 == 0)
						{
							Debug.Log("SWARM");
							BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[0]);
						}
						else
						{
							Debug.Log("SHOT");
							BattleMaster.instance.attackExecutionTurn(beeQueen.RUMBLE_FIELD, beeQueen.KNOWN_ATTACKS[1]);
						}
					}
				}
			}
		}
		return what_where;
	}	
}
