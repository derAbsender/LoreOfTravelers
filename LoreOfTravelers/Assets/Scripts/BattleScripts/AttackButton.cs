using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class AttackButton : MonoBehaviour
{

	private Attack currentAttack;
	[SerializeField]
	private List<BattlePosition> attackArea;

	[SerializeField]
	private GameObject AttackOptionIndicator;

	public GameObject ATTACK_OPTION_INDICATOR
	{
		get { return AttackOptionIndicator; }
		set { AttackOptionIndicator = value; }
	}



	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void chosenAttackButtonPress()
	{
		if (BattleMaster.instance.BACK_BUTTON.activeInHierarchy)
		{
			BattleMaster.instance.BACK_BUTTON.SetActive(false);
		}		

		attackArea.Clear();
		foreach (var position in BattleMaster.instance.INDIPOS)
		{
			if (position.GetComponentInChildren<Button>())
			{
				Destroy(position.GetComponentInChildren<Button>().gameObject);
			}
		}
		string attackId = GetComponentInChildren<Text>().text;

		foreach (var attack in BattleMaster.instance.ALL_ATTACKS)
		{
			if (attack.ATTACK_ID == attackId)
			{
				AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_ATTACK = attack;
			}
		}


		AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_COMBATANT = BattleMaster.instance.CURRENT_COMBATANT;
		Attack currentAttack = AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_ATTACK;
		AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		Debug.Log(currentAttack.ATTACK_ID);

	
		if (currentAttack.isMagic)
		{					
			if (!BattleMaster.instance.MAGIC_ADJUSTER.activeInHierarchy)
			{
				BattleMaster.instance.MAGIC_ADJUSTER.SetActive(true);
			}
			BattleMaster.instance.MAGIC_ADJUSTER_SLIDER.maxValue = BattleMaster.instance.CURRENT_COMBATANT.MP;
			BattleMaster.instance.MAGIC_ADJUSTER_SLIDER.value = BattleMaster.instance.CURRENT_COMBATANT.MP/3;
		}

		AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_ATTACK = currentAttack;

		BattleMaster.instance.FIGURES[BattleMaster.instance.ALL_BATTLE_IDs[BattleMaster.instance.TURN_COUNTER_TOKEN]].CURRENT_ATTACK = currentAttack;
		if (currentAttack.FAST_STRIKE)
		{
			BattleMaster.instance.FIGURES[BattleMaster.instance.ALL_BATTLE_IDs[BattleMaster.instance.TURN_COUNTER_TOKEN]].IS_PREPARING = false;
		}
		else
		{
			BattleMaster.instance.FIGURES[BattleMaster.instance.ALL_BATTLE_IDs[BattleMaster.instance.TURN_COUNTER_TOKEN]].IS_PREPARING = true;
		}
		

		if (currentAttack.frontRowOpposing && currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.ROW_COORD == 2)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
					Instantiate(AttackOptionIndicator, position.transform);

					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
				}
			}
		}
		if (currentAttack.backRowOpposing && currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.ROW_COORD == 3)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
					Instantiate(AttackOptionIndicator, position.transform);

					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
				}
			}
		}
		if (currentAttack.frontRowOwn && currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				if (position.ROW_COORD == 1)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
					Instantiate(AttackOptionIndicator, position.transform);

					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
				}
			}
		}
		if (currentAttack.backRowOwn && currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				if (position.ROW_COORD == 0)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
					Instantiate(AttackOptionIndicator, position.transform);

					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
				}
			}
		}

		if (currentAttack.frontRowOpposing && !currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.ROW_COORD == 2)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
				}
			}
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.ROW_COORD == 2)
				{
					Instantiate(AttackOptionIndicator, position.transform);
				}
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}
		if (currentAttack.backRowOpposing && !currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.ROW_COORD == 3)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
				}
			}
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.ROW_COORD == 3)
				{
					Instantiate(AttackOptionIndicator, position.transform);
				}
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}
		if (currentAttack.frontRowOwn && !currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				if (position.ROW_COORD == 1)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
				}
			}
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				if (position.ROW_COORD == 1)
				{
					Instantiate(AttackOptionIndicator, position.transform);
				}
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}
		if (currentAttack.backRowOwn && !currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				if (position.ROW_COORD == 0)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);					
				}				
			}
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				if (position.ROW_COORD == 0)
				{
					Instantiate(AttackOptionIndicator, position.transform);
				}
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}



		if (currentAttack.opposingField && !currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
			}
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{				
				Instantiate(AttackOptionIndicator, position.transform);				
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}

		if (currentAttack.ownField && !currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
			}
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				Instantiate(AttackOptionIndicator, position.transform);
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}


		if (currentAttack.ownField && currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
				Instantiate(AttackOptionIndicator, position.transform);
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}

		if (currentAttack.opposingField && currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
				Instantiate(AttackOptionIndicator, position.transform);
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}

		if (currentAttack.reachingHit)
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.ROW_COORD == 2)
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
					foreach (var reach in BattleMaster.instance.ENEMY_SIDE)
					{
						if (reach.ROW_COORD == 3 && reach.COL_COORD == position.COL_COORD)
						{
							AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(reach);
						}
					}
					Instantiate(AttackOptionIndicator, position.transform);
				}
				AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
			}
		}

		if (currentAttack.self)
		{
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_COMBATANT.CURR_POS);
			Instantiate(AttackOptionIndicator, AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_COMBATANT.CURR_POS.transform);
		}

		if (currentAttack.field && !currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.INDIPOS)
			{
				if (position.PositionID == AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_COMBATANT.CURR_POS.PositionID)
				{
					if (currentAttack.self)
					{
						AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
					}
				}
				else
				{
					AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
				}				
			}
			foreach (var position in BattleMaster.instance.INDIPOS)
			{
				if (position.PositionID == AttackOptionIndicator.GetComponent<AttackIndicator>().CURRENT_COMBATANT.CURR_POS.PositionID)
				{
					if (currentAttack.self)
					{
						Instantiate(AttackOptionIndicator, position.transform);
					}
				}
				else
				{
					Instantiate(AttackOptionIndicator, position.transform);
				}			
			}
			AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
		}

		if (currentAttack.field && currentAttack.singleTarget)
		{
			foreach (var position in BattleMaster.instance.INDIPOS)
			{
				AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Add(position);
				Instantiate(AttackOptionIndicator, position.transform);
				AttackOptionIndicator.GetComponent<AttackIndicator>().ATTACK_FIELD.Clear();
			}			
		}
		attackArea.Clear();
	}

}
