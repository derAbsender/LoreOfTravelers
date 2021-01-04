using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combatant : MonoBehaviour
{
	[SerializeField]
	private Image characterImage;

	public Image CHARACTER_IMAGE
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
	private int packSizeMin;

	public int PACK_min_SIZE
	{
		get { return packSizeMin; }
		set { packSizeMin = value; }
	}
	[SerializeField]
	private int packSizeMax;

	public int PACK_MAX_SIZE
	{
		get { return packSizeMax; }
		set { packSizeMax = value; }
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


	[SerializeField]
	private float accuracy;

	public float ACCU
	{
		get { return accuracy; }
		set { accuracy = value; }
	}
	[SerializeField]
	private float accuracyMax;

	public float ACCU_MAX
	{
		get { return accuracyMax; }
		set { accuracyMax = value; }
	}
	[SerializeField]
	private float accuracyMin;

	public float ACCU_MIN
	{
		get { return accuracyMin; }
		set { accuracyMin = value; }
	}
	[Header("Ability")]
	[SerializeField]
	private EffectHub ability;

	public EffectHub ABILITY
	{
		get { return ability; }
		set { ability = value; }
	}
	[SerializeField]
	private string effectName;

	public string EFFECT_NAME
	{
		get { return effectName; }
		set { effectName = value; }
	}


	[SerializeField]
	private Attack[] knownAttacks;

	public Attack[] KNOWN_ATTACKS
	{
		get { return knownAttacks; }
		set { knownAttacks = value; }
	}


	[SerializeField]
	private string playerSpawnPoint;

	public string PLAYER_SPAWN_POINT
	{
		get { return playerSpawnPoint; }
		set { playerSpawnPoint = value; }
	}


	[SerializeField]
	Wiggyat wiggyat;

	//[SerializeField]
	//Player player;

	[SerializeField]
	Peele peele;

	//[SerializeField]
	//Mokianer mokianer;

	[SerializeField]
	BeeKing beeKing;

	[SerializeField]
	BeeQueen beeQueen;

	[SerializeField]
	private Item[] battleInventory;

	public Item[] BATTLE_INVENTORY
	{
		get { return battleInventory; }
		set { battleInventory = value; }
	}



	[SerializeField]
	private BattlePosition currentPosition;

	public BattlePosition CURR_POS
	{
		get { return currentPosition; }
		set { currentPosition = value; }
	}

	[SerializeField]
	private List<BattlePosition> neighbors;

	public List<BattlePosition> NEIGHBORS
	{
		get { return neighbors; }
		set { neighbors = value; }
	}

	[SerializeField]
	private List<GameObject> movementOptions;

	public List<GameObject> MOVEMENT_OPTIONS
	{
		get { return movementOptions; }
		set { movementOptions = value; }
	}
	//[SerializeField]
	//BattlePosition battlePositionConvert;

	[SerializeField]
	private Attack currentAttack;

	public Attack CURRENT_ATTACK
	{
		get { return currentAttack; }
		set { currentAttack = value; }
	}

	[SerializeField]
	private bool isPreparing;

	public bool IS_PREPARING
	{
		get { return isPreparing; }
		set { isPreparing = value; }
	}

	[SerializeField]
	private bool isExhausted;

	public bool IS_EXHAUSTED
	{
		get { return isExhausted; }
		set { isExhausted = value; }
	}

	[SerializeField]
	private List<string> attackedPositions;

	public List<string> ATTACKED_POSITIONS
	{
		get { return attackedPositions; }
		set { attackedPositions = value; }
	}

	[SerializeField]
	private Image figureSprite;

	public Image FIGURE_SPRITE
	{
		get { return figureSprite; }
		set { figureSprite = value; }
	}


	[SerializeField]
	private bool isAlly;

	public bool ALLY
	{
		get { return isAlly; }
		set { isAlly = value; }
	}

	[SerializeField]
	private bool isDemoralized;

	public bool IS_DEMORALIZED
	{
		get { return isDemoralized; }
		set { isDemoralized = value; }
	}
	[SerializeField]
	private bool isMegalomaniac;

	public bool IS_MEGALOMANIAC
	{
		get { return isMegalomaniac; }
		set { isMegalomaniac = value; }
	}


	[SerializeField]
	private bool isSwarmed;

	public bool SWARMED
	{
		get { return isSwarmed; }
		set { isSwarmed = value; }
	}

	[SerializeField]
	private bool isKnockedOut;

	public bool IS_KO
	{
		get { return isKnockedOut; }
		set { isKnockedOut = value; }
	}


	[SerializeField]//? (Wird im BattleManager instantiiert
	private string id;

	public string BattleID
	{
		get { return id; }
		set { id = value; }
	}
	[SerializeField]
	private float spRegenFactor;

	public float SP_REGEN_FACTOR
	{
		get { return spRegenFactor; }
		set { spRegenFactor = value; }
	}

	private int currentAttackFieldCount;

	public int CURR_ATTACK_FIELD_COUNT
	{
		get { return currentAttackFieldCount; }
		set { currentAttackFieldCount = value; }
	}

	[SerializeField]
	private List<BattlePosition> actionField;

	public List<BattlePosition> ACTION_FIELD
	{
		get { return actionField; }
		set { actionField = value; }
	}
	[SerializeField]
	private List<BattlePosition> rumbleField;

	public List<BattlePosition> RUMBLE_FIELD
	{
		get { return rumbleField; }
		set { rumbleField = value; }
	}


	[SerializeField]
	private GameObject informationVisual;

	public GameObject INFORMATION_VISUAL
	{
		get { return informationVisual; }
		set { informationVisual = value; }
	}

	[SerializeField]
	private Slider miniVisualHP;

	public Slider MINI_VISUAL_HP
	{
		get { return miniVisualHP; }
		set { miniVisualHP = value; }
	}
	[SerializeField]
	private Slider miniVisualSP;

	public Slider MINI_VISUAL_SP
	{
		get { return miniVisualSP; }
		set { miniVisualSP = value; }
	}
	[SerializeField]
	private Slider miniVisualMP;

	public Slider MINI_VISUAL_MP
	{
		get { return miniVisualMP; }
		set { miniVisualMP = value; }
	}
	[SerializeField]
	private Slider miniVisualCP;

	public Slider MINI_VISUAL_CP
	{
		get { return miniVisualCP; }
		set { miniVisualCP = value; }
	}

	[SerializeField]
	private Image[] glare;

	public Image[] GLARE
	{
		get { return glare; }
		set { glare = value; }
	}
	[SerializeField]
	private GameObject glareObject;

	public GameObject GLARE_OBJECT
	{
		get { return glareObject; }
		set { glareObject = value; }
	}

	public int spawnEnemy(Combatant enemy)
	{
		spRegenFactor = 2;
		int packsize = determinPackSize();
		int packsizeMemory = packsize;

		do
		{
			for (int i = 0; i < BattleMaster.instance.INDIPOS.Length; i++)
			{
				if (BattleMaster.instance.INDIPOS[i].POS_TYPE == PositionType.spawn && !BattleMaster.instance.INDIPOS[i].IS_ALLY)
				{
					if (packsize == 0)
					{
						break;
					}
					//Debug.Log(BattleMaster.instance.INDIPOS[i].isOccupied());
					if (Random.Range(0, 10) % 3 == 0 && !BattleMaster.instance.INDIPOS[i].CURRENTLY_OCCUPIED)
					{
						findPlaceToSPawn(BattleMaster.instance.INDIPOS[i], enemy);
						packsize--;

					}
				}
			}
		} while (packsize > 0);

		

		return packsizeMemory;
	}

	private bool findPlaceToSPawn(BattlePosition position, Combatant combatant)
	{
		bool match = false;
		
		if (!position.CURRENTLY_OCCUPIED)
		{
			//Debug.Log(position.isOccupied());
			combatant.currentPosition = position;
			combatant.id = "RC_" + position.ROW_COORD + ",CC_" + position.COL_COORD;
			spawnCombatant(position, combatant);



			BattleMaster.instance.ALL_BATTLE_IDs.Add(id);
			match = true;
		}
		

		return match;
	}

	public int spawnFriend(Combatant friend)
	{

		foreach (var position in BattleMaster.instance.INDIPOS)
		{
			if (position.isContained(playerSpawnPoint))
			{
				if (findPlaceToSPawn(position, friend))
				{
					break;
				}
			}
		}
		return 1;
	}
	private void spawnCombatant(BattlePosition position, Combatant combatant)
	{
		//combatant.CURR_POS.AREA_TILES.Clear();
		//combatant.CURR_POS.IMPACT_TILES.Clear();
		combatant.currentPosition = position;


		//if (combatant.CURR_POS.BORDERING_TILES.Count == 0)
		//{
		//	for (int i = 0; i < BattleMaster.instance.INDIPOS.Length; i++)
		//	{
		//		combatant.CURR_POS.spotBorderingTiles(combatant.CURR_POS, BattleMaster.instance.INDIPOS[i]);
		//	}
		//}
		//if (combatant.CURR_POS.FURTHER_BORDERING_TILES.Count == 0)
		//{
		//	for (int i = 0; i < BattleMaster.instance.INDIPOS.Length; i++)
		//	{
		//		combatant.CURR_POS.spotFurtherBorderingTiles(combatant.CURR_POS, BattleMaster.instance.INDIPOS[i]);
		//	}
		//}

		combatant = Instantiate(combatant, position.transform).GetComponent<Combatant>();
		//combatant.CURR_POS.AREA_TILES = combatant.CURR_POS.spotAreaFields(combatant.CURR_POS);

		//combatant.CURR_POS.IMPACT_TILES = combatant.CURR_POS.addImpactZones(combatant.CURR_POS);
		combatant.IS_EXHAUSTED = false;

		position.FIGURE = combatant;
		BattleMaster.instance.FIGURES.Add("RC_"+position.ROW_COORD+",CC_" +position.COL_COORD, combatant);
		position.CURRENTLY_OCCUPIED = true;
	}

	private int determinPackSize()
	{
		int pack = Random.Range(packSizeMin, packSizeMax + 1);
		return pack;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void loadBehaviour(Combatant combatant)
	{
		string[] decision = new string[2];

		//Debug.Log(combatant.AREA_TILES.Count);
		if (combatant.IS_MEGALOMANIAC)
		{
			decision = combatant.rogueLogic(combatant);
		}
		else
		{
			switch (combatant.NAME)
			{
				case "Wiggyat": decision = wiggyat.makeDecision(combatant); break;
				case "Wiggymoth": decision = wiggyat.makeDecision(combatant); break;
				case "Peele": decision = peele.makeDecision(combatant); break;
			//	case "Mokianer": decision = mokianer.makeDecision(combatant); break;
				case "Bee King": decision = beeKing.makeDecision(combatant); break;
				case "Bee Queen": decision = beeQueen.makeDecision(combatant); break;
				default:
					break;
			}
		}

		Debug.Log(decision[0] + ", " + decision[1]);

		if (decision[0] == "move")
		{
			moving(decision[1], combatant);
		}

		BattleMaster.instance.endTurn();
	}


	public void moving(string position, Combatant combatant)
	{		
		copyToPosition(combatant, position);
	}

	protected void copyToPosition(Combatant combatant, string position)
	{

		//Debug.Log(combatant.NAME);
		Combatant oldCombatant = combatant;
		
		string oldID = "";
		combatant.SP = combatant.SP - combatant.SP_MAX / (combatant.E_ATK/10 + combatant.E_DEF/10);

		//Debug.Log("movement Costs: " + combatant.SP_MAX / (combatant.E_ATK / 10 + combatant.E_DEF / 10));

		
		for (int i = 0; i < BattleMaster.instance.INDIPOS.Length; i++)
		{
			if (BattleMaster.instance.INDIPOS[i].isContained(position))
			{
				if (BattleMaster.instance.INDIPOS[i].CURRENTLY_OCCUPIED)
				{
					Combatant switchedCombatant = oldCombatant;
					for (int j = 0; j < BattleMaster.instance.INDIPOS.Length; j++)
					{
						if (BattleMaster.instance.INDIPOS[j].PositionID == oldCombatant.CURR_POS.PositionID)
						{
							//Debug.Log("J " + BattleMaster.instance.INDIPOS[j].PositionID);//<---- NULL?
							//Debug.Log("I " + BattleMaster.instance.INDIPOS[i].PositionID);
							//Debug.Log("OC " + BattleMaster.instance.INDIPOS[i].FIGURE);     //<---- NULL?!
							//Debug.Log("OC " + switchedCombatant);
							//Debug.Log("OC " + oldCombatant.CURR_POS.transform);
							switchedCombatant = Instantiate(BattleMaster.instance.INDIPOS[i].FIGURE, oldCombatant.CURR_POS.transform);

							BattleMaster.instance.INDIPOS[j].FIGURE = switchedCombatant;
							switchedCombatant.currentPosition = BattleMaster.instance.INDIPOS[j];
				
							oldID = BattleMaster.instance.INDIPOS[i].FIGURE.BattleID;
							switchedCombatant.BattleID = oldID;

							Destroy(BattleMaster.instance.INDIPOS[i].FIGURE.gameObject);

							if (BattleMaster.instance.FIGURES.ContainsKey(BattleMaster.instance.INDIPOS[i].FIGURE.BattleID))
							{
								BattleMaster.instance.FIGURES.Remove(BattleMaster.instance.INDIPOS[i].FIGURE.BattleID);
							}
							

							//Debug.Log("switch figure" + switchedCombatant.CURR_POS.PositionID + "," + switchedCombatant.NAME);

					

							break;
						}
					}
					Combatant movedCombatant = Instantiate(combatant, BattleMaster.instance.INDIPOS[i].transform).GetComponent<Combatant>();
					BattleMaster.instance.INDIPOS[i].FIGURE = movedCombatant;
					movedCombatant.currentPosition = BattleMaster.instance.INDIPOS[i];

					//Debug.Log("FIGURES Count " + BattleMaster.instance.FIGURES.Count);

					string tempID;
					tempID = combatant.BattleID;
					movedCombatant.BattleID = tempID;

					Destroy(combatant.gameObject);
					if (BattleMaster.instance.FIGURES.ContainsKey(BattleMaster.instance.INDIPOS[i].FIGURE.BattleID))
					{
						BattleMaster.instance.FIGURES.Remove(BattleMaster.instance.INDIPOS[i].FIGURE.BattleID);
					}
					//BattleMaster.instance.FIGURES.Add(movedCombatant.BattleID, movedCombatant);

					//Debug.Log("FIGURES COunt " + BattleMaster.instance.FIGURES.Count);

					BattleMaster.instance.FIGURES.Add(movedCombatant.BattleID, movedCombatant);
					//Debug.Log("figures " + switchedCombatant.BattleID + "," + switchedCombatant.NAME);
					//Debug.Log("figures " + movedCombatant.BattleID + "," + movedCombatant.NAME);
					BattleMaster.instance.FIGURES.Add(switchedCombatant.BattleID, switchedCombatant);

					//foreach (var item in BattleMaster.instance.INDIPOS)
					//{
					//	if (item.CURRENTLY_OCCUPIED)
					//	{
					//		Debug.Log("figures CO " + item.FIGURE);
					//		Debug.Log("figures CO " + item.FIGURE.BattleID);
					//		Debug.Log("figures CO " + item.FIGURE.CURR_POS.PositionID);
					//	}
					//}

					break;
				}
				else
				{
					combatant.CURR_POS.CURRENTLY_OCCUPIED = false;

					string tempID;

					combatant.currentPosition = BattleMaster.instance.INDIPOS[i];

					Combatant movedCombatant = Instantiate(combatant, BattleMaster.instance.INDIPOS[i].transform).GetComponent<Combatant>();

					//movedCombatant.CURR_POS.spotSurroundings(movedCombatant.CURR_POS);

					BattleMaster.instance.INDIPOS[i].FIGURE = movedCombatant;

					movedCombatant.currentPosition = BattleMaster.instance.INDIPOS[i];

					tempID = combatant.BattleID;

					movedCombatant.BattleID = tempID;

					movedCombatant.CURR_POS.CURRENTLY_OCCUPIED = true;

					Destroy(combatant.gameObject);
					if (BattleMaster.instance.FIGURES.ContainsKey(combatant.BattleID))
					{
						BattleMaster.instance.FIGURES.Remove(combatant.BattleID);
					}
					BattleMaster.instance.FIGURES.Add(movedCombatant.BattleID, movedCombatant);

					//if (movedCombatant.CURR_POS.POS_TYPE == PositionType.flight)
					//{
					//	deleteCombatant(movedCombatant);
					//}
					//foreach (var item in BattleMaster.instance.INDIPOS)
					//{
					//	if (item.CURRENTLY_OCCUPIED)
					//	{
					//		Debug.Log("figures " + item.FIGURE);
					//	}
					//}

					break;
				}				
			}
		}
	}

	public void deleteCombatant(Combatant combatant)
	{
		for (int i = 0; i < BattleMaster.instance.ALL_BATTLE_IDs.Count; i++)
		{
			if (BattleMaster.instance.ALL_BATTLE_IDs[i] == combatant.BattleID)
			{
				foreach (var item in BattleMaster.instance.INDIPOS)
				{
					if (item.FIGURE && item.FIGURE.BattleID == BattleMaster.instance.ALL_BATTLE_IDs[i])
					{
						Destroy(item.FIGURE.gameObject);
					}
				}
				BattleMaster.instance.REM_COMBATANT_IDs.Add(BattleMaster.instance.ALL_BATTLE_IDs[i]);

				combatant.CURR_POS.CURRENTLY_OCCUPIED = false;

				Destroy(combatant);

				//BattleMaster.instance.TURN_COUNTER_TOKEN ++;
				Debug.Log(combatant.NAME + "|" + combatant.BattleID + " should be destroyed or moved");
			}
		}
	}


	public void moveToButtonPress(MovementIndicator mi)
	{
		string position = "RC_" + mi.ASSIGNED_POSITION.ROW_COORD + ",CC_" + mi.ASSIGNED_POSITION.COL_COORD;

		copyToPosition(mi.CURRENT_COMBATANT, position);

		foreach (var indiposition in BattleMaster.instance.INDIPOS)
		{
			if (indiposition.GetComponentInChildren<MovementIndicator>())
			{
				Destroy(indiposition.GetComponentInChildren<MovementIndicator>().gameObject);
			}
		}

		//BattleMaster.instance.TURN_COUNTER_TOKEN++;

		//BattleMaster.instance.turnDecision();
		BattleMaster.instance.endTurn();
	}


	//ROGUE LOGIC//////////////////////////////////////////////////////////////
	public string[] rogueLogic(Combatant combatant)
	{
		string[] what_where = { "move", "RC_" };

		List<Attack> possibleAttacks = new List<Attack>();
		foreach (var attack in combatant.KNOWN_ATTACKS)
		{
			if (combatant.ALLY && combatant.CURR_POS.ROW_COORD == 0 && attack.usableBack)
			{
				possibleAttacks.Add(attack);
			}
			if (combatant.ALLY && combatant.CURR_POS.ROW_COORD == 1 && attack.usableFront)
			{
				possibleAttacks.Add(attack);
			}
			if (!combatant.ALLY && combatant.CURR_POS.ROW_COORD == 2 && attack.usableFront)
			{
				possibleAttacks.Add(attack);
			}
			if (!combatant.ALLY && combatant.CURR_POS.ROW_COORD == 3 && attack.usableBack)
			{
				possibleAttacks.Add(attack);
			}
		}

		int indexAttack = Random.Range(0, possibleAttacks.Count);

		Attack a = possibleAttacks[indexAttack];
		combatant.RUMBLE_FIELD.Clear();


		if (Random.Range(0,10)%2==0)
		{
			what_where[1] = movingDecision(combatant);
		}
		else
		{
			what_where[0] = "attack";

			if (a.self)
			{
				combatant.ACTION_FIELD.Add(combatant.CURR_POS);				
			}
			if (a.field)
			{
				foreach (var position in BattleMaster.instance.INDIPOS)
				{
					if (position.PositionID != combatant.CURR_POS.PositionID)
					{
						combatant.ACTION_FIELD.Add(position);
					}
				}
			}

			if (combatant.ALLY)
			{
				if (a.backRowOpposing)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == 3)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}
				if (a.frontRowOpposing)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == 2)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}
				if (a.backRowOwn)
				{
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 0)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}
				if (a.frontRowOwn)
				{
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 1)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}

				if (a.opposingField)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						combatant.ACTION_FIELD.Add(position);
					}
				}
				if (a.ownField)
				{
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						combatant.ACTION_FIELD.Add(position);
					}
				}

				if (a.singleTarget)
				{
					int index = Random.Range(0, combatant.ACTION_FIELD.Count);
					combatant.RUMBLE_FIELD.Clear();
					combatant.RUMBLE_FIELD.Add(combatant.ACTION_FIELD[index]);
					BattleMaster.instance.attackExecutionTurn(combatant.RUMBLE_FIELD, a);
				}
				if (a.reachingHit)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == 2)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
					int index = Random.Range(0, combatant.ACTION_FIELD.Count);
					combatant.RUMBLE_FIELD.Add(combatant.ACTION_FIELD[index]);
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == combatant.ACTION_FIELD[index].ROW_COORD+1 &&position.COL_COORD == combatant.ACTION_FIELD[index].COL_COORD)
						{
							combatant.RUMBLE_FIELD.Add(position);
							break;
						}
					}
					BattleMaster.instance.attackExecutionTurn(combatant.RUMBLE_FIELD, a);
				}
			}
			else
			{
				if (a.backRowOpposing)
				{
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 0)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}
				if (a.frontRowOpposing)
				{
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 1)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}
				if (a.backRowOwn)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == 3)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}
				if (a.frontRowOwn)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						if (position.ROW_COORD == 2)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
				}

				if (a.opposingField)
				{
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						combatant.ACTION_FIELD.Add(position);
					}
				}
				if (a.ownField)
				{
					foreach (var position in BattleMaster.instance.ENEMY_SIDE)
					{
						combatant.ACTION_FIELD.Add(position);
					}
				}

				if (a.singleTarget)
				{
					int index = Random.Range(0, combatant.ACTION_FIELD.Count);
					combatant.RUMBLE_FIELD.Clear();
					combatant.RUMBLE_FIELD.Add(combatant.ACTION_FIELD[index]);
					BattleMaster.instance.attackExecutionTurn(combatant.RUMBLE_FIELD, a);
				}

				if (a.reachingHit)
				{
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == 1)
						{
							combatant.ACTION_FIELD.Add(position);
						}
					}
					int index = Random.Range(0, combatant.ACTION_FIELD.Count);
					combatant.RUMBLE_FIELD.Add(combatant.ACTION_FIELD[index]);
					foreach (var position in BattleMaster.instance.PLAYER_SIDE)
					{
						if (position.ROW_COORD == combatant.ACTION_FIELD[index].ROW_COORD-1 && position.COL_COORD == combatant.ACTION_FIELD[index].COL_COORD)
						{
							combatant.RUMBLE_FIELD.Add(position);
							break;
						}
					}
					BattleMaster.instance.attackExecutionTurn(combatant.RUMBLE_FIELD, a);
				}
			}


			BattleMaster.instance.attackExecutionTurn(combatant.ACTION_FIELD, a);
		}

		

		return what_where;
	}

	public string movingDecision(Combatant c)
	{
		string keyToNextPosition = "RC_";
		Debug.Log(c.NAME);
		RUMBLE_FIELD.Clear();

		if (c.ALLY)
		{
			foreach (var position in BattleMaster.instance.PLAYER_SIDE)
			{
				if (position.CURRENTLY_OCCUPIED)
				{
					if (!position.FIGURE.IS_PREPARING || position.PositionID != c.CURR_POS.PositionID)
					{
						RUMBLE_FIELD.Add(position);
					}
				}
				else
				{
					RUMBLE_FIELD.Add(position);
				}
			}
		}
		else
		{
			foreach (var position in BattleMaster.instance.ENEMY_SIDE)
			{
				if (position.CURRENTLY_OCCUPIED)
				{
					if (!position.FIGURE.IS_PREPARING)
					{
						RUMBLE_FIELD.Add(position);
					}
				}
				else
				{
					RUMBLE_FIELD.Add(position);
				}
			}
		}
		int index = Random.Range(0, RUMBLE_FIELD.Count);
		keyToNextPosition = RUMBLE_FIELD[index].PositionID;
		RUMBLE_FIELD.Clear();
		return keyToNextPosition;
	}

	public void showOccupant()
	{
		//positionImage = GetComponentInChildren<Image>();
		miniVisualHP.maxValue = HP_MAX;
		miniVisualSP.maxValue = SP_MAX;
		miniVisualMP.maxValue = MP_MAX;
		miniVisualCP.maxValue = CP_MAX;
		//CPSliderMain.maxValue = currentCombatant.CP_MAX;
		miniVisualHP.value = HP;
		miniVisualSP.value = SP;
		miniVisualMP.value = MP;
		miniVisualCP.value = CP;

	}

}
