using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SoapFloorTile : MonoBehaviour
{
    public SpriteRenderer sr;

    public Sprite untouchedSprite;
    public Sprite brokenSprite;
    public Sprite destroyedSprite;
    CharacterFigurePiece cfp;
    bool isBroken = false;

    bool staysOnTile = false;
    bool usedStaff;


    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = untouchedSprite;
    }
    private void Update()
    {
        if (staysOnTile && cfp.heldWeapon.weaponType == WeaponObject.WeaponType.Staff && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("GAMEOVER");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //AND OTHERS
        {
            cfp = other.gameObject.GetComponent<PartyMemberManager>().activeCFP;
            staysOnTile = true;
            if (!isBroken)
            {
                sr.sprite = brokenSprite;
                isBroken = true;
            }
            else
            {
                sr.sprite = destroyedSprite;
                Destroy(other.gameObject);
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