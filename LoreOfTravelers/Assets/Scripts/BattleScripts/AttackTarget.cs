using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackTarget
{

	[SerializeField]
	private BattlePosition target;

	public BattlePosition TARGET
	{
		get { return target; }
		set { target = value; }
	}

	[SerializeField]
	private float hpDamage;

	public float HP_DAMAGE
	{
		get { return hpDamage; }
		set { hpDamage = value; }
	}

	[SerializeField]
	private float spDamage;

	public float SP_DAMAGE
	{
		get { return spDamage; }
		set { spDamage = value; }
	}

	[SerializeField]
	private float cpDamage;

	public float CP_DAMAGE
	{
		get { return cpDamage; }
		set { cpDamage = value; }
	}


	//[SerializeField]
	//private float mpCost;

	//public float MP_COST
	//{
	//	get { return mpCost; }
	//	set { mpCost = value; }
	//}

	[SerializeField]
	private float accuracy;

	public float ACCURACY
	{
		get { return accuracy; }
		set { accuracy = value; }
	}




	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
