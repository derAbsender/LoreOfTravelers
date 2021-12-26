using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorIcon : MonoBehaviour
{
    public Armor armor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInputManager pim = collision.gameObject.GetComponent<PlayerInputManager>();
            if (pim.pmm.activeCFP.classJob == CharacterFigurePiece.ClassJob.Juggernaut)
            {
                //pim.pmm.activeCFP.juggernaut.EquipArmor(this);
                //Debug.Log(pim.pmm.activeCFP.juggernaut.head);
                switch (armor.armorType)
                {
                    case Armor.ArmorType.Head:
                        if (pim.pmm.activeCFP.juggernaut.head == null)
                        {
                            pim.pmm.activeCFP.juggernaut.EquipArmor(armor);
                            pim.pmm.activeCFP.ChangeArmor(pim.pmm.activeCFP.juggernaut.maxArmorValue, pim.pmm.activeCFP.juggernaut.maxArmorValue);

                            Destroy(gameObject);
                        }
                        break;
                    case Armor.ArmorType.Body:
                        if (pim.pmm.activeCFP.juggernaut.body == null)
                        {
                            pim.pmm.activeCFP.juggernaut.EquipArmor(armor);
                            pim.pmm.activeCFP.ChangeArmor(pim.pmm.activeCFP.juggernaut.maxArmorValue, pim.pmm.activeCFP.juggernaut.maxArmorValue);

                            Destroy(gameObject);
                        }
                        break;
                    case Armor.ArmorType.Limbs:
                        if (pim.pmm.activeCFP.juggernaut.limbs == null)
                        {
                            pim.pmm.activeCFP.juggernaut.EquipArmor(armor);
                            pim.pmm.activeCFP.ChangeArmor(pim.pmm.activeCFP.juggernaut.maxArmorValue, pim.pmm.activeCFP.juggernaut.maxArmorValue);

                            Destroy(gameObject);
                        }
                        break;
                    default:
                        break;
                }
                if (GameObject.FindGameObjectWithTag("MainObject").GetComponentInChildren<ClassInventoryManager>())
                {
                    GameObject.FindGameObjectWithTag("MainObject").GetComponentInChildren<ClassInventoryManager>().SetArmorInventory(armor);
                }

            }
        }
    }
}
