using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Animator animBomb;

    //public Transform attackPosition;
    public float attackRadius;
    public int maxObjectsHit = 5;
    public Collider2D[] objectsHit;
    public LayerMask selectObjectsToHit;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Player.GetComponent<PartyMemberManager>().activeCFP.ChangeAmount(-1);
        StartCoroutine("PlacedBomb");
    }

    IEnumerator PlacedBomb()
    {
        yield return new WaitForSeconds(1.5f); //1.5
        animBomb.SetTrigger("Burning");
        StartCoroutine("SpeedUp");

    }

    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(15f); //1.5
        animBomb.speed *= 2;
        StartCoroutine("BlowUp");
    }

    IEnumerator BlowUp()
    {
        yield return new WaitForSeconds(.1f);
        objectsHit = Physics2D.OverlapCircleAll(this.transform.position, attackRadius, selectObjectsToHit);
        if (objectsHit.Length > 0)
        {
            foreach (Collider2D hit in objectsHit)
            {
                if (hit.CompareTag("Bombable"))
                {
                    Destroy(hit.gameObject);
                }
                if (hit.gameObject.layer == 10)
                {
                    hit.gameObject.GetComponent<Bomb>().StartBlowUp();
                }
            }
        }
        animBomb.SetTrigger("Explodes");
    }

    public void StartBlowUp()
    {
        StartCoroutine("BlowUp");
    }

    void ExplosionEnd()
    {        
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        if (this.transform == null)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Arrow>())
        {
            StartCoroutine("BlowUp");
        }
    }
}
