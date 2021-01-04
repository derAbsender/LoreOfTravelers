//using System.Collections;
//using System.Linq;
//using System.Collections.Generic;
//using UnityEngine;

//public class Mokianer : Combatant
//{
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//	public string[] makeDecision(Combatant mokianer)
//	{
//		string[] what_where = new string[2];
//		what_where[0] = "attack";
//		what_where[1] = "RC_";
//		bool acted = false;
//		List<BattlePosition> singlePosition = new List<BattlePosition>();

//		//if (Random.Range(0, 100) % 7 == 0)
//		//{
//		//	what_where[0] = "skip";
//		//	what_where[1] = "RC_";//+wiggyat.CURR_POS.ROW_COORD+",CC_"+wiggyat.CURR_POS.COL_COORD;
//		//	acted = true;
//		//	Debug.Log("In it's panick, the Wiggyat forgot what that it panicked. Leaving it uneasy.");
//		//	//BattleMaster.instance.TURN_COUNTER_TOKEN++;
//		//}

//		foreach (var area in mokianer.CURR_POS.AREA_TILES)
//		{
//			foreach (var tile in area)
//			{
//				if (tile.CURRENTLY_OCCUPIED && tile.FIGURE.NAME == "Mokianer")
//				{
//					break;
//				}
//				else if(tile.CURRENTLY_OCCUPIED && tile.FIGURE.ALLY)
//				{
//					Debug.Log(mokianer.KNOWN_ATTACKS[0].ATTACK_SP_COST);
//					BattleMaster.instance.attackExecutionTurn(area, mokianer.KNOWN_ATTACKS[0]);
//					acted = true;
//					break;
//				}
//			}
//			if (acted)
//			{
//				break;
//			}
//		}
//		if (!acted)
//		{
//			foreach (var position in mokianer.CURR_POS.BORDERING_TILES)
//			{
//				if (position.CURRENTLY_OCCUPIED && position.FIGURE.ALLY)
//				{
//					//Attack Hit 
//					singlePosition.Add(position);
//					BattleMaster.instance.attackExecutionTurn(singlePosition, mokianer.KNOWN_ATTACKS[1]);
//					acted = true;
//					singlePosition.Clear();
//				}
//			}
//		}
//		else if (!acted)
//		{
//			foreach (var position in mokianer.CURR_POS.FURTHER_BORDERING_TILES)
//			{
//				if (position.CURRENTLY_OCCUPIED && position.FIGURE.ALLY)
//				{
//					//Attack Sting
//					singlePosition.Add(position);
//					BattleMaster.instance.attackExecutionTurn(singlePosition, mokianer.KNOWN_ATTACKS[2]);
//					acted = true;
//					singlePosition.Clear();
//				}
//			}
//		}

		

//		if (!acted && mokianer.SP >= 2)
//		{
			
//			//action = Action.move;
//			what_where[0] = "move";
//			what_where[1] = movingDecision(mokianer);

//			//BattleMaster.instance.TURN_COUNTER_TOKEN++;
//		}
//		if(!acted && what_where[1] == "RC_")
//		{
//			Debug.Log("Is too exhausted to run");
//			what_where[0] = "skip";
//			what_where[1] = "RC_";//+wiggyat.CURR_POS.ROW_COORD+",CC_"+wiggyat.CURR_POS.COL_COORD;
//			acted = true;
//		}

//		return what_where;
//	}

//	public string movingDecision(Combatant w)
//	{
//		string keyToNextPosition = "RC_";
//		int counter = 0;
//		bool match = false;
//		Debug.Log(w.NAME);
//		do
//		{
//			foreach (var position in w.CURR_POS.BORDERING_TILES)
//			{
//				if (Random.Range(0, 100) % 6 == 0 && !position.CURRENTLY_OCCUPIED)
//				{
//					if (position.POS_TYPE != PositionType.flight)
//					{
//						keyToNextPosition += "" + position.ROW_COORD;
//						keyToNextPosition += ",CC_" + position.COL_COORD;
						
//						match = true;
//						Debug.Log("The " + w.NAME + " ran to " + keyToNextPosition);
//						break;
//					}
//				}
//				counter++;
//			}
//		} while (!match);

//		return keyToNextPosition;
//	}

//}
