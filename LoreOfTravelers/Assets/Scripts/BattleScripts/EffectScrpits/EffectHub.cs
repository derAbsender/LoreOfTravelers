using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHub : MonoBehaviour
{
	[SerializeField]
	private RoyalRush royalRush;

	public RoyalRush ROYAL_RUSH
	{
		get { return royalRush; }
		set { royalRush = value; }
	}

	[SerializeField]
	private string effectId;

	public string EFFECT_ID
	{
		get { return effectId; }
		set { effectId = value; }
	}

	[Header("TRIGGER")]
	[SerializeField]
	private bool attackSideEffect;

	public bool ATTACK_SIDE_EFFECT
	{
		get { return attackSideEffect; }
		set { attackSideEffect = value; }
	}
	[SerializeField]
	private bool onField;

	public bool ON_FIELD
	{
		get { return onField; }
		set { onField = value; }
	}



	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void executeAbilityEffect(BattlePosition target, Combatant combatant, Attack attack)
	{
		switch (effectId)
		{
			case "Royal Rush": royalRush.royalRushEffect(target);break;
			default:
				break;
		}
	}
}
