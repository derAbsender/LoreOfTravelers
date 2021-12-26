using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{


	public PlayerMovement pm;
	public PartyMemberManager pmm;
	public GameObject bomb;
	public GameObject arrow;
	public Staff staff;
	public GameObject chain;
	public GameObject sword;

	public bool animatingStop = false;
	public bool isAttacking = false;
	public bool canMove = true;
	public bool isRunning = false;
	public bool isExhausted = false;


	public Vector2 moveDir;
	public Vector2 directionFaced;

	public Animator animMovement;
	public Animator animWeapon;

	public Inventory inventory;
	public Transform attackPosition;

	public UserInterface ui;

	public static PlayerInputManager instance;

	// Start is called before the first frame update
	void Start()
    {
        if (instance ==null)
        {
			instance = this;
		}
        else
        {
			Destroy(gameObject);
        }
		
		DontDestroyOnLoad(gameObject);

		animMovement.runtimeAnimatorController = pmm.SetAnimatorMovement();
		//----------------------------------------------------------------
		for (int i = 0; i < pmm.partyCFP.Count; i++)
        {
            if (pmm.partyCFP[i]!= null)
            {
				if (pmm.partyCFP[i].heldWeapon == null)
				{
					pmm.partyCFP[i].SetBareHanded();					
				}
			}
		}
		ui = GameObject.FindWithTag("UI").GetComponent<UserInterface>();
		//inventory = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
		inventory.gameObject.SetActive(false);
		pmm.activeCFP.juggernaut.currentArmorValue = pmm.activeCFP.juggernaut.maxArmorValue;
		//----------------------------------------------------------------
		ui.SetMemberIcon(pmm.activeCFP.characterUIIcon);
		ui.SetWeaponIcon();
		ui.ShowClassJobResources();

		ui.SetHealthSlider(pmm.activeCFP.playerStats.health.currValue, pmm.activeCFP.playerStats.health.initValue);
		ui.SetStaminaSlider(pmm.activeCFP.playerStats.stamina.currValue, pmm.activeCFP.playerStats.stamina.initValue);
		ui.SetCharismaSlider(pmm.activeCFP.playerStats.charisma.currValue, pmm.activeCFP.playerStats.charisma.initValue);

		ui.SetArmorSlider(pmm.activeCFP.juggernaut.currentArmorValue, pmm.activeCFP.juggernaut.maxArmorValue);
	}

	

    // Update is called once per frame
    void Update()
    {
		HandleMovementInput();
		HandleActiveCharacter();
		HandleAttack();
		InventoryControll();
		HandleRun();
	}

	void HandleRun()
    {
		pm.HandleSpeed();
		if (Input.GetKeyDown(KeyCode.Space))
        {
			pm.isRunning = true;
		}
        if (Input.GetKeyUp(KeyCode.Space))
        {
			pm.isRunning = false;
        }

        if (pmm.activeCFP.playerStats.stamina.currValue == 0)
        {
			pm.isExhausted = true;
        }
		if (pmm.activeCFP.playerStats.stamina.currValue == pmm.activeCFP.playerStats.stamina.initValue)
		{
			pm.isExhausted = false;
		}

		if (pm.isExhausted)
        {
            if (pm.isRunning)
            {
				pmm.activeCFP.ChangeStamina(0);
			}
            else
            {
				pmm.activeCFP.ChangeStamina(.002f);
			}

            if (!pm.isMoving)
            {
				pmm.activeCFP.ChangeStamina(.01f);
			}
        }
        else
        {
			if (pm.isRunning)
            {
                pmm.activeCFP.ChangeStamina(-.01f);
            }
            else
            {
                pmm.activeCFP.ChangeStamina(.01f);
            }
        }
	}

	void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0) && !inventory.gameObject.activeInHierarchy)
		{
            if (pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Bow)
            {
				animWeapon.SetTrigger("BowLoaded");
			}            
        }
		

        if (Input.GetMouseButtonDown(0) && !inventory.gameObject.activeInHierarchy)
		{
			attackPosition.GetComponent<SpriteRenderer>().sortingOrder = 0;
            //Debug.Log(pmm.activeCFP.heldWeapon.weaponType);

            if (attackPosition.gameObject.GetComponent<CheckFront>().front != null && attackPosition.gameObject.GetComponent<CheckFront>().front.gameObject.GetComponent<PushableObject>() 
				&& (pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Bomb || pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Fist))
            {
                PushableObject po = attackPosition.gameObject.GetComponent<CheckFront>().front.gameObject.GetComponent<PushableObject>();
				po.MoveObject();
            }

            if (pmm.activeCFP.heldWeapon.weaponType==WeaponObject.WeaponType.Bomb && pmm.activeCFP.heldWeapon.amount > 0 )
            {
                if (attackPosition.gameObject.GetComponent<CheckFront>().front != null)// && attackPosition.gameObject.GetComponent<CheckFront>().front.gameObject.GetComponent<Bomb>()
				{

				}
                else
                {
					Instantiate(bomb, new Vector2(attackPosition.position.x, attackPosition.position.y), Quaternion.identity);
				}				
			}
			else if(pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Fist)
            {

            }
			else if (pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Staff && !isAttacking)
            {
				animWeapon.SetTrigger("AttackStaff");
				isAttacking = true;
				staff.InitializeStaffAction(directionFaced, pm.playerRB);				
			}
            else if (pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Bow && !isAttacking && pmm.activeCFP.heldWeapon.amount > 0)
            {
				if (directionFaced.y < 0)
				{
					attackPosition.GetComponent<SpriteRenderer>().sortingOrder = 5;
				}
				animWeapon.SetTrigger("AttackBow");
				ShootArrow();				
            }
			else if(pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Sling && !isAttacking)
            {
				isAttacking = true;
				animatingStop = true;
				canMove = false;
				GameObject slingGO = Instantiate(chain.gameObject, new Vector2(attackPosition.position.x, attackPosition.position.y), Quaternion.identity);
				slingGO.GetComponent<Sling>().InitializeChain(directionFaced,gameObject, attackPosition.gameObject);
            }
			else if (pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Sword && !isAttacking)
            {
				if (directionFaced.y < 0)
				{
					attackPosition.GetComponent<SpriteRenderer>().sortingOrder = 5;
				}
				animWeapon.SetTrigger("AttackSword");
				canMove = false;
				isAttacking = true;
				GameObject swordGO = Instantiate(sword.gameObject, new Vector2(attackPosition.position.x, attackPosition.position.y), Quaternion.identity);
				swordGO.GetComponent<Sword>().InitializeConstantHit(gameObject);
			}
		}
	}

	void ShootArrow()
	{
		arrow.GetComponent<Arrow>().SetDirection(directionFaced);
        if (GetComponent<PlayerMovement>().isMoving)
        {
			StartCoroutine("DelayShootArrow");
        }
        else
        {
			Instantiate(arrow, new Vector2(attackPosition.position.x, attackPosition.position.y), Quaternion.identity);
		}
	}
	IEnumerator DelayShootArrow()
    {
		canMove = false;
		animatingStop = true;
		yield return new WaitForSeconds(.5f);
		Instantiate(arrow, new Vector2(attackPosition.position.x, attackPosition.position.y), Quaternion.identity);
	}

	void HandleActiveCharacter()
	{

		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			animMovement.runtimeAnimatorController = pmm.ChangePartyMemberAnimator(-1);
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			animMovement.runtimeAnimatorController = pmm.ChangePartyMemberAnimator(1);
		}
		inventory.cim.UnsetClassInventory();
		inventory.setStatValuesInventory();
		inventory.cim.SetArmorInventory();

		ui.SetWeaponIcon();
		ui.SetWeaponAmount(pmm.activeCFP.heldWeapon.amount);
		ui.SetWeaponDurability(pmm.activeCFP.heldWeapon.durability, pmm.activeCFP.heldWeapon.durabilityMAX);

		ui.SetHealthSlider(pmm.activeCFP.playerStats.health.currValue, pmm.activeCFP.playerStats.health.initValue);
		ui.SetStaminaSlider(pmm.activeCFP.playerStats.stamina.currValue, pmm.activeCFP.playerStats.stamina.initValue);
		ui.SetCharismaSlider(pmm.activeCFP.playerStats.charisma.currValue, pmm.activeCFP.playerStats.charisma.initValue);
		ui.ShowClassJobResources();
	}

	void HandleMovementInput()
	{
		if (!animatingStop)
		{
			moveDir.x = Input.GetAxisRaw("Horizontal");
			moveDir.y = Input.GetAxisRaw("Vertical");

			pm.HandleMovementInput(moveDir, attackPosition);
			
		
			directionFaced = pm.directionFaced;

			animMovement.SetFloat("moveX", moveDir.x);
			animMovement.SetFloat("moveY", moveDir.y);
			animMovement.SetFloat("lastMoveX", directionFaced.x);
			animMovement.SetFloat("lastMoveY", directionFaced.y);
			animWeapon.SetFloat("facingX", directionFaced.x);
			animWeapon.SetFloat("facingY", directionFaced.y);
		}
		else
		{
			animMovement.SetFloat("moveX", 0);
			animMovement.SetFloat("moveY", 0);
		}
	}

	void InventoryControll()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{

			if (inventory.gameObject.activeInHierarchy)
			{
				inventory.gameObject.SetActive(false);
			}
			else
			{
				inventory.gameObject.SetActive(true);
				inventory.gameObject.GetComponent<Inventory>().InitializeInventory();
			}
		}
	}
}
