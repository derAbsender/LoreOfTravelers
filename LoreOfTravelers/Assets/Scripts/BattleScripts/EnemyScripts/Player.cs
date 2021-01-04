using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Combatant
{

	[SerializeField]
	private GameObject movementIndicator;

	public GameObject MOVEMENT_INDICATOR
	{
		get { return movementIndicator; }
		set { movementIndicator = value; }
	}

	[SerializeField]
	private GameObject PlayerBaseOptions;

	public GameObject PLAYER_BASE_OPTIONS
	{
		get { return PlayerBaseOptions; }
		set { PlayerBaseOptions = value; }
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
