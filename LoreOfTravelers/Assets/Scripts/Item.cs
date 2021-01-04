using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	[SerializeField]
	private float hpRegen;

	public float HP_REGEN
	{
		get { return hpRegen; }
		set { hpRegen = value; }
	}

	[SerializeField]
	private float mpRegen;

	public float MP_REGEN
	{
		get { return mpRegen; }
		set { mpRegen = value; }
	}

	[SerializeField]
	private float spRegen;

	public float SP_REGEN
	{
		get { return spRegen; }
		set { spRegen = value; }
	}

	[SerializeField]
	private float cpRegen;

	public float CP_REGEN
	{
		get { return cpRegen; }
		set { cpRegen = value; }
	}

	[SerializeField]
	private float pAtkChange;

	public float P_ATK_CHANGE
	{
		get { return pAtkChange; }
		set { pAtkChange = value; }
	}

	[SerializeField]
	private float pDefChange;

	public float P_DEF_CHANGE
	{
		get { return pDefChange; }
		set { pDefChange = value; }
	}

	[SerializeField]
	private float iAtkChange;

	public float I_ATK_CHANGE
	{
		get { return iAtkChange; }
		set { iAtkChange = value; }
	}

	[SerializeField]
	private float iDefChange;

	public float I_DEF_CHANGE
	{
		get { return iDefChange; }
		set { iDefChange = value; }
	}

	[SerializeField]
	private float eDefChange;

	public float E_DEF_CHANGE
	{
		get { return eDefChange; }
		set { eDefChange = value; }
	}

	[SerializeField]
	private float eAtkChange;

	public float E_ATK_CHANGE
	{
		get { return eAtkChange; }
		set { eAtkChange = value; }
	}

	[SerializeField]
	private float cAtkChange;

	public float C_ATK_CHANGE
	{
		get { return cAtkChange; }
		set { cAtkChange = value; }
	}

	[SerializeField]
	private float cDefChange;

	public float C_DEF_CHANGE
	{
		get { return cDefChange; }
		set { cDefChange = value; }
	}

	//CURE////////////////////////////////////////////////////////////////////////

	[SerializeField]
	private bool swarmCure;

	public bool SWARM_CURE
	{
		get { return swarmCure; }
		set { swarmCure = value; }
	}

	//META////////////////////////////////////////////////////////////////////////

	[SerializeField]
	private Image itemImage;

	public Image ITEM_IMAGE
	{
		get { return itemImage; }
		set { itemImage = value; }
	}
	//BATTLEMASTER VS GAMEMASTER
	/*
		BattleMaster was coded with IMAGE (Image)
		The item code starts with an SPRITE (Sprite)
		 */

	[SerializeField]
	private Sprite itemSprite;

	public Sprite ITEM_SPRITE
	{
		get { return itemSprite; }
		set { itemSprite = value; }
	}


	[SerializeField]
	private string itemName;

	public string ITEM_NAME
	{
		get { return itemName; }
		set { itemName = value; }
	}

	[SerializeField]
	private string lore;

	public string LORE
	{
		get { return lore; }
		set { lore = value; }
	}

	[SerializeField]
	private string functionTextImage;

	public string FUNCTION
	{
		get { return functionTextImage; }
		set { functionTextImage = value; }
	}

	[SerializeField]
	private int stackSize;

	public int STACK_SIZE
	{
		get { return stackSize; }
		set { stackSize = value; }
	}

	[SerializeField]
	private string inventoryId;

	public string INVENTORY_ID
	{
		get { return inventoryId; }
		set { inventoryId = value; }
	}

	[SerializeField]
	private PlayerFigure owner;

	public PlayerFigure OWNER
	{
		get { return owner; }
		set { owner = value; }
	}



	[SerializeField]
	private int amount;

	public int AMOUNT
	{
		get { return amount; }
		set { amount = value; }
	}

	[SerializeField]
	private Combatant target;

	public Combatant TARGET
	{
		get { return target; }
		set { target = value; }
	}

	[SerializeField]
	private float worth;

	public float WORTH
	{
		get { return worth; }
		set { worth = value; }
	}

	[SerializeField]
	private Text amountText;

	public Text AMOUNT_TEXT
	{
		get { return amountText; }
		set { amountText = value; }
	}




	// Start is called before the first frame update
	void Start()
	{
		//currentAmount.Add(owner, amount);
		//Debug.Log(currentAmount.Count);
		//AMOUNT_TEXT.text = "" + AMOUNT;
		//INVENTORY_ID = OWNER.NAME;
		//Debug.Log(INVENTORY_ID);

	}

	public void useItem(Combatant target, Item item)
	{
		target.HP += item.hpRegen;
		target.SP += item.spRegen;
		target.MP += item.mpRegen;
		target.CP += item.cpRegen;

		target.P_ATK += item.pAtkChange;
		target.I_ATK += item.iAtkChange;
		target.E_ATK += item.eAtkChange;
		target.C_ATK += item.cAtkChange;

		target.P_DEF += item.pDefChange;
		target.I_DEF += item.iDefChange;
		target.E_DEF += item.eDefChange;
		target.C_DEF += item.cDefChange;

		//item.currentAmount[item.owner]--;

		BattleMaster.instance.controlMaxandMin(target);
		BattleMaster.instance.endTurn();
	}

	public void updateAmount()
	{
		AMOUNT_TEXT.text = "" + AMOUNT;
	}
	
	public void updateInventoryPositionID(string positionID)
	{
		INVENTORY_ID = positionID;
	}

	public Item getItem()
	{
		return this;
	}
	public void setItem(Item item)
	{
		hpRegen = item.hpRegen;
		mpRegen = item.mpRegen;
		spRegen = item.spRegen;
		cpRegen = item.cpRegen;
		pAtkChange = item.pAtkChange;
		pDefChange = item.pDefChange;
		iAtkChange = item.iAtkChange;
		iDefChange = item.iDefChange;
		eDefChange = item.eDefChange;
		eAtkChange = item.eAtkChange;
		cAtkChange = item.cAtkChange;
		cDefChange = item.cDefChange;
		swarmCure = item.swarmCure;
		itemImage = item.itemImage;
		itemSprite = item.itemSprite;
		itemName = item.itemName;
		lore = item.lore;
		functionTextImage = item.functionTextImage;
		stackSize = item.stackSize;
		inventoryId = item.inventoryId;
		owner = item.owner;
		amount = item.amount;
		target = item.target;
		worth = item.worth;
		amountText = item.amountText;
	}
}
