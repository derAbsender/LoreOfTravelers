using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassInventoryManager : MonoBehaviour
{
    GameObject player;
    public GameObject juggernaut;
    public Armor head_armorInventoryObject;
    public GameObject head_armorInventoryIcon;
    public Armor body_armorInventoryObject;
    public GameObject body_armorInventoryIcon;
    public Armor limbs_armorInventoryObject;
    public GameObject limbs_armorInventoryIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnsetClassInventory()
    {
        this.juggernaut.SetActive(false);
    }

    public void SetArmorInventory(Armor part)
    {
        switch (part.armorType)
        {
            case Armor.ArmorType.Head:
                head_armorInventoryObject = part;
                head_armorInventoryIcon.GetComponent<Image>().sprite = part.armorIcon;
                head_armorInventoryIcon.GetComponent<ArmorToken>().armor = part;
                break;
            case Armor.ArmorType.Body:
                body_armorInventoryObject = part;
                body_armorInventoryIcon.GetComponent<Image>().sprite = part.armorIcon;
                body_armorInventoryIcon.GetComponent<ArmorToken>().armor = part;
                break;
            case Armor.ArmorType.Limbs:
                limbs_armorInventoryObject = part;
                limbs_armorInventoryIcon.GetComponent<Image>().sprite = part.armorIcon;
                limbs_armorInventoryIcon.GetComponent<ArmorToken>().armor = part;
                break;
            default:
                break;
        }
    }

    public void UnsetArmorInventory(int part)
    {
        switch (part)
        {
            case 1:
                head_armorInventoryObject = null;
                head_armorInventoryIcon.GetComponent<Image>().sprite = null;
                head_armorInventoryIcon.GetComponent<ArmorToken>().armor = null;
                break;
            case 2:
                body_armorInventoryObject = null;
                body_armorInventoryIcon.GetComponent<Image>().sprite = null;
                body_armorInventoryIcon.GetComponent<ArmorToken>().armor = null;
                break;
            case 3:
                limbs_armorInventoryObject = null;
                limbs_armorInventoryIcon.GetComponent<Image>().sprite = null;
                limbs_armorInventoryIcon.GetComponent<ArmorToken>().armor = null;
                break;
            default:
                break;
        }
    }

    public void SetArmorInventory()
    {
        this.juggernaut.SetActive(false);
        player = GameObject.FindWithTag("Player");

        if (player.GetComponent<PartyMemberManager>().activeCFP.classJob == CharacterFigurePiece.ClassJob.Juggernaut)
        {
            this.juggernaut.SetActive(true);
            JuggernautClassJob juggernaut = player.GetComponent<PartyMemberManager>().activeCFP.juggernaut;
            if (juggernaut.head != null)
            {
                SetArmorInventory(juggernaut.head);
            }
            else
            {
                UnsetArmorInventory(1);
            }
            if (juggernaut.body != null)
            {
                SetArmorInventory(juggernaut.body);
            }
            else
            {
                UnsetArmorInventory(2);
            }
            if (juggernaut.limbs != null)
            {
                SetArmorInventory(juggernaut.limbs);
            }
            else
            {
                UnsetArmorInventory(3);
            }
        }
    }

}
