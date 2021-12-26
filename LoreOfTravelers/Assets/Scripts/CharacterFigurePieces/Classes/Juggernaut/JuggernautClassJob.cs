using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernautClassJob : MonoBehaviour
{
    public Armor body;
    public Armor head;
    public Armor limbs;

    public float currentArmorValue;
    public float maxArmorValue;

    public bool wearsSet;


    bool CheckForEquippedArmor(Armor part)
    {
        if (part != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckIfWearsSet()
    {
        if (CheckForEquippedArmor(limbs) && CheckForEquippedArmor(head) && CheckForEquippedArmor(body))
        {
            if (limbs.id == head.id && head.id == body.id)
            {
                wearsSet = true;
            }
            else
            {
                wearsSet = false;
            }
        }
        else
        {
            wearsSet = false;
        }
    }

    public void SetMaxArmorValue()
    {
        maxArmorValue = 0;
        CheckIfWearsSet();
        
        if (wearsSet)
        {
            maxArmorValue = head.armorSet + body.armorSet + limbs.armorSet;
        }
        else
        {
            if (CheckForEquippedArmor(head))
            {
                maxArmorValue += head.armorSingle;
            }
            else
            {
                maxArmorValue += 0;
            }
            if (CheckForEquippedArmor(body))
            {
                maxArmorValue += body.armorSingle;
            }
            else
            {
                maxArmorValue += 0;
            }
            if (CheckForEquippedArmor(limbs))
            {
                maxArmorValue += limbs.armorSingle;
            }
            else
            {
                maxArmorValue += 0;
            }
        }
        gameObject.GetComponent<CharacterFigurePiece>().ChangeArmor(currentArmorValue, maxArmorValue);
    }
    public void EquipArmor(Armor part)
    {
        switch (part.armorType)
        {
            case Armor.ArmorType.Head:
                if (head == null)
                {
                    head = part;
                    SetMaxArmorValue();
                }
                break;
            case Armor.ArmorType.Body:
                if (body == null)
                {
                    body = part;
                    SetMaxArmorValue();
                }
                break;
            case Armor.ArmorType.Limbs:
                if (limbs == null)
                {
                    limbs = part;
                    SetMaxArmorValue();
                }
                break;
            default:
                break;
        }
    }
    public void UnequipArmor(Armor part)
    {
        switch (part.armorType)
        {
            case Armor.ArmorType.Head:
                if (head != null)
                {
                    head = null;
                    SetMaxArmorValue();
                }
                break;
            case Armor.ArmorType.Body:
                if (body != null)
                {
                    body = null;
                    SetMaxArmorValue();
                }
                break;
            case Armor.ArmorType.Limbs:
                if (limbs != null)
                {
                    limbs = null;
                    SetMaxArmorValue();
                }
                break;
            default:
                break;
        }
    }
}
