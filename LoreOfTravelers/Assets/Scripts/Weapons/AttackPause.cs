using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPause : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInputManager pim;

    private void Start()
    {

    }

    public void AttackPauseEnd()
    {
        if (pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Sword)
        {
            pim.canMove = true;
            pim.isAttacking = false;
        }
        else if (pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Staff)
        {
            StartCoroutine("AttackPauseInit");
        }
        else if (pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Bow || pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Fist)
        {
            pim.animatingStop = false;
            pim.canMove = true;
        }
    }

    IEnumerator AttackPauseInit()
    {
        yield return new WaitForSeconds(.1f);
        pim.isAttacking = false;
    }


}
