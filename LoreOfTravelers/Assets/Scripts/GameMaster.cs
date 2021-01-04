using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
	public static GameMaster instance;

	[SerializeField]
	private GameObject mainMenu;

	public GameObject MAIN_MENU
	{
		get { return mainMenu; }
		set { mainMenu = value; }
	}


	[SerializeField]
	private List<PlayerFigure> playerParty;

	public List<PlayerFigure> PLAYER_PARTY
	{
		get { return playerParty; }
		set { playerParty = value; }
	}

	[SerializeField]
	private Item[] allItems;

	public Item[] ALL_ITEMS
	{
		get { return allItems; }
		set { allItems = value; }
	}


	// Start is called before the first frame update
	void Start()
    {
		instance = this;

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
