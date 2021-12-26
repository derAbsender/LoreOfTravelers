using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Image[] members;
    public GameObject amountHolder;
    public Text amount;
    public GameObject durabilityHolder;
    public Slider durability;
    public GameObject weaponIconHolder;
    public Image weaponIcon;
    public Slider healthSlider;
    public Slider staminaSlider;
    public Slider charismaSlider;

    public Slider armorSlider;
    public Slider wrathSlider;
    public Slider magicSlider;

    public GameObject herd;
    public GameObject[] herdMembers;


    public PartyMemberManager pmm;

    public static UserInterface instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SetMemberIcon(Sprite cfpIcon)
    {
        for (int i = 0; i < members.Length; i++)
        {
            if (members[i].sprite == null)
            {
                members[i].sprite = cfpIcon;
                break;
            }
        }
    }
    public void SetWeaponIcon()
    {
        weaponIcon.sprite = pmm.activeCFP.heldWeapon.weaponIcon;
        ShowWeaponState();
    }

    void ShowWeaponState()
    {
        amountHolder.SetActive(false);
        durabilityHolder.SetActive(false);
        switch (pmm.activeCFP.heldWeapon.weaponType)
        {
            case WeaponObject.WeaponType.Sword:
                durabilityHolder.SetActive(true);
                break;
            case WeaponObject.WeaponType.Bomb:
                amountHolder.SetActive(true);
                break;
            case WeaponObject.WeaponType.Bow:
                amountHolder.SetActive(true);
                break;
            case WeaponObject.WeaponType.Sling:
                durabilityHolder.SetActive(true);
                break;
            case WeaponObject.WeaponType.Fist:
                break;
            case WeaponObject.WeaponType.Staff:
                durabilityHolder.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void ShowClassJobResources()
    {
        herd.SetActive(false);
        magicSlider.gameObject.SetActive(false);
        wrathSlider.gameObject.SetActive(false);
        armorSlider.gameObject.SetActive(false);

        switch (pmm.activeCFP.classJob)
        {
            case CharacterFigurePiece.ClassJob.Shepperd:
                herd.SetActive(true);
                break;
            case CharacterFigurePiece.ClassJob.Mage:
                magicSlider.gameObject.SetActive(true);
                break;
            case CharacterFigurePiece.ClassJob.Warrior:
                wrathSlider.gameObject.SetActive(true);
                break;
            case CharacterFigurePiece.ClassJob.Juggernaut:
                armorSlider.gameObject.SetActive(true);                
                break;
            default:
                break;
        }
    }

    public void SetWeaponAmount(int amount)
    {
        this.amount.text = amount.ToString();
    }

    public void SetWeaponDurability(float durability, float durabilityMAX)
    {
        this.durability.maxValue = durabilityMAX;
        this.durability.value = durability;
    }

    public void SetHealthSlider(float setValue, float maxValue)
    {
        this.healthSlider.maxValue = maxValue;
        this.healthSlider.value = setValue;
    }
    public void SetStaminaSlider(float setValue, float maxValue)
    {        
        this.staminaSlider.maxValue = maxValue;
        this.staminaSlider.value = setValue;
    }
    public void SetCharismaSlider(float setValue, float maxValue)
    {
        this.charismaSlider.maxValue = maxValue;
        this.charismaSlider.value = setValue;
    }
    public void SetArmorSlider(float setValue, float maxValue)
    {
        this.armorSlider.maxValue = maxValue;
        this.armorSlider.value = setValue;
    }
}
