using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackIndicator : MonoBehaviour
{
	[SerializeField]
	private Combatant currentCombatant;

	public Combatant CURRENT_COMBATANT
	{
		get { return currentCombatant; }
		set { currentCombatant = value; }
	}

	[SerializeField]
	private Attack currentAttack;

	public Attack CURRENT_ATTACK
	{
		get { return currentAttack; }
		set { currentAttack = value; }
	}

	[SerializeField]
	private List<BattlePosition> attackField;

	public List<BattlePosition> ATTACK_FIELD
	{
		get { return attackField; }
		set { attackField = value; }
	}
	[SerializeField]
	private float magicStrength;

	public float MAGIC_STRENGTH
	{
		get { return magicStrength; }
		set { magicStrength = value; }
	}


	// Start is called before the first frame update
	void Start()
    {
		       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void pressAttackIndicator()
	{
		Debug.Log(attackField.Count);

		BattleMaster.instance.attackExecutionTurn(attackField, currentAttack);
		
		BattleMaster.instance.endTurn();
		
	}

}
