using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	GameObject Player;
	PlayerInputManager pim;
	public float attackRadius = 0.85f;
	public LayerMask selectObjectsToHit;

	public void InitializeConstantHit(GameObject Player)
    {        
        this.Player = Player;
        pim = this.Player.GetComponent<PlayerInputManager>();
        if (Player.GetComponent<PartyMemberManager>().activeCFP.playerStats.stamina.currValue - 4 >= 0)
        {
            Player.GetComponent<PartyMemberManager>().activeCFP.ChangeStamina(-4);
        }
        
        StartCoroutine("ConstantHit");       
    }

	IEnumerator ConstantHit()
	{        

        Collider2D[] objectsHit;

        while (pim.isAttacking)
        {
            objectsHit = Physics2D.OverlapCircleAll(pim.attackPosition.position, attackRadius, selectObjectsToHit);

            if (objectsHit.Length > 0)
            {
                foreach (Collider2D hit in objectsHit)
                {
                    if (pim.pmm.activeCFP.heldWeapon.weaponType == WeaponObject.WeaponType.Sword && hit.gameObject.layer != 10)
                    {                        
                        Destroy(hit.gameObject);
                    }
                    if (hit.gameObject.layer == 10)
                    {                        
                        hit.gameObject.GetComponent<Bomb>().StartBlowUp();
                    }
                }
            }
            yield return null;
        }
        //Player.GetComponent<PartyMemberManager>().activeCFP.ChangeDurability(-10);        
        Destroy(gameObject);

    }
}
