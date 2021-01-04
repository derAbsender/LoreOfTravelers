using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
	public static GameMenu instance;

	[SerializeField]
	private GameObject mainMenu;

	public GameObject MAIN_MENU
	{
		get { return mainMenu; }
		set { mainMenu = value; }
	}




	public GameObject[] figure_TokenSlot;
	public GameObject figure_Token;

	public GameObject[] item_SlotPocket;
	public GameObject[] item_SlotBagPack;
	public GameObject[] item_SlotArmor;
	public GameObject[] item_SlotWeapon;
	public GameObject[] item_SlotTotem;
	public GameObject item_Token;


	private List<PlayerFigure> playerStats;

	//STAT_BAR-VALUES
	[Header("STAT_BAR-VALUES")]
	#region
	[SerializeField]
	private Text hpText;

	public Text HP_TEXT
	{
		get { return hpText; }
		set { hpText = value; }
	}

	[SerializeField]
	private Text spText;

	public Text SP_TEXT
	{
		get { return spText; }
		set { spText = value; }
	}

	[SerializeField]
	private Text mpText;

	public Text MP_TEXT
	{
		get { return mpText; }
		set { mpText = value; }
	}

	[SerializeField]
	private Text cpText;

	public Text CP_TEXT
	{
		get { return cpText; }
		set { cpText = value; }
	}
	#endregion

	[SerializeField]
	private Text figureName;

	public Text FIGURE_NAME
	{
		get { return figureName; }
		set { figureName = value; }
	}
	[Header("SLIDER")]
	//SLIDER
	#region
	[SerializeField]
	private Slider hpSlider;

	public Slider HP_SLIDER
	{
		get { return hpSlider; }
		set { hpSlider = value; }
	}

	[SerializeField]
	private Slider mpSlider;

	public Slider MP_SLIDER
	{
		get { return mpSlider; }
		set { mpSlider = value; }
	}

	[SerializeField]
	private Slider spSlider;

	public Slider SP_SLIDER
	{
		get { return spSlider; }
		set { spSlider = value; }
	}

	[SerializeField]
	private Slider cpSlider;

	public Slider CP_SLIDER
	{
		get { return cpSlider; }
		set { cpSlider = value; }
	}
	#endregion
	[SerializeField]
	private Image characterImage;

	public Image CHARACTER_IMAGE
	{
		get { return characterImage; }
		set { characterImage = value; }
	}

	[SerializeField]
	private Text ActionButtonText;

	public Text ACTION_BUTTON_TEXT
	{
		get { return ActionButtonText; }
		set { ActionButtonText = value; }
	}

	[SerializeField]
	private string ActionButtonTextReturn;

	public string ACTION_BUTTON_TEXT_RETURN
	{
		get { return ActionButtonTextReturn; }
		set { ActionButtonTextReturn = value; }
	}

	//InventoryOfOneChar swapping for path owner.OWNED_ITEMS in combination with owner.ITEM_POSITION_ID

	Dictionary<PlayerFigure, List<GameObject>> inventoryOfOneChar = new Dictionary<PlayerFigure, List<GameObject>>();

	[SerializeField]
	private bool isDragging;

	public bool IS_DRAGGING
	{
		get { return isDragging; }
		set { isDragging = value; }
	}

	[SerializeField]
	private bool bagpackOpen;

	public bool BAGPACK_OPEN
	{
		get { return bagpackOpen; }
		set { bagpackOpen = value; }
	}

	// Start is called before the first frame update
	void Start()
    {
		instance = this;
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire1") && !isDragging)
		{
			initializeItemTokens();
			openMainMenu();
			ActionButtonText.text = "Open Bagpack";
		}
	}

	private void initializeItemTokens()
	{
		foreach (var player in GameMaster.instance.PLAYER_PARTY)
		{
			if (player.ITEM_POSITION_ID.Count == player.OWNED_ITEMS.Count)
			{
				//Debug.Log(player.ITEM_POSITION_ID.Count);
				for (int i = 0; i < player.OWNED_ITEMS.Count; i++)
				{
					if (player.OWNED_ITEMS[i].INVENTORY_ID == "")
					{
						player.OWNED_ITEMS[i].INVENTORY_ID = player.ITEM_POSITION_ID[i];
					}
				}
			}
		}
		
	}

	public void openMainMenu()
	{
		if (mainMenu.activeInHierarchy)
		{
			foreach (var slot in figure_TokenSlot)
			{
				if (slot.transform.childCount > 0)
				{
					Destroy(slot.GetComponentInChildren<Draggable>().gameObject);
				}
			}

			foreach (var player in GameMaster.instance.PLAYER_PARTY)
			{
				foreach (var item in inventoryOfOneChar[player])
				{
					if (item.GetComponent<ItemToken>())
					{
						Destroy(item.GetComponent<ItemToken>().gameObject);
					}
				}
			}

			inventoryOfOneChar.Clear();
			mainMenu.SetActive(false);
		}
		else
		{				
			mainMenu.SetActive(true);
			WIP_showInfo();
			foreach (var player in GameMaster.instance.PLAYER_PARTY)
			{
				readyItemManagement(player);
			}		
		}
	}

	private void WIP_showInfo()
	{
		playerStats = GameMaster.instance.PLAYER_PARTY;
		for (int i = 0; i < playerStats.Count; i++)
		{
			for (int j = 0; j < figure_TokenSlot.Length; j++)
			{
				if (playerStats[i].SPAWN_POSITION_ID == figure_TokenSlot[j].GetComponent<FigurSlot>().SPAWN_POSITION_ID)
				{
					figure_Token.GetComponentInChildren<Text>().text = playerStats[i].NAME;
					figure_Token.GetComponent<FigureToken>().FIGURE_ID = playerStats[i].FIGURE_ID;
					Instantiate(figure_Token, figure_TokenSlot[j].transform);
				}				
			}
		}
		for (int i = 0; i < figure_TokenSlot.Length; i++)
		{
			if (figure_TokenSlot[i].GetComponent<FigureToken>() != null)
			{				
				Instantiate(figure_Token, figure_TokenSlot[i].transform);
				figure_TokenSlot[i].GetComponentInChildren<CanvasGroup>().alpha = 0;
			}
		}
	}

	private void readyItemManagement(PlayerFigure player)
	{
		List<GameObject> gameObjectList = new List<GameObject>();
		//Debug.Log(player.NAME);
		if (inventoryOfOneChar.ContainsKey(player))
		{
			inventoryOfOneChar.Remove(player);
		}
		foreach (var item in player.OWNED_ITEMS)
		{
			if (!setItemPositions(item, item_SlotPocket, gameObjectList))
			{
				if (!setItemPositions(item, item_SlotBagPack, gameObjectList))
				{
					if (!setItemPositions(item, item_SlotArmor, gameObjectList))
					{
						if (!setItemPositions(item, item_SlotWeapon, gameObjectList))
						{
							if (setItemPositions(item, item_SlotTotem, gameObjectList))
							{
									
							}
						}
					}
				}
			}		
		}
		//Debug.Log(gameObjectList.Count);
		inventoryOfOneChar.Add(player, gameObjectList);			
	}

	private bool setItemPositions(Item item, GameObject[] slots, List<GameObject> lgo)
	{
		bool match = false;
		for (int i = 0; i < slots.Length; i++)
		{
			if (item.INVENTORY_ID == slots[i].GetComponent<ItemSlot>().SLOT_ID)
			{
				GameObject tempItem = Instantiate(item_Token, slots[i].GetComponent<ItemSlot>().transform);
				tempItem.GetComponentInChildren<Text>().text = item.AMOUNT.ToString();
				//tempItem.GetComponent<ItemToken>().ITEM_ID = item.INVENTORY_ID;
				tempItem.GetComponent<ItemToken>().typeOfThisToken = item.GetComponent<ItemToken>().typeOfThisToken;
				tempItem.GetComponent<Image>().sprite = item.ITEM_SPRITE;
				tempItem.GetComponent<Item>().setItem(item);

				lgo.Add(tempItem);
				match = true;
				break;
			}
		}
		return match;
	}

	public void updateMainStats(string playerId)
	{
		playerStats = GameMaster.instance.PLAYER_PARTY;
		
		for (int i = 0; i < playerStats.Count; i++)
		{
			if (playerStats[i].FIGURE_ID == playerId)
			{
				figureName.text = playerStats[i].NAME;
				hpText.text = "" + playerStats[i].HP + " | " + playerStats[i].HP_MAX;
				mpText.text = "" + playerStats[i].MP + " | " + playerStats[i].MP_MAX;
				spText.text = "" + playerStats[i].SP + " | " + playerStats[i].SP_MAX;
				cpText.text = "" + playerStats[i].CP + " | " + playerStats[i].CP_MAX;

				hpSlider.maxValue = playerStats[i].HP_MAX;
				hpSlider.value = playerStats[i].HP;

				spSlider.maxValue = playerStats[i].SP_MAX;
				spSlider.value = playerStats[i].SP;

				mpSlider.maxValue = playerStats[i].MP_MAX;
				mpSlider.value = playerStats[i].MP;

				cpSlider.maxValue = playerStats[i].CP_MAX;
				cpSlider.value = playerStats[i].CP;

				characterImage.sprite = playerStats[i].CHARACTER_IMAGE;

				updateLoadOut(playerStats[i]);
			}			
		}
		
	}

	public void changeButtonToDisposable()
	{
		ActionButtonTextReturn = ActionButtonText.text;
		ActionButtonText.text = "DISPOSE";
	}
	public void changeButtonToCloseBag()
	{
		ActionButtonText.text = ActionButtonTextReturn;
	}

	public void updateLoadOut(PlayerFigure player)
	{
		//Debug.Log("INV COUNT "+ inventoryOfOneChar[player].Count);
		if (inventoryOfOneChar.ContainsKey(player))
		{
			for (int i = 0; i < item_SlotPocket.Length; i++)
			{
				if (item_SlotPocket[i].transform.childCount > 0)
				{
					Destroy(item_SlotPocket[i].transform.GetChild(0).gameObject);
				}
			}
			for (int i = 0; i < item_SlotBagPack.Length; i++)
			{
				if (item_SlotBagPack[i].transform.childCount > 0)
				{
					Destroy(item_SlotBagPack[i].transform.GetChild(0).gameObject);
				}
			}
			for (int i = 0; i < item_SlotArmor.Length; i++)
			{
				if (item_SlotArmor[i].transform.childCount > 0)
				{
					Destroy(item_SlotArmor[i].transform.GetChild(0).gameObject);
				}
			}
			for (int i = 0; i < item_SlotWeapon.Length; i++)
			{
				if (item_SlotWeapon[i].transform.childCount > 0)
				{
					Destroy(item_SlotWeapon[i].transform.GetChild(0).gameObject);
				}
			}
			for (int i = 0; i < item_SlotTotem.Length; i++)
			{
				if (item_SlotTotem[i].transform.childCount > 0)
				{
					Destroy(item_SlotTotem[i].transform.GetChild(0).gameObject);
				}
			}

			readyItemManagement(player);
		}		
	}

	public void updateInventoryArrangement(PlayerFigure owner)
	{
		//Debug.Log("updateInventoryArrangement");
		if (inventoryOfOneChar.ContainsKey(owner))
		{
			inventoryOfOneChar[owner].Clear();
			updateBagTypes(owner, item_SlotBagPack);
			updateBagTypes(owner, item_SlotArmor);
			updateBagTypes(owner, item_SlotWeapon);
			updateBagTypes(owner, item_SlotPocket);
			updateBagTypes(owner, item_SlotTotem);
		}		
	}

	private void updateBagTypes(PlayerFigure owner, GameObject[] slots)
	{
		//Debug.Log("update");
		foreach (var item in slots)
		{
			if (item.transform.childCount > 0 && 
				item.GetComponentInChildren<Item>() && 
				controlItemAmount(item.GetComponentInChildren<Item>()))
			{
				inventoryOfOneChar[owner].Add(item.transform.GetChild(0).gameObject);
			}
		}
	}

	private bool controlItemAmount(Item item)
	{
		if (item.AMOUNT <= 0)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

	public void updateInventoryPosition(PlayerFigure owner, string newPosition, string oldPosition)
	{
		Debug.Log("PRO " + inventoryOfOneChar[owner].Count);
		if (inventoryOfOneChar.ContainsKey(owner))
		{
			for (int i = 0; i < inventoryOfOneChar[owner].Count; i++)
			{
				Debug.Log("POST " + inventoryOfOneChar[owner].Count);
				if (inventoryOfOneChar[owner][i].GetComponent<Item>().INVENTORY_ID == oldPosition)
				{
					inventoryOfOneChar[owner][i].GetComponent<Item>().INVENTORY_ID = newPosition;
					break;
				}
			}
		}
		//Debug.Log("PRO " + owner.OWNED_ITEMS.Count);
		for (int i = 0; i < owner.OWNED_ITEMS.Count; i++)
		{
			//Debug.Log("POST " + owner.OWNED_ITEMS.Count);
			if (owner.OWNED_ITEMS[i].INVENTORY_ID == oldPosition)
			{
				owner.OWNED_ITEMS[i].INVENTORY_ID = newPosition;
				break;
			}
		}		
	}

	public void deleteItemInPool(PlayerFigure owner, string id)
	{
		for (int i = 0; i < inventoryOfOneChar[owner].Count; i++)
		{
			if (inventoryOfOneChar[owner][i].GetComponent<Item>().INVENTORY_ID == id)
			{
				inventoryOfOneChar[owner].RemoveAt(i);
			}
		}
	}
	public void addItemToInventory(PlayerFigure owner, Item newItem)
	{		
		bool isContained = false;
		foreach (var item in owner.OWNED_ITEMS)
		{
			if (item.INVENTORY_ID == newItem.INVENTORY_ID)
			{
				isContained = true;
				break;
			}
		}
		if (!isContained)
		{
			owner.OWNED_ITEMS.Add(newItem);
		}
	}
}
