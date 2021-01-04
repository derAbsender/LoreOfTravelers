using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMaster : MonoBehaviour
{

	public List<Combatant> HELPERLIST;

	[SerializeField]
	private GameObject visualIndicatorContainer;

	public GameObject VISUAL_INDICA_CONTAINER
	{
		get { return visualIndicatorContainer; }
		set { visualIndicatorContainer = value; }
	}


	[Header("Library")]
	[SerializeField]
	private Combatant[] individualFigures;

	public Combatant[] INDIFIG
	{
		get { return individualFigures; }
		set { individualFigures = value; }
	}

	[SerializeField]
	public int fieldCountRow;

	[SerializeField]
	public int fieldCountColumn;

	[SerializeField]
	private BattlePosition[] individualPositions;
	

	public BattlePosition[] INDIPOS
	{
		get { return individualPositions; }
		set { individualPositions = value; }
	}

	//[SerializeField]
	//string[] allBattlePositionID = new string[15];

	[Header("Individual Fight")]
	[SerializeField]
	string[] baseNames;

	[SerializeField]
	private int turnCounterToken;

	public int TURN_COUNTER_TOKEN
	{
		get { return turnCounterToken; }
		set { turnCounterToken = value; }
	}


	public static BattleMaster instance;
	[SerializeField]
	Dictionary<string,Combatant> participants = new Dictionary<string,Combatant>();

	public Dictionary<string, Combatant> FIGURES
	{
		get { return participants; }
		set { participants = value; }
	}

	[SerializeField]
	private List<string> allBattleIDs;

	public List<string> ALL_BATTLE_IDs
	{
		get { return allBattleIDs; }
		set { allBattleIDs = value; }
	}


	private BattlePosition[,] fieldCoordinates;

	public BattlePosition[,] FIELDCOORDINATES
	{
		get { return fieldCoordinates; }
		set { fieldCoordinates = value; }
	}

	public GameObject playerBaseOptions;

	[SerializeField]
	private GameObject movementIndicator;

	public GameObject MOVEMENT_INDICATOR
	{
		get { return movementIndicator; }
		set { movementIndicator = value; }
	}

	[SerializeField]
	private GameObject AttackContainer;

	public GameObject ATTACK_CONTAINER
	{
		get { return AttackContainer; }
		set { AttackContainer = value; }
	}
	[SerializeField]
	private Button[] attackButton;

	public Button[] ATTACK_BUTTON
	{
		get { return attackButton; }
		set { attackButton = value; }
	}
	[SerializeField]
	private Combatant currentCombatant;

	public Combatant CURRENT_COMBATANT
	{
		get { return currentCombatant; }
		set { currentCombatant = value; }
	}

	[SerializeField]
	private Attack[] allAttacks;

	public Attack[] ALL_ATTACKS
	{
		get { return allAttacks; }
		set { allAttacks = value; }
	}

	BattlePosition battlePositionConvert;

	[SerializeField]
	private List<string> removedCombatantIDs;

	public List<string> REM_COMBATANT_IDs
	{
		get { return removedCombatantIDs; }
		set { removedCombatantIDs = value; }
	}
	[SerializeField]
	Elements elementHub;

	[SerializeField]
	private Text nameMainContainer;

	public Text NAME_MAIN_CONT
	{
		get { return nameMainContainer; }
		set { nameMainContainer = value; }
	}
	[SerializeField]
	private Slider HPSliderMain;

	public Slider HP_SLIDER_MAIN
	{
		get { return HPSliderMain; }
		set { HPSliderMain = value; }
	}
	[SerializeField]
	private Slider SPSliderMain;

	public Slider SP_SLIDER_MAIN
	{
		get { return SPSliderMain; }
		set { SPSliderMain = value; }
	}
	[SerializeField]
	private Slider MPSliderMain;

	public Slider MP_SLIDER_MAIN
	{
		get { return MPSliderMain; }
		set { MPSliderMain = value; }
	}
	[SerializeField]
	private Slider CPSliderMain;

	public Slider CP_SLIDER_MAIN
	{
		get { return CPSliderMain; }
		set { CPSliderMain = value; }
	}
	[SerializeField]
	private GameObject partyVisuals;

	public GameObject PARTY_VISUALS
	{
		get { return partyVisuals; }
		set { partyVisuals = value; }
	}

	[SerializeField]
	private GameObject ItemWindow;

	public GameObject ITEM_WINDOW
	{
		get { return ItemWindow; }
		set { ItemWindow = value; }
	}

	[SerializeField]
	private GameObject BackButton;

	public GameObject BACK_BUTTON
	{
		get { return BackButton; }
		set { BackButton = value; }
	}

	float magicDamage = 0;

	[SerializeField]
	private GameObject MagicAdjuster;

	public GameObject MAGIC_ADJUSTER
	{
		get { return MagicAdjuster; }
		set { MagicAdjuster = value; }
	}
	[SerializeField]
	private Slider MagicAdjusterSlider;

	public Slider MAGIC_ADJUSTER_SLIDER
	{
		get { return MagicAdjusterSlider; }
		set { MagicAdjusterSlider = value; }
	}

	[SerializeField]
	private BattlePosition[] playerSide;

	public BattlePosition[] PLAYER_SIDE
	{
		get { return playerSide; }
		set { playerSide = value; }
	}
	[SerializeField]
	private BattlePosition[] enemySide;

	public BattlePosition[] ENEMY_SIDE
	{
		get { return enemySide; }
		set { enemySide = value; }
	}

	[SerializeField]
	private ItemButton[] inventoryButton;

	public ItemButton[] INVENTORY_BUTTON
	{
		get { return inventoryButton; }
		set { inventoryButton = value; }
	}

	[SerializeField]
	private GameObject itemOption;

	public GameObject ITEM_OPTION
	{
		get { return itemOption; }
		set { itemOption = value; }
	}

	[SerializeField]
	private Button itemTargetUseButton;

	public Button ITEM_TARGET_USE_BUTTON
	{
		get { return itemTargetUseButton; }
		set { itemTargetUseButton = value; }
	}

	bool battleOnGoing = true;
	// Start is called before the first frame update
	void Start()
    {

		initializeBattlefield();
		spawning();

		battlefieldSort();

		foreach (var item in individualPositions)
		{
			if (item.IS_NEIGHBORING && item.POS_TYPE != PositionType.illegitimate)
			{
				//Debug.Log(item.GetComponentInChildren<Text>());
				item.GetComponentInChildren<Text>().text = "" + item.ROW_COORD + "," + item.COL_COORD;
			}
			else
			{
				//Debug.Log(item.GetComponentInChildren<Text>());
				item.GetComponentInChildren<Text>().text = "";
			}
		}

		foreach (var item in individualPositions)
		{
			item.GetComponentInChildren<Text>().text = item.ROW_COORD + "," + item.COL_COORD;
		}

		Combatant currentCombatant = participants[allBattleIDs[turnCounterToken]];

		int index = Random.Range(-100, 100);
		if (index < 0)
		{
			index = -1;
			Debug.Log("Demorale");
		}
		else
		{
			index = 1;
			Debug.Log("Morale");
		}

		foreach (var id in allBattleIDs)
		{
			participants[id].CP+= (participants[id].C_ATK + participants[id].C_DEF) / 20 * index;
			
		}

		prepareTurn();
	}

    // Update is called once per frame
    void Update()
    {

	}

	private void initializeBattlefield()
	{
		//fieldCoordinates = new BattlePosition[fieldCountRow, fieldCountColumn];
		instance = this;
		int rowCounter = 0;
		int columnCounter = 0;
		for (int i = 0; i < individualPositions.Length; i++)
		{
			individualPositions[i].setID(rowCounter, columnCounter);

			if (individualPositions[i].ROW_COORD == 1 || individualPositions[i].ROW_COORD == 2)
			{
				individualPositions[i].IS_FRONT = true;
			}
			if (individualPositions[i].ROW_COORD == 1 || individualPositions[i].ROW_COORD == 0)
			{
				individualPositions[i].IS_ALLY = true;
			}

			columnCounter++;
			//Debug.Log(columnCounter);
			if (columnCounter == fieldCountColumn)
			{

				columnCounter = 0;
				rowCounter++;
			}
	
			individualPositions[i].CoordDisplay.text = "" + individualPositions[i].COL_COORD + "," + individualPositions[i].ROW_COORD;
		}
	}

	private void spawning()
	{	
		
		int participantCount = 0;

		foreach (var figure in individualFigures)
		{
			for (int i_names = 0; i_names < baseNames.Length; i_names++)
			{
				if (baseNames[i_names] == figure.NAME)
				{
					if (figure.ALLY)
					{
						participantCount += figure.spawnFriend(figure);
					}
					else
					{
						//Debug.Log("HERE");
						participantCount += figure.spawnEnemy(figure);						
					}
				}				
			}			
		}
	}

	private List<string> battlefieldSort()
	{

		for (int i = 0; i < allBattleIDs.Count; i++)
		{			
			float cvi = participants[allBattleIDs[i]].SPD;
			for (int j = 0; j < allBattleIDs.Count; j++)
			{
				float cvj = participants[allBattleIDs[j]].SPD;
				if (cvj > cvi)
				{
					string temp = participants[allBattleIDs[j]].BattleID;
					allBattleIDs[j] = participants[allBattleIDs[i]].BattleID;
					allBattleIDs[i] = temp;
				}
			}			
		}

		allBattleIDs.Reverse();

		return allBattleIDs;
	}

	public void turnDecision(Combatant currentCombatant)
	{

		Debug.Log(currentCombatant.ACCU);

		foreach (var item in allBattleIDs)
		{
			//Debug.Log("BM figures "+participants[item].CURR_POS.PositionID+","+participants[item].NAME);
		}

		currentCombatant.NEIGHBORS.Clear();
		currentCombatant.MOVEMENT_OPTIONS.Clear();

		if (currentCombatant.IS_MEGALOMANIAC)
		{
			currentCombatant.loadBehaviour(currentCombatant);
		}
		else
		{
			if (currentCombatant.ALLY)
			{
				playerBaseOptions.SetActive(true);
			}
			else
			{
				currentCombatant.loadBehaviour(currentCombatant);
			}
		}
	}

	public void calculateDamage(BattlePosition target, Combatant combatant, Attack attack)
	{
		AttackTarget damageObject = attack.executeAttackPerTarget(combatant, target, attack);

		Debug.Log("---------CALCULATE DAMAGE----------------");
		//Debug.Log(attack.reachingHit);
		float val = Random.Range(0, 100);
		float accu = target.FIGURE.SPD / ((combatant.ACCU + combatant.ACCU_VAL) / 2f) * 12.5f;
		Debug.Log(val);		
		Debug.Log(combatant.NAME + " wants to attack " + target.PositionID + " with " + attack.ATTACK_ID);
		Debug.Log(accu);
		if (attack.self || attack.ownField || attack.backRowOwn || attack.frontRowOwn)
		{
			calculation(target, combatant, attack, damageObject);
		}
		else
		{
			if (val > accu)
			{
				if (damageObject.ACCURACY > Random.Range(0, 100))
				{
					calculation(target, combatant, attack, damageObject);
					if (combatant.ABILITY != null && combatant.ABILITY.ATTACK_SIDE_EFFECT)
					{
						combatant.ABILITY.executeAbilityEffect(target, combatant, attack);
					}
				}
				else
				{
					Debug.Log("MISSED!");
				}
			}
			else
			{
				Debug.Log("MISSED! Outclassed!");
			}
		}
			
	}

	private void calculation(BattlePosition target, Combatant combatant, Attack attack, AttackTarget damageObject)
	{
		float damage = 0;
		float staminaDamage = 0;

		attack.callAttackEffects(combatant, target);
		if (target.CURRENTLY_OCCUPIED)
		{
			if (attack.isMagic)
			{
				damage = combatant.I_ATK / target.FIGURE.I_DEF * (magicDamage / combatant.CURR_ATTACK_FIELD_COUNT);

				if (combatant.MP < 0)
				{
					combatant.MP = 0;
				}
			}
			else
			{
				damage = combatant.P_ATK / target.FIGURE.P_DEF * damageObject.HP_DAMAGE;
			}

			staminaDamage = combatant.E_ATK / target.FIGURE.E_DEF * damageObject.SP_DAMAGE;
			damage = damage * elementHub.CalculateDamage(combatant.ELEMENT_TYPE, attack.ELEMENT_TYPE, target.FIGURE.ELEMENT_TYPE);

			charismaDamage(target, combatant, damageObject, attack);



			if (Random.Range(0, 100) < combatant.ACCU_VAL)
			{
				Debug.Log("--->!!CRITICAL HIT!!<---");
				damage *= 2;
				staminaDamage *= 2;
			}

			if (combatant.ACCU > 100)
			{
				if (Random.Range(0, 100) < combatant.ACCU - 100)
				{
					Debug.Log(")=> EXCELENT CONDITION <=(");
					damage *= 1.5f;
					staminaDamage *= 1.5f;
				}
			}

			Debug.Log(combatant.NAME);
			Debug.Log("with " + attack.ATTACK_ID);
			Debug.Log(damage + " DAMAGE DEALT!");
			Debug.Log(staminaDamage + " EXHAUSTION CAUSED!");

			target.FIGURE.HP -= damage;
			target.FIGURE.SP -= staminaDamage;

			Debug.Log("to " + target.FIGURE.NAME);

			if (target.FIGURE.HP <= 0)
			{
				target.FIGURE.IS_KO = true;
			}
			if (target.FIGURE.HP <= target.FIGURE.HP_MAX * 1/8 *(-1))
			{
				Debug.Log(target.FIGURE.HP_MAX * 1 / 8 * (-1));
				Debug.Log(target.FIGURE.NAME + " is dead.");
				target.FIGURE.deleteCombatant(target.FIGURE);
			}
			if (target.FIGURE.SP <= 0)
			{
				target.FIGURE.SP = 0;
			}
		}
		Debug.Log(combatant.NAME + " deals with " + attack.ATTACK_ID + " " + damage + "HP damage to " + target.FIGURE.NAME);
		Debug.Log("and " + staminaDamage + "SP damage to " + target.FIGURE.NAME);
	}

	private void charismaDamage(BattlePosition target, Combatant combatant, AttackTarget attackTarget, Attack attack)
	{
		float charismaDamage = 0;
		int index = 0;
		charismaDamage = combatant.C_ATK / target.FIGURE.C_DEF * attackTarget.CP_DAMAGE;
		float charismaCost = combatant.C_ATK / combatant.C_DEF * attack.CP_COST;
	
		Debug.Log("FOREIGN TARGET");
		if (target.FIGURE.CP < target.FIGURE.CP_MAX / 2)
		{
			target.FIGURE.CP -= charismaDamage;
			index = -1;
		}
		if (target.FIGURE.CP > target.FIGURE.CP_MAX / 2)
		{
			target.FIGURE.CP += charismaDamage;
			index = 1;
		}
	
		Debug.Log("SELF TARGET");
		if (combatant.CP < combatant.CP_MAX / 2)
		{
			combatant.CP += charismaDamage;
			index = 1;
		}
		if (combatant.CP > combatant.CP_MAX / 2)
		{
			combatant.CP -= charismaDamage;
			index = -1;
		}
		

		Debug.Log(target.FIGURE.NAME + " lost " + index + " " + charismaDamage + " from " + combatant.NAME);

		if (target.FIGURE.CP > target.FIGURE.CP_MAX)
		{
			target.FIGURE.CP = target.FIGURE.CP_MAX;
			target.FIGURE.IS_MEGALOMANIAC = true;
		}
		if (target.FIGURE.CP < 0)
		{
			if (participants[allBattleIDs[turnCounterToken]].IS_DEMORALIZED)
			{
				target.FIGURE.P_ATK = target.FIGURE.P_ATK_MIN;
				target.FIGURE.P_DEF = target.FIGURE.P_DEF_MIN;
				target.FIGURE.I_ATK = target.FIGURE.I_ATK_MIN;
				target.FIGURE.I_DEF = target.FIGURE.I_DEF_MIN;
				target.FIGURE.C_ATK = target.FIGURE.C_ATK_MIN;
				target.FIGURE.C_DEF = target.FIGURE.C_DEF_MIN;
				target.FIGURE.ACCU_VAL = target.FIGURE.ACCU_MIN_VAL;
				target.FIGURE.SPD = target.FIGURE.SPD_MIN;
				//participants[allBattleIDs[turnCounterToken]].IS_DEMORALIZED = false;
			}
			target.FIGURE.IS_DEMORALIZED = true;
		}

		
		float upperLimit = combatant.CP_MAX / 2 + combatant.CP_MAX * 5 / 100;
		float lowerLimit = combatant.CP_MAX / 2 - combatant.CP_MAX * 5 / 100;
		Debug.Log("U_L_:" + upperLimit);
		Debug.Log("L_L_:" + lowerLimit);
		if (combatant.CP < upperLimit && combatant.CP > lowerLimit)
		{
			if (combatant.IS_DEMORALIZED)
			{
				combatant.P_ATK = combatant.P_ATK_MAX / 2;
				combatant.P_DEF = combatant.P_DEF_MAX / 2;
				combatant.I_ATK = combatant.I_ATK_MAX / 2;
				combatant.I_DEF = combatant.I_DEF_MAX / 2;
				combatant.C_ATK = combatant.C_ATK_MAX / 2;
				combatant.C_DEF = combatant.C_DEF_MAX / 2;
				combatant.E_ATK = combatant.E_ATK_MAX / 2;
				combatant.E_DEF = combatant.E_DEF_MAX / 2;
				combatant.ACCU_VAL = combatant.ACCU_MAX_VAL / 2;
				combatant.SPD = combatant.SPD_MAX / 2;
			}
			combatant.IS_DEMORALIZED = false;
			combatant.IS_MEGALOMANIAC = false;
		}
	}

	public void endTurn()
	{
		float upperLimit = participants[allBattleIDs[turnCounterToken]].CP_MAX / 2 + participants[allBattleIDs[turnCounterToken]].CP_MAX * 5 / 100;
		float lowerLimit = participants[allBattleIDs[turnCounterToken]].CP_MAX / 2 - participants[allBattleIDs[turnCounterToken]].CP_MAX * 5 / 100;
		Debug.Log("=> END TURN =============================");

		dealWithAilment(participants[allBattleIDs[turnCounterToken]]);

		BackButton.SetActive(false);

		if (MagicAdjuster.activeInHierarchy)
		{
			MagicAdjuster.SetActive(false);
		}

		participants[allBattleIDs[turnCounterToken]].CURR_ATTACK_FIELD_COUNT = 0;

		if (participants[allBattleIDs[turnCounterToken]].SP < 0)
		{
			float selfDamage = participants[allBattleIDs[turnCounterToken]].SP * -1;
			selfDamage = participants[allBattleIDs[turnCounterToken]].C_ATK / participants[allBattleIDs[turnCounterToken]].C_DEF * selfDamage;
			participants[allBattleIDs[turnCounterToken]].HP -= selfDamage;
			participants[allBattleIDs[turnCounterToken]].SP = 0;
			//participants[allBattleIDs[turnCounterToken]].SP_REGEN_FACTOR /= 2;
			Debug.Log(participants[allBattleIDs[turnCounterToken]].NAME + " hurt themself in their exhaustion! " + selfDamage);
		}
		//if (participants[allBattleIDs[turnCounterToken]].SP > participants[allBattleIDs[turnCounterToken]].SP_MAX)
		//{
		//	participants[allBattleIDs[turnCounterToken]].SP = participants[allBattleIDs[turnCounterToken]].SP_MAX;
		//}
		//if (participants[allBattleIDs[turnCounterToken]].HP > participants[allBattleIDs[turnCounterToken]].HP_MAX)
		//{
		//	participants[allBattleIDs[turnCounterToken]].HP = participants[allBattleIDs[turnCounterToken]].HP_MAX;
		//}
		controlMaxandMin(participants[allBattleIDs[turnCounterToken]]);


		if (participants[allBattleIDs[turnCounterToken]].CP < upperLimit && participants[allBattleIDs[turnCounterToken]].CP > lowerLimit)
		{
			participants[allBattleIDs[turnCounterToken]].IS_MEGALOMANIAC = false;
		}
		if (participants[allBattleIDs[turnCounterToken]].IS_DEMORALIZED)
		{
			participants[allBattleIDs[turnCounterToken]].P_ATK = participants[allBattleIDs[turnCounterToken]].P_ATK_MIN;
			participants[allBattleIDs[turnCounterToken]].P_DEF = participants[allBattleIDs[turnCounterToken]].P_DEF_MIN;
			participants[allBattleIDs[turnCounterToken]].I_ATK = participants[allBattleIDs[turnCounterToken]].I_ATK_MIN;
			participants[allBattleIDs[turnCounterToken]].I_DEF = participants[allBattleIDs[turnCounterToken]].I_DEF_MIN;
			participants[allBattleIDs[turnCounterToken]].C_ATK = participants[allBattleIDs[turnCounterToken]].C_ATK_MIN;
			participants[allBattleIDs[turnCounterToken]].C_DEF = participants[allBattleIDs[turnCounterToken]].C_DEF_MIN;
			participants[allBattleIDs[turnCounterToken]].ACCU_VAL = participants[allBattleIDs[turnCounterToken]].ACCU_MIN_VAL;
			participants[allBattleIDs[turnCounterToken]].SPD = participants[allBattleIDs[turnCounterToken]].SPD_MIN;
			//participants[allBattleIDs[turnCounterToken]].IS_DEMORALIZED = false;
		}

		//Debug.Log("COMBATANT HP:" + combatant.HP);
		//if (participants[allBattleIDs[turnCounterToken]].HP <= 0)
		//{
		//	participants[allBattleIDs[turnCounterToken]].deleteCombatant(participants[allBattleIDs[turnCounterToken]]);
		//}

		foreach (var position in individualPositions)
		{
			if (position.GetComponentInChildren<MovementIndicator>())
			{
				Destroy(position.GetComponentInChildren<MovementIndicator>().gameObject);
			}
			if (position.GetComponentInChildren<UseOnTargetButton>())
			{
				Destroy(position.GetComponentInChildren<UseOnTargetButton>().gameObject);
			}
		}
		foreach (var position in individualPositions)
		{
			if (position.GetComponentInChildren<AttackIndicator>())
			{
				Destroy(position.GetComponentInChildren<AttackIndicator>().gameObject);
			}
		}

		turnCounterToken++;

		playerBaseOptions.SetActive(false);

		if (turnCounterToken >= ALL_BATTLE_IDs.Count)
		{
			turnCounterToken = 0;
			//Debug.Log(removedCombatantIDs.Count);
			foreach (var item in removedCombatantIDs)
			{
				FIGURES.Remove(item);
				ALL_BATTLE_IDs.Remove(item);
			}
			battlefieldSort();
		}

		foreach (var attack in attackButton)
		{
			attack.gameObject.SetActive(false);
		}

		if (AttackContainer.activeInHierarchy)
		{
			AttackContainer.SetActive(false);
		}
		if (ItemWindow.activeInHierarchy)
		{
			ItemWindow.SetActive(false);
		}

		foreach (var figure in ALL_BATTLE_IDs)
		{
			if (participants[figure].GLARE_OBJECT.activeInHierarchy)
			{
				participants[figure].GLARE_OBJECT.SetActive(false);
			}
		}

		prepareTurn();
	}

	private void prepareTurn()
	{

		Debug.Log("=TURN PREPARATION=====================>");

		controlBattleEnd();

		participants[allBattleIDs[turnCounterToken]].SP_REGEN_FACTOR = (participants[allBattleIDs[turnCounterToken]].E_ATK + participants[allBattleIDs[turnCounterToken]].E_DEF + participants[allBattleIDs[turnCounterToken]].C_ATK + participants[allBattleIDs[turnCounterToken]].C_DEF) / 4 / 10;
		Combatant currentCombatant = participants[allBattleIDs[turnCounterToken]];
		Debug.Log("=REGEN FACTOR====>"+ currentCombatant.SP_REGEN_FACTOR);


		nameMainContainer.text = currentCombatant.NAME;
		HPSliderMain.maxValue = currentCombatant.HP_MAX;
		SPSliderMain.maxValue = currentCombatant.SP_MAX;
		MPSliderMain.maxValue = currentCombatant.MP_MAX;
		CPSliderMain.maxValue = currentCombatant.CP_MAX;
		HPSliderMain.value = currentCombatant.HP;
		SPSliderMain.value = currentCombatant.SP;
		MPSliderMain.value = currentCombatant.MP;
		CPSliderMain.value = currentCombatant.CP;

		float upperLimit = currentCombatant.CP_MAX / 2 + currentCombatant.CP_MAX * 5 / 100;
		float lowerLimit = currentCombatant.CP_MAX / 2 - currentCombatant.CP_MAX * 5 / 100;
		Debug.Log("UL_" + upperLimit);
		Debug.Log("LL_" + lowerLimit);


		foreach (var item in allBattleIDs)
		{
			participants[item].showOccupant();
			if (!participants[item].ALLY && participants[item].IS_PREPARING)
			{
				Debug.Log(participants[item].ATTACKED_POSITIONS.Count + ", TARGET COUNT");
				
				foreach (var target in participants[item].ATTACKED_POSITIONS)
				{
					Debug.Log("TARGET," + target);
					if (target == currentCombatant.CURR_POS.PositionID)
					{
						participants[item].GLARE_OBJECT.SetActive(true);

						StartCoroutine(rotateGlare(item));						
						
						break;
					}
				}				
			}
		}
		//if (currentCombatant.SP == currentCombatant.SP_MAX)
		//{
		//	currentCombatant.SP_REGEN_FACTOR *= 2;
		//}

		if (currentCombatant.HP > 0)
		{
			Debug.Log("It is " + currentCombatant.NAME + "(" + currentCombatant.BattleID + ")'s turn. Currently at " + currentCombatant.CURR_POS.ROW_COORD + "," + currentCombatant.CURR_POS.COL_COORD + ". " + participants.Count + " participant counts. TURN_TOKEN:" + turnCounterToken);

			int index = Random.Range(-100, 100);
			if (index < 0)
			{
				index = -1;
			}
			else
			{
				index = 1;
			}
			currentCombatant.CP += (currentCombatant.C_ATK + currentCombatant.C_DEF)/20 * index;

			Debug.Log("In their moment for themselves: " + (currentCombatant.C_ATK + currentCombatant.C_DEF) / 20 * index + " Charisma");

			if (participants[allBattleIDs[turnCounterToken]].IS_DEMORALIZED || currentCombatant.CP > currentCombatant.CP_MAX)
			{
				participants[allBattleIDs[turnCounterToken]].P_ATK = participants[allBattleIDs[turnCounterToken]].P_ATK_MIN;
				participants[allBattleIDs[turnCounterToken]].P_DEF = participants[allBattleIDs[turnCounterToken]].P_DEF_MIN;
				participants[allBattleIDs[turnCounterToken]].I_ATK = participants[allBattleIDs[turnCounterToken]].I_ATK_MIN;
				participants[allBattleIDs[turnCounterToken]].I_DEF = participants[allBattleIDs[turnCounterToken]].I_DEF_MIN;
				participants[allBattleIDs[turnCounterToken]].C_ATK = participants[allBattleIDs[turnCounterToken]].C_ATK_MIN;
				participants[allBattleIDs[turnCounterToken]].C_DEF = participants[allBattleIDs[turnCounterToken]].C_DEF_MIN;
				participants[allBattleIDs[turnCounterToken]].ACCU_VAL = participants[allBattleIDs[turnCounterToken]].ACCU_MIN_VAL;
				participants[allBattleIDs[turnCounterToken]].SPD = participants[allBattleIDs[turnCounterToken]].SPD_MIN;
				//participants[allBattleIDs[turnCounterToken]].IS_DEMORALIZED = false;
			}
			if (currentCombatant.CP > currentCombatant.CP_MAX)
			{
				currentCombatant.CP = currentCombatant.CP_MAX;
				currentCombatant.IS_MEGALOMANIAC = true;
			}

			if (currentCombatant.CP < upperLimit && currentCombatant.CP > lowerLimit)
			{
				float valSP = (((currentCombatant.E_ATK * currentCombatant.E_DEF) / 2) / currentCombatant.SP_MAX / 2) * currentCombatant.SP_REGEN_FACTOR;
				float valHP = (((currentCombatant.P_ATK * currentCombatant.P_DEF) / 2) / currentCombatant.HP_MAX / 2) * currentCombatant.SP_REGEN_FACTOR;
				float valMP = (((currentCombatant.I_ATK * currentCombatant.I_DEF) / 2) / currentCombatant.MP_MAX / 2) * currentCombatant.SP_REGEN_FACTOR;
				Debug.Log("HP REGEN = " + valHP);
				Debug.Log("MP REGEN = " + valMP);
				Debug.Log("SP REGEN = " + valSP);
				currentCombatant.HP += valHP;
				currentCombatant.MP += valMP;
				currentCombatant.SP += valSP;
				if (currentCombatant.HP > currentCombatant.HP_MAX)
				{
					currentCombatant.HP = currentCombatant.HP_MAX;
				}
				if (currentCombatant.MP > currentCombatant.MP_MAX)
				{
					currentCombatant.MP = currentCombatant.MP_MAX;
				}
				if (currentCombatant.SP > currentCombatant.SP_MAX)
				{
					currentCombatant.SP = currentCombatant.SP_MAX;
				}
				currentCombatant.IS_MEGALOMANIAC = false;
				if (currentCombatant.IS_DEMORALIZED)
				{
					currentCombatant.P_ATK = currentCombatant.P_ATK_MAX/2;
					currentCombatant.P_DEF = currentCombatant.P_DEF_MAX/2;
					currentCombatant.I_ATK = currentCombatant.I_ATK_MAX/2;
					currentCombatant.I_DEF = currentCombatant.I_DEF_MAX/2;
					currentCombatant.C_ATK = currentCombatant.C_ATK_MAX/2;
					currentCombatant.C_DEF = currentCombatant.C_DEF_MAX/2;
					currentCombatant.ACCU_VAL = currentCombatant.ACCU_MAX_VAL/2;
					currentCombatant.SPD = currentCombatant.SPD_MAX/2;
				}
				currentCombatant.IS_DEMORALIZED = false;
			}

			if (currentCombatant.SP < currentCombatant.SP_MAX)
			{
				Debug.Log("CURRENT SP =" + currentCombatant.SP);

				float val = (((currentCombatant.E_ATK * currentCombatant.E_DEF) / 2) / currentCombatant.SP_MAX / 2 ) * currentCombatant.SP_REGEN_FACTOR;

				Debug.Log("SP REGEN = " + val);

				//combatant.SP = combatant.SP + ((combatant.C_ATK*combatant.C_DEF)/2)/combatant.SP_MAX/10;
				currentCombatant.SP += val;
				if (currentCombatant.SP > currentCombatant.SP_MAX)
				{
					currentCombatant.SP = currentCombatant.SP_MAX;
				}
			}
			//Debug.Log("Vitalized Turn SP =" + currentCombatant.SP);

			if (currentCombatant.IS_PREPARING)
			{
				Debug.Log(currentCombatant.NAME + ", attacked with prepared Attack: " + currentCombatant.CURRENT_ATTACK.ATTACK_ID);
				currentCombatant.IS_PREPARING = false;
				foreach (var positions in currentCombatant.ATTACKED_POSITIONS)
				{
					DEBUG_PRINT(positions);
					BattlePosition bp = convertToBattlePosition(positions);
					if (bp.CURRENTLY_OCCUPIED)
					{
						calculateDamage(bp, currentCombatant, currentCombatant.CURRENT_ATTACK);
					}
				}
				currentCombatant.ATTACKED_POSITIONS.Clear();
				endTurn();
			}
			else
			{
				if (currentCombatant.IS_EXHAUSTED)
				{
					Debug.Log(currentCombatant.NAME + " is exhausted from using " + currentCombatant.CURRENT_ATTACK.ATTACK_ID);
					currentCombatant.IS_EXHAUSTED = false;
					endTurn();
				}
				else
				{
					turnDecision(currentCombatant);
				}
			}
		}
		else
		{			
			endTurn();
		}
	}


	public void moveButtonPress()
	{
		Combatant currentCombatant = participants[allBattleIDs[turnCounterToken]];

		BackButton.SetActive(true);

		float val = currentCombatant.SP_MAX / ((currentCombatant.C_ATK * currentCombatant.C_DEF) / 2) * 15;

		foreach (var position in playerSide)
		{
			if (position.PositionID != currentCombatant.CURR_POS.PositionID)
			{
				if (position.CURRENTLY_OCCUPIED && position.FIGURE.IS_PREPARING)
				{

				}
				else
				{
					movementIndicator.GetComponent<MovementIndicator>().ASSIGNED_POSITION = position;
					movementIndicator.GetComponent<MovementIndicator>().CURRENT_COMBATANT = currentCombatant;
					currentCombatant.MOVEMENT_OPTIONS.Add(Instantiate(movementIndicator, position.transform));
				}
			}
		}		
	}

	private void dealWithAilment(Combatant currentCombatant)
	{
		if (currentCombatant.SWARMED)
		{
			dealWithSwarm(currentCombatant);
		}
	}



	private Combatant dealWithSwarm(Combatant combatant)
	{
		float swarmDMG = combatant.HP_MAX * 1 / 10;
		combatant.HP -= swarmDMG;
		Debug.Log("Aggressive Insects deal !!!!!" + swarmDMG + "!!!!!! to " + combatant.NAME + "__" + combatant.CURR_POS.PositionID);
		if (Random.Range(0,101) < combatant.C_DEF/5)
		{
			combatant.SWARMED = false;
			Debug.Log(combatant.NAME + "==> Gets RID OF THE INSECTS");
			Debug.Log(combatant.SWARMED);
		}
		else
		{
			Debug.Log(combatant.NAME + "The insects keep gnawing");
		}

		return combatant;
	}

	public void itemButtonPress()
	{
		currentCombatant = participants[allBattleIDs[turnCounterToken]];

		BackButton.SetActive(true);

		if (playerBaseOptions.activeInHierarchy)
		{
			playerBaseOptions.SetActive(false);
		}

		foreach (var position in individualPositions)
		{
			if (position.GetComponentInChildren<MovementIndicator>())
			{
				Destroy(position.GetComponentInChildren<MovementIndicator>().gameObject);
			}
		}

		for (int i = 0; i < currentCombatant.BATTLE_INVENTORY.Length; i++)
		{
			Debug.Log(inventoryButton[i]);
			inventoryButton[i].gameObject.SetActive(true);
			inventoryButton[i].ASSIGNED_ITEM = currentCombatant.BATTLE_INVENTORY[i];
			inventoryButton[i].ITEM_IMAGE.sprite = currentCombatant.BATTLE_INVENTORY[i].ITEM_IMAGE.sprite;
			inventoryButton[i].GetComponentInChildren<Text>().text = currentCombatant.BATTLE_INVENTORY[i].ITEM_NAME;
		}
		ItemWindow.SetActive(true);
	}


	public void attackButtonPress()
	{
		currentCombatant = participants[allBattleIDs[turnCounterToken]];
		if (playerBaseOptions.activeInHierarchy)
		{
			playerBaseOptions.SetActive(false);
		}

		BackButton.SetActive(true);

		foreach (var position in individualPositions)
		{
			if (position.GetComponentInChildren<MovementIndicator>())
			{
				Destroy(position.GetComponentInChildren<MovementIndicator>().gameObject);
			}
		}

		//Debug.Log(GetComponentInChildren<AttackIndicator>().CURRENT_ATTACK.ATTACK_ID);

		AttackContainer.SetActive(true);

		for (int i = 0; i < currentCombatant.KNOWN_ATTACKS.Length; i++)
		{
			if (currentCombatant.CURR_POS.ROW_COORD == 0 && currentCombatant.KNOWN_ATTACKS[i].usableBack)
			{
				attackButton[i].gameObject.SetActive(true);

				attackButton[i].GetComponentInChildren<Text>().text = currentCombatant.KNOWN_ATTACKS[i].ATTACK_ID;
			}
			if (currentCombatant.CURR_POS.ROW_COORD == 1 && currentCombatant.KNOWN_ATTACKS[i].usableFront)
			{
				attackButton[i].gameObject.SetActive(true);

				attackButton[i].GetComponentInChildren<Text>().text = currentCombatant.KNOWN_ATTACKS[i].ATTACK_ID;
			}

			
		}
	}

	public void backButtonPress()
	{
		if (AttackContainer.activeInHierarchy)
		{
			AttackContainer.SetActive(false);
		}
		if (ItemWindow.activeInHierarchy)
		{
			ItemWindow.SetActive(false);
		}
		foreach (var position in individualPositions)
		{
			if (position.GetComponentInChildren<AttackIndicator>())
			{
				Destroy(position.GetComponentInChildren<AttackIndicator>().gameObject);
			}
			if (position.GetComponentInChildren<MovementIndicator>())
			{
				Destroy(position.GetComponentInChildren<MovementIndicator>().gameObject);
			}
		}

		if (itemOption.activeInHierarchy)
		{
			itemOption.SetActive(false);
		}

		if (!playerBaseOptions.activeInHierarchy)
		{
			playerBaseOptions.SetActive(true);
		}
		BackButton.SetActive(false);
	}


	public void attackExecutionTurn(List<BattlePosition> attackField, Attack currentAttack)
	{
		float costs = (FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].E_ATK / FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].E_DEF) * currentAttack.SP_COST;
		FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].SP -= costs;
		Debug.Log(currentAttack.ATTACK_ID);
		foreach (var item in attackField)
		{
			Debug.Log("FIELDCOUNT " + item.PositionID);
		}
	
		
		if (currentAttack.isMagic)
		{
			FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].MP -= magicDamage;
		}

		FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].CURR_ATTACK_FIELD_COUNT = attackField.Count;

		if (currentAttack.EXHAUSTING)
		{
			FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].IS_EXHAUSTED = true;
		}
		FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].CURRENT_ATTACK = currentAttack;

		if (currentAttack.FAST_STRIKE)
		{
			foreach (var position in attackField)
			{
				if (position.CURRENTLY_OCCUPIED)
				{
					calculateDamage(position, FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]], currentAttack);
				}				
			}			
		}
		else
		{
			foreach (var position in attackField)
			{
				FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].ATTACKED_POSITIONS.Add(position.PositionID);
			}		

			instance.FIGURES[ALL_BATTLE_IDs[TURN_COUNTER_TOKEN]].IS_PREPARING = true;				
		}
	}

	public void gaugingMagicDamage()
	{
		this.magicDamage = MagicAdjusterSlider.value;
	}




	private BattlePosition convertToBattlePosition(string coord)
	{

		foreach (var position in BattleMaster.instance.INDIPOS)
		{
			if (coord == "RC_" + position.ROW_COORD + ",CC_" + position.COL_COORD)
			{
				battlePositionConvert = position;
				break;
			}
		}

		return battlePositionConvert;
	}

	private IEnumerator rotateGlare(string item)
	{
		bool rotating = true;
		while (rotating && battleOnGoing)
		{
			participants[item].GLARE[0].transform.Rotate(1, 0, 1 );
			participants[item].GLARE[1].transform.Rotate(-1, -0, -1 );
			yield return null;
		}
	}

	public void pressItemUse(int i)
	{
		BackButton.SetActive(true);
		foreach (var id in ALL_BATTLE_IDs)
		{
			itemTargetUseButton.GetComponent<UseOnTargetButton>().TARGET = participants[id];
			itemTargetUseButton.GetComponent<UseOnTargetButton>().ASSIGNED_ITEM = inventoryButton[i].GetComponent<ItemButton>().ASSIGNED_ITEM;
			Instantiate(itemTargetUseButton, participants[id].gameObject.transform.parent);
		}
	}

	public void pressFleeButton()
	{
		int enemyCount = 0;
		int backRowCount = 0;
		foreach (var position in ENEMY_SIDE)
		{
			if (position.CURRENTLY_OCCUPIED)
			{
				enemyCount++;
				if (position.ROW_COORD == 3)
				{
					backRowCount++;
				}
			}
		}
		if (enemyCount == backRowCount)
		{
			//END FIGHT
		}
		else if (backRowCount == 0)
		{
			if (Random.Range(0,100) > 90)
			{
				//END FIGHT
			}
		}
		else if (Random.Range(0,100) > (enemyCount-backRowCount)/enemyCount)
		{
			//END FIGHT
		}
		
	}


	public void DEBUG_PRINT (string print)
	{
		Debug.Log(print);
	}

	public void controlMaxandMin(Combatant combatant)
	{
		if (combatant.SP > combatant.SP_MAX)
		{
			combatant.SP = combatant.SP_MAX;
		}
		if (combatant.HP > combatant.HP_MAX)
		{
			combatant.HP = combatant.HP_MAX;
		}
		if (combatant.MP > combatant.MP_MAX)
		{
			combatant.MP = combatant.MP_MAX;
		}
		if (combatant.CP > combatant.CP_MAX)
		{
			combatant.CP = combatant.CP_MAX;
		}

		if (combatant.SP < 0)
		{
			combatant.SP = 0;
		}
		//if (combatant.HP < 0)
		//{
		//	combatant.HP = 0;
		//}
		if (combatant.MP < 0)
		{
			combatant.MP = 0;
		}
		if (combatant.CP < 0)
		{
			combatant.CP = 0;
		}

		if (combatant.P_ATK > combatant.P_ATK_MAX)
		{
			combatant.P_ATK = combatant.P_ATK_MAX;
		}
		if (combatant.I_ATK > combatant.I_ATK_MAX)
		{
			combatant.I_ATK = combatant.I_ATK_MAX;
		}
		if (combatant.E_ATK > combatant.E_ATK_MAX)
		{
			combatant.E_ATK = combatant.E_ATK_MAX;
		}
		if (combatant.C_ATK > combatant.C_ATK_MAX)
		{
			combatant.C_ATK = combatant.C_ATK_MAX;
		}

		if (combatant.P_ATK < combatant.P_ATK_MIN)
		{
			combatant.P_ATK = combatant.P_ATK_MIN;
		}
		if (combatant.I_ATK < combatant.I_ATK_MIN)
		{
			combatant.I_ATK = combatant.I_ATK_MIN;
		}
		if (combatant.E_ATK < combatant.E_ATK_MIN)
		{
			combatant.E_ATK = combatant.E_ATK_MIN;
		}
		if (combatant.C_ATK < combatant.C_ATK_MIN)
		{
			combatant.C_ATK = combatant.C_ATK_MIN;
		}



		if (combatant.P_DEF > combatant.P_DEF_MAX)
		{
			combatant.P_DEF = combatant.P_DEF_MAX;
		}
		if (combatant.I_DEF > combatant.I_DEF_MAX)
		{
			combatant.I_DEF = combatant.I_DEF_MAX;
		}
		if (combatant.E_DEF > combatant.E_DEF_MAX)
		{
			combatant.E_DEF = combatant.E_DEF_MAX;
		}
		if (combatant.C_DEF > combatant.C_DEF_MAX)
		{
			combatant.C_DEF = combatant.C_DEF_MAX;
		}

		if (combatant.P_DEF < combatant.P_DEF_MIN)
		{
			combatant.P_DEF = combatant.P_DEF_MIN;
		}
		if (combatant.I_DEF < combatant.I_DEF_MIN)
		{
			combatant.I_DEF = combatant.I_DEF_MIN;
		}
		if (combatant.E_DEF < combatant.E_DEF_MIN)
		{
			combatant.E_DEF = combatant.E_DEF_MIN;
		}
		if (combatant.C_DEF < combatant.C_DEF_MIN)
		{
			combatant.C_DEF = combatant.C_DEF_MIN;
		}
	}

	private void controlBattleEnd()
	{
		bool playerWin = true;
		bool enemyWin = true;
		foreach (var position in PLAYER_SIDE)
		{
			if (position.CURRENTLY_OCCUPIED && !position.FIGURE.IS_KO)
			{
				enemyWin = false;
			}
		}
		foreach (var position in ENEMY_SIDE)
		{
			if (position.CURRENTLY_OCCUPIED && !position.FIGURE.IS_KO)
			{
				playerWin = false;
			}
		}
		if (playerWin || enemyWin)
		{
			battleOnGoing = false;
		}


	}
}
