using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

	[SerializeField]
	private string attackId;

	public string ATTACK_ID
	{
		get { return attackId; }
		set { attackId = value; }
	}


	

	[SerializeField]
	private bool fastStrike;

	public bool FAST_STRIKE
	{
		get { return fastStrike; }
		set { fastStrike = value; }
	}

	[SerializeField]
	private bool exhausting;

	public bool EXHAUSTING
	{
		get { return exhausting; }
		set { exhausting = value; }
	}

	public bool isMagic;

	[SerializeField]
	private List<AttackTarget> attackTargets;

	public List<AttackTarget> ATTACK_TARGETS
	{
		get { return attackTargets; }
		set { attackTargets = value; }
	}

	public bool frontRowOpposing;
	public bool backRowOpposing;
	public bool frontRowOwn;
	public bool backRowOwn;
	public bool self;
	public bool singleTarget;
	public bool opposingField;
	public bool ownField;
	public bool field;
	public bool reachingHit;

	public bool usableBack;
	public bool usableFront;


	private List<BattlePosition> targetPosition;

	public List<BattlePosition> TARGET_POSITION
	{
		get { return targetPosition; }
		set { targetPosition = value; }
	}

	[SerializeField]
	private Element elementType;

	public Element ELEMENT_TYPE
	{
		get { return elementType; }
		set { elementType = value; }
	}


	[SerializeField]
	private float spCost;

	public float SP_COST
	{
		get { return spCost; }
		set { spCost = value; }
	}

	[SerializeField]
	private float cpCost;

	public float CP_COST
	{
		get { return cpCost; }
		set { cpCost = value; }
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public AttackTarget executeAttackPerTarget(Combatant combatant, BattlePosition target, Attack currentAttack)
	{
		////////////////////////SAME FOR EVERY FIELD
		if (currentAttack.frontRowOpposing || currentAttack.backRowOpposing || currentAttack.self || currentAttack.frontRowOwn || currentAttack.backRowOwn)
		{
			return attackTargets[0];
		}

		////////////////////////SAME FOR EVERY FIELD

		////////////////////////TWO DIFFERENT TARGET TYPES
		if (currentAttack.reachingHit)
		{
			
			if (combatant.ALLY)
			{
				if (target.ROW_COORD == 2)
				{
					return attackTargets[0];
				}
				else
				{
					return attackTargets[1];
				}
			}
			else
			{
				if (target.ROW_COORD == 1)
				{
					return attackTargets[0];
				}
				else
				{
					return attackTargets[1];
				}
			}
		}
	
		if (currentAttack.opposingField)
		{
			if (combatant.ALLY)
			{
				if (target.ROW_COORD == 2)
				{
					return attackTargets[0];
				}
				else
				{
					return attackTargets[1];
				}
			}
			else
			{
				if (target.ROW_COORD == 1)
				{
					return attackTargets[0];
				}
				else
				{
					return attackTargets[1];
				}
			}
			
		}
	
		////////////////////////TWO DIFFERENT TARGET TYPES
		
		////////////////////////FOUR DIFFERENT TARGET TYPES
		if (currentAttack.field)
		{
			if (target.ROW_COORD == combatant.CURR_POS.ROW_COORD)
			{
				if (target.PositionID == combatant.CURR_POS.PositionID)
				{
					if (currentAttack.self)
					{
						return attackTargets[0];
					}
				}
				return attackTargets[0];
			}
			else if (target.ROW_COORD == combatant.CURR_POS.ROW_COORD + 1 || target.ROW_COORD == combatant.CURR_POS.ROW_COORD - 1)
			{
				return attackTargets[1];
			}
			else if (target.ROW_COORD == combatant.CURR_POS.ROW_COORD + 2 || target.ROW_COORD == combatant.CURR_POS.ROW_COORD - 2)
			{
				return attackTargets[2];
			}
			else if (target.ROW_COORD == combatant.CURR_POS.ROW_COORD + 3 || target.ROW_COORD == combatant.CURR_POS.ROW_COORD - 3)
			{
				return attackTargets[3];
			}
		}

		if (currentAttack.ownField)
		{			
			if (target.ROW_COORD == combatant.CURR_POS.ROW_COORD)
			{
				if (currentAttack.self)
				{
					return attackTargets[2];
				}
				return attackTargets[0];
			}
			else if (target.ROW_COORD == combatant.CURR_POS.ROW_COORD + 1 || target.ROW_COORD == combatant.CURR_POS.ROW_COORD - 1)
			{
				return attackTargets[1];
			}		
		}

		////////////////////////FOUR DIFFERENT TARGET TYPES
		Debug.Log("YOU SHOULD NOT SEE THIS!");
		return attackTargets[0];
	}

	/////////////////////AREAFIELD/////////////////////////////////////////////////////

	public void callAttackEffects(Combatant user, BattlePosition target)
	{
		switch (user.CURRENT_ATTACK.ATTACK_ID)
		{
			case "Rest": restEffect(user);break;
			case "Guard Song": guardSongEffect(target);break;
			case "War Song": guardSongEffect(target);break;
			case "Swarm": swarmEffect(target);break;
			default:
				break;
		}
	}

	private void swarmEffect(BattlePosition target)
	{
		target.FIGURE.SWARMED = true;
		changeStat(target, "ACCU", -9);
		changeStat(target, "E_DEF", -6);
		changeStat(target, "E_ATK", -6);
		changeStat(target, "C_ATK", -6);
		changeStat(target, "C_DEF", -6);

		Debug.Log("!!!!!!!!!!!!!!!" + target.FIGURE.NAME + " [at " + target.FIGURE.CURR_POS.PositionID + "] was !!!SWARMED!!!!!!!!!!!!!!!!!!!");
	}

	private void restEffect(Combatant user)
	{
		user.CP = user.CP_MAX / 2;

		Debug.Log(user.NAME + "has gathered new Confidence");
	}

	private void guardSongEffect(BattlePosition target)
	{
		if (target.CURRENTLY_OCCUPIED)
		{
			changeStat(target, "SPD", 3);
			changeStat(target, "DEF", 6);
			changeStat(target, "M_DEF", 3);
			changeStat(target, "E_DEF", 9);
			changeStat(target, "C_DEF", 12);
			float upperLimit = 11f / 18f * target.FIGURE.CP_MAX;
			float lowerLimit = 7f / 18f * target.FIGURE.CP_MAX;
			float cure = Random.Range(lowerLimit, upperLimit);
			target.FIGURE.CP = cure;
			Debug.Log(target.FIGURE.NAME + " [at " + target.FIGURE.CURR_POS.PositionID + "] was inspired by the Guard Song");
		}
	}

	private void warSongEffect(BattlePosition target)
	{
		if (target.CURRENTLY_OCCUPIED)
		{
			changeStat(target, "ACCU", 9);
			changeStat(target, "ATK", 6);
			changeStat(target, "M_ATK", 3);
			changeStat(target, "E_ATK", 9);
			changeStat(target, "C_ATK", 12);
			float upperLimit = 14f / 18f * target.FIGURE.CP_MAX;
			float lowerLimit = 10f / 18f * target.FIGURE.CP_MAX;
			float cure = Random.Range(lowerLimit, upperLimit);
			target.FIGURE.CP = cure;
			Debug.Log(target.FIGURE.NAME + " [at " + target.FIGURE.CURR_POS.PositionID + "] was inspired by the War Song");
		}
	}

	/////////////////////TEMPERING_FUNCTIONS/////////////////////////////////////////////////////

	private void changeStat(BattlePosition target, string stat, float change)
	{
		if (target.CURRENTLY_OCCUPIED)
		{
			switch (stat)
			{
				case "SPD":
					if (target.FIGURE.SPD != target.FIGURE.SPD_MAX)
					{
						target.FIGURE.SPD += change;
					}
					if (target.FIGURE.SPD > target.FIGURE.SPD_MAX)
					{
						target.FIGURE.SPD = target.FIGURE.SPD_MAX;
					}
					if (target.FIGURE.SPD < target.FIGURE.SPD_MIN)
					{
						target.FIGURE.SPD = target.FIGURE.SPD_MIN;
					}
					; break;
				case "ATK":
					if (target.FIGURE.P_ATK != target.FIGURE.P_ATK_MAX)
					{
						target.FIGURE.P_ATK += change;
					}
					if (target.FIGURE.P_ATK > target.FIGURE.P_ATK_MAX)
					{
						target.FIGURE.P_ATK = target.FIGURE.P_ATK_MAX;
					}
					if (target.FIGURE.P_ATK < target.FIGURE.P_ATK_MIN)
					{
						target.FIGURE.P_ATK = target.FIGURE.P_ATK_MIN;
					}
					; break;
				case "DEF":
					if (target.FIGURE.P_DEF != target.FIGURE.P_DEF_MAX)
					{
						target.FIGURE.P_DEF += change;
					}
					if (target.FIGURE.P_DEF > target.FIGURE.P_DEF_MAX)
					{
						target.FIGURE.P_DEF = target.FIGURE.P_DEF_MAX;
					}
					if (target.FIGURE.P_DEF < target.FIGURE.P_DEF_MIN)
					{
						target.FIGURE.P_DEF = target.FIGURE.P_DEF_MIN;
					}
					; break;
				case "C_ATK":
					if (target.FIGURE.C_ATK != target.FIGURE.C_ATK_MAX)
					{
						target.FIGURE.C_ATK += change;
					}
					if (target.FIGURE.C_ATK > target.FIGURE.C_ATK_MAX)
					{
						target.FIGURE.C_ATK = target.FIGURE.C_ATK_MAX;
					}
					if (target.FIGURE.C_ATK < target.FIGURE.C_ATK_MIN)
					{
						target.FIGURE.C_ATK = target.FIGURE.C_ATK_MIN;
					}
					; break;
				case "C_DEF":
					if (target.FIGURE.C_DEF != target.FIGURE.C_DEF_MAX)
					{
						target.FIGURE.C_DEF += change;
					}
					if (target.FIGURE.C_DEF > target.FIGURE.C_DEF_MAX)
					{
						target.FIGURE.C_DEF = target.FIGURE.C_DEF_MAX;
					}
					if (target.FIGURE.C_DEF < target.FIGURE.C_DEF_MIN)
					{
						target.FIGURE.C_DEF = target.FIGURE.C_DEF_MIN;
					}
					; break;
				case "ACCU":
					if (target.FIGURE.ACCU != target.FIGURE.ACCU_MAX)
					{
						target.FIGURE.ACCU += change;
					}
					if (target.FIGURE.ACCU > target.FIGURE.ACCU_MAX)
					{
						target.FIGURE.ACCU = target.FIGURE.ACCU_MAX;
					}
					if (target.FIGURE.ACCU < target.FIGURE.ACCU_MIN)
					{
						target.FIGURE.ACCU = target.FIGURE.ACCU_MIN;
					}
					; break;
				case "ACCU_VAL":
					if (target.FIGURE.ACCU_VAL != target.FIGURE.ACCU_MAX_VAL)
					{
						target.FIGURE.ACCU_VAL += change;
					}
					if (target.FIGURE.ACCU_VAL > target.FIGURE.ACCU_MAX_VAL)
					{
						target.FIGURE.ACCU_VAL = target.FIGURE.ACCU_MAX_VAL;
					}
					if (target.FIGURE.ACCU_VAL < target.FIGURE.ACCU_MIN_VAL)
					{
						target.FIGURE.ACCU_VAL = target.FIGURE.ACCU_MIN_VAL;
					}
					; break;
				default:
					break;
			}
		}

	}
}