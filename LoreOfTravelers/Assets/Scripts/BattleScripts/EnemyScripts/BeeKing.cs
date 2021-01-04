using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeKing : Combatant
{
	Combatant beeKing;

	public string[] makeDecision(Combatant beeKing)
	{
		bool acted = false;
		string[] what_where = { "skip", "RC_" };

		if (beeKing.SP < 17)
		{
			BattleMaster.instance.attackExecutionTurn(RUMBLE_FIELD, beeKing.KNOWN_ATTACKS[2]);
			what_where[1] = "attack";
			acted = true;
		}

		if (!acted)
		{
			if (beeKing.CURR_POS.ROW_COORD == 2)
			{
				what_where[0] = "move";
				what_where[1] = "RC_3,CC_"+beeKing.CURR_POS.COL_COORD;
				acted = true;
			}
			else
			{
				what_where[0] = "attack";
				bool allSwarmed = true;
				foreach (var target in BattleMaster.instance.INDIFIG)
				{
					if (target.ALLY)
					{
						beeKing.ACTION_FIELD.Add(target.CURR_POS);
						if (!target.SWARMED)
						{
							allSwarmed = false;
						}
					}
				}
				int index = Random.Range(0, beeKing.ACTION_FIELD.Count);
				beeKing.RUMBLE_FIELD.Add(beeKing.ACTION_FIELD[index]);
				if (allSwarmed)
				{
					BattleMaster.instance.attackExecutionTurn(beeKing.RUMBLE_FIELD, beeKing.KNOWN_ATTACKS[1]);
				}
				else
				{
					if (Random.Range(0, 10) % 2 == 0)
					{
						BattleMaster.instance.attackExecutionTurn(beeKing.RUMBLE_FIELD, beeKing.KNOWN_ATTACKS[0]);
					}
					else
					{
						BattleMaster.instance.attackExecutionTurn(beeKing.RUMBLE_FIELD, beeKing.KNOWN_ATTACKS[1]);
					}
				}				
			}
		}

		beeKing.RUMBLE_FIELD.Clear();
		beeKing.ACTION_FIELD.Clear();
		return what_where;
	}
}
