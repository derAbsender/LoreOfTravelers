using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public class CharacterFigurePiece : MonoBehaviour
{
    [Header("Graphics")]
    public RuntimeAnimatorController characterAnimator;
    public Sprite characterUIIcon;
    [Header("Equippment")]
    public bool emptyHanded;
    public WeaponObject heldWeapon;
    public WeaponObject bareHanded;
    UserInterface ui;
    
    public enum ClassJob { Shepperd, Mage, Warrior, Juggernaut}

    public PlayerStats playerStats;

    public float weaponResourceModificator = 1f;

    public float staminaModifactor = 1f;

    public ClassJob classJob;

    public JuggernautClassJob juggernaut;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpWeapon(WeaponObject weapon)
    {
        ui = GameObject.FindWithTag("UI").GetComponent<UserInterface>();
        heldWeapon = weapon;
        emptyHanded = false;
        ui.SetWeaponAmount(heldWeapon.amount);
        ui.SetWeaponDurability(heldWeapon.durability, heldWeapon.durabilityMAX);
    }

    public void ChangeAmount(int amount)
    {
        ui = GameObject.FindWithTag("UI").GetComponent<UserInterface>();

        float r = UnityEngine.Random.Range(0f, 1f);

        if (r < weaponResourceModificator && amount<0)
        {
            heldWeapon.amount += amount;
            if (heldWeapon.amount > heldWeapon.amountMAX)
            {
                heldWeapon.amount = heldWeapon.amountMAX;
            }
            else if (heldWeapon.amount < 0)
            {
                heldWeapon.amount = 0;
            }
            if (heldWeapon.amount == 0)
            {
                SetBareHanded();
            }
        }
        else
        {
            heldWeapon.amount += amount;
            if (heldWeapon.amount > heldWeapon.amountMAX)
            {
                heldWeapon.amount = heldWeapon.amountMAX;
            }
            else if (heldWeapon.amount < 0)
            {
                heldWeapon.amount = 0;
            }
            if (heldWeapon.amount == 0)
            {
                SetBareHanded();
            }
        }        

        ui.SetWeaponAmount(heldWeapon.amount);
    }

    public void ChangeDurability(float amount)
    {
        ui = GameObject.FindWithTag("UI").GetComponent<UserInterface>();
        if (amount < 0)
        {
            amount = amount * weaponResourceModificator;
        }
        
        heldWeapon.durability += amount;
        if (heldWeapon.durability > heldWeapon.durabilityMAX)
        {
            heldWeapon.durability = heldWeapon.durabilityMAX;
        }
        else if (heldWeapon.durability < 0)
        {
            heldWeapon.durability = 0;
        }
        if (heldWeapon.durability == 0 )
        {
            SetBareHanded();
        }

        ui.SetWeaponDurability(heldWeapon.durability, heldWeapon.durabilityMAX);
    }

    public void SetBareHanded()
    {        
        emptyHanded = true;
        heldWeapon = bareHanded;
    }

    public void ChangeStamina(float change)
    {
        playerStats.stamina.currValue += change;
        if (playerStats.stamina.currValue < 0)
        {
            playerStats.stamina.currValue = 0;
        }
        if (playerStats.stamina.currValue > playerStats.stamina.initValue)
        {
            playerStats.stamina.currValue = playerStats.stamina.initValue;
        }

        ui = GameObject.FindWithTag("UI").GetComponent<UserInterface>();
        ui.SetStaminaSlider(playerStats.stamina.currValue, playerStats.stamina.initValue);
    }

    public void ChangeArmor(float setValue, float maxValue)
    {
        ui.SetArmorSlider( setValue,  maxValue);
    }
}
