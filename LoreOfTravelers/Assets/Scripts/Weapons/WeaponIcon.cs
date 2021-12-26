using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIcon : MonoBehaviour
{
    public WeaponObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInputManager pim = other.GetComponent<PlayerInputManager>();

            if (!pim.pmm.activeCFP.emptyHanded)
            {
                switch (weapon.weaponType)
                {
                    case WeaponObject.WeaponType.Sword:
                        break;
                    case WeaponObject.WeaponType.Bomb:
                        if (pim.pmm.activeCFP.heldWeapon.amount != weapon.amountMAX && pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Bomb)
                        {
                            pim.pmm.activeCFP.ChangeAmount(weapon.amountMAX);

                            Destroy(gameObject);
                        }
                        break;
                    case WeaponObject.WeaponType.Bow:
                        if (pim.pmm.activeCFP.heldWeapon.amount != weapon.amountMAX && pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Bow)
                        {
                            pim.pmm.activeCFP.ChangeAmount(weapon.amountMAX);

                            Destroy(gameObject);
                        }
                        break;
                    case WeaponObject.WeaponType.Sling:
                        if (pim.pmm.activeCFP.heldWeapon.durability != weapon.durabilityMAX && pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Sling)
                        {
                            pim.pmm.activeCFP.ChangeDurability(weapon.durabilityMAX);
                            Destroy(gameObject);
                        }
                        break;
                    case WeaponObject.WeaponType.Fist:
                        break;
                    case WeaponObject.WeaponType.Staff:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                
                GameObject wo = Instantiate(weapon.gameObject);
                pim.pmm.activeCFP.PickUpWeapon(wo.GetComponent<WeaponObject>());
                Destroy(wo);                
                Destroy(gameObject);
            }
        }
    }
}
