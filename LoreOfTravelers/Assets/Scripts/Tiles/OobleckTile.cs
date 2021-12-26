using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OobleckTile : MonoBehaviour
{
    long timeCount = 0;

    PlayerMovement pm;
    CharacterFigurePiece cfp;

    bool staysOnTile = false;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!pm.isMoving && timeCount < 40)
            {
                StartCoroutine(IdleOnOobleck(pm));               
            }
            if (pm.isExhausted)
            {
                Destroy(pm.gameObject);
            }
        }
    }

    private void Update()
    {
        if (pm != null && !pm.isMoving)
        {
            timeCount++;
        }
        else
        {
            timeCount = 0;
        }
        
        if (staysOnTile && cfp.heldWeapon.weaponType == WeaponObject.WeaponType.Staff && Input.GetButtonDown("Fire1"))
        {
            Destroy(pm.gameObject);
        }
    }

    IEnumerator IdleOnOobleck(PlayerMovement player)
    {
        yield return new WaitUntil(() => player.isMoving || timeCount > 200);
        
        if (timeCount > 200)
        {
            Destroy(player.gameObject);
        }
        else
        {
            timeCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm = other.gameObject.GetComponent<PlayerMovement>();
            cfp = other.gameObject.GetComponent<PartyMemberManager>().activeCFP;

            staysOnTile = true;

            if (pm.isExhausted)
            {
                Destroy(pm.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            staysOnTile = false;
        }
    }
}
