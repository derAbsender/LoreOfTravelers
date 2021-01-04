using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFigure : MonoBehaviour
{
	[SerializeField]
	private string figureID;

	public string FIGURE_ID
	{
		get { return figureID; }
		set { figureID = value; }
	}


	[SerializeField]
	private Sprite characterImage;

	public Sprite CHARACTER_IMAGE
	{
		get { return characterImage; }
		set { characterImage = value; }
	}


	[SerializeField]//Soll im enemy script behandelt werden
	private string figureName;

	public string NAME
	{
		get { return figureName; }
		set { figureName = value; }
	}

	[SerializeField]
	private string spawnPositionID;

	public string SPAWN_POSITION_ID
	{
		get { return spawnPositionID; }
		set { spawnPositionID = value; }
	}


	[SerializeField]
	private Element[] elementType;

	public Element[] ELEMENT_TYPE
	{
		get { return elementType; }
		set { elementType = value; }
	}

	[Header("Bars")]

	[SerializeField]
	private float health;

	public float HP
	{
		get { return health; }
		set { health = value; }
	}
	[SerializeField]
	private float healthMax;

	public float HP_MAX
	{
		get { return healthMax; }
		set { healthMax = value; }
	}

	[SerializeField]
	private float stamina;

	public float SP
	{
		get { return stamina; }
		set { stamina = value; }
	}
	[SerializeField]
	private float staminaMax;

	public float SP_MAX
	{
		get { return staminaMax; }
		set { staminaMax = value; }
	}

	[SerializeField]
	private float magic;

	public float MP
	{
		get { return magic; }
		set { magic = value; }
	}
	[SerializeField]
	private float magicMax;

	public float MP_MAX
	{
		get { return magicMax; }
		set { magicMax = value; }
	}
	[SerializeField]
	private float charisma;

	public float CP
	{
		get { return charisma; }
		set { charisma = value; }
	}
	[SerializeField]
	private float charismaMax;

	public float CP_MAX
	{
		get { return charismaMax; }
		set { charismaMax = value; }
	}

	[Header("Battle Values")]
	[Header("Physical")]
	[SerializeField]
	private float physicalATK;

	public float P_ATK
	{
		get { return physicalATK; }
		set { physicalATK = value; }
	}
	[SerializeField]
	private float physicalATKMax;

	public float P_ATK_MAX
	{
		get { return physicalATKMax; }
		set { physicalATKMax = value; }
	}
	[SerializeField]
	private float phsyicalATKMin;

	public float P_ATK_MIN
	{
		get { return phsyicalATKMin; }
		set { phsyicalATKMin = value; }
	}

	[SerializeField]
	private float physicalDEF;

	public float P_DEF
	{
		get { return physicalDEF; }
		set { physicalDEF = value; }
	}
	[SerializeField]
	private float physicalDEFMax;

	public float P_DEF_MAX
	{
		get { return physicalDEFMax; }
		set { physicalDEFMax = value; }
	}
	[SerializeField]
	private float physicalDEFMin;

	public float P_DEF_MIN
	{
		get { return physicalDEFMin; }
		set { physicalDEFMin = value; }
	}
	[Header("Magical")]
	[SerializeField]
	private float intelligenceATK;

	public float I_ATK
	{
		get { return intelligenceATK; }
		set { intelligenceATK = value; }
	}
	[SerializeField]
	private float intelligenceATKMax;

	public float I_ATK_MAX
	{
		get { return intelligenceATKMax; }
		set { intelligenceATKMax = value; }
	}
	[SerializeField]
	private float intelligenceATKMin;

	public float I_ATK_MIN
	{
		get { return intelligenceATKMin; }
		set { intelligenceATKMin = value; }
	}

	[SerializeField]
	private float intelligenceDEF;

	public float I_DEF
	{
		get { return intelligenceDEF; }
		set { intelligenceDEF = value; }
	}
	[SerializeField]
	private float intelligenceDEFMax;

	public float I_DEF_MAX
	{
		get { return intelligenceDEFMax; }
		set { intelligenceDEFMax = value; }
	}
	[SerializeField]
	private float intelligenceDEFMin;

	public float I_DEF_MIN
	{
		get { return intelligenceDEFMin; }
		set { intelligenceDEFMin = value; }
	}

	[Header("enduring")]
	[SerializeField]
	private float enduranceATK;

	public float E_ATK
	{
		get { return enduranceATK; }
		set { enduranceATK = value; }
	}
	[SerializeField]
	private float enduranceATKMax;

	public float E_ATK_MAX
	{
		get { return enduranceATKMax; }
		set { enduranceATKMax = value; }
	}
	[SerializeField]
	private float enduranceATKMin;

	public float E_ATK_MIN
	{
		get { return enduranceATKMin; }
		set { enduranceATKMin = value; }
	}

	[SerializeField]
	private float enduranceDEF;

	public float E_DEF
	{
		get { return enduranceDEF; }
		set { enduranceDEF = value; }
	}
	[SerializeField]
	private float enduranceDEFMax;

	public float E_DEF_MAX
	{
		get { return enduranceDEFMax; }
		set { enduranceDEFMax = value; }
	}
	[SerializeField]
	private float enduranceDEFMin;

	public float E_DEF_MIN
	{
		get { return enduranceDEFMin; }
		set { enduranceDEFMin = value; }
	}

	[Header("charismatic")]
	[SerializeField]
	private float charismaATK;

	public float C_ATK
	{
		get { return charismaATK; }
		set { charismaATK = value; }
	}
	[SerializeField]
	private float charismaATKMax;

	public float C_ATK_MAX
	{
		get { return charismaATKMax; }
		set { charismaATKMax = value; }
	}
	[SerializeField]
	private float charismaATKMin;

	public float C_ATK_MIN
	{
		get { return charismaATKMin; }
		set { charismaATKMin = value; }
	}

	[SerializeField]
	private float charismaDEF;

	public float C_DEF
	{
		get { return charismaDEF; }
		set { charismaDEF = value; }
	}
	[SerializeField]
	private float charismaDEFMax;

	public float C_DEF_MAX
	{
		get { return charismaDEFMax; }
		set { charismaDEFMax = value; }
	}
	[SerializeField]
	private float charismaDEFMin;

	public float C_DEF_MIN
	{
		get { return charismaDEFMin; }
		set { charismaDEFMin = value; }
	}


	[Header("Speed")]
	[SerializeField]
	private float speed;

	public float SPD
	{
		get { return speed; }
		set { speed = value; }
	}
	[SerializeField]
	private float speedMax;

	public float SPD_MAX
	{
		get { return speedMax; }
		set { speedMax = value; }
	}
	[SerializeField]
	private float speedMin;

	public float SPD_MIN
	{
		get { return speedMin; }
		set { speedMin = value; }
	}
	[Header("AccuracyKomplex")]

	[SerializeField]
	private float accuracyValue;

	public float ACCU_VAL
	{
		get { return accuracyValue; }
		set { accuracyValue = value; }
	}
	[SerializeField]
	private float accuracyMaxValue;

	public float ACCU_MAX_VAL
	{
		get { return accuracyMaxValue; }
		set { accuracyMaxValue = value; }
	}
	[SerializeField]
	private float accuracyMinValue;

	public float ACCU_MIN_VAL
	{
		get { return accuracyMinValue; }
		set { accuracyMinValue = value; }
	}

	/// <summary>
	/// //////////////////////////////////////////////
	/// </summary>

	[SerializeField]
	private List<Item> ownedItems;

	public List<Item> OWNED_ITEMS
	{
		get { return ownedItems; }
		set { ownedItems = value; }
	}

	[SerializeField]
	private List<string> itemPositionID;

	public List<string> ITEM_POSITION_ID
	{
		get { return itemPositionID; }
		set { itemPositionID = value; }
	}


	[Header("TOKEN INFO")]
	[SerializeField]
	private List<string> tokenPosition;

	public List<string> TOKEN_POSITION
	{
		get { return tokenPosition; }
		set { tokenPosition = value; }
	}


	// Start is called before the first frame update
	void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	

	public void updateItemTokenPosition()
	{

	}

	public bool removeItemFromInventory(Item item)
	{
		for (int i = 0; i < ownedItems.Count; i++)
		{
			if (ownedItems[i].INVENTORY_ID == item.INVENTORY_ID)
			{
				ownedItems.RemoveAt(i);
				itemPositionID.RemoveAt(i);
				return true;
			}
		}
		return false;
	}


}
