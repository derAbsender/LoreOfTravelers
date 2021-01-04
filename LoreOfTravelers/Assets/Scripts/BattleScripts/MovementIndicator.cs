using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementIndicator : MonoBehaviour
{
	[SerializeField]
	private BattlePosition assignedPosition;

	public BattlePosition ASSIGNED_POSITION
	{
		get { return assignedPosition; }
		set { assignedPosition = value; }
	}
	[SerializeField]
	private Combatant currentCombatant;

	public Combatant CURRENT_COMBATANT
	{
		get { return currentCombatant; }
		set { currentCombatant = value; }
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
