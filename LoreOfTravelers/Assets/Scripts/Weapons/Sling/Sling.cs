using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    [Header("Chain Fundamentals")]
    public Sprite chainHead_Down;

    public GameObject chainLink;

    public LayerMask tallObjects;
    GameObject Player;
    GameObject AttackPosition;
    PlayerInputManager pim;
    public float chainLength = 6;

    Vector2 facedDirection;

    Vector2 endGraphicPoint = new Vector2();
    Vector2 endMechanicalPoint = new Vector2();
    Vector2 startGraphicPosition;
    Vector2 startMechanicalPosition;
    int distanceSafe = 0;

    List<GameObject> chainLinkCount = new List<GameObject>();

    public float duration = 50f;

    bool hitScalable = false;

    bool getDragable = false;
    Transform draggedItem;



    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        pim = Player.GetComponent<PlayerInputManager>();
    }
    public void InitializeChain(Vector2 directionFaced, GameObject player, GameObject attackPosition)
    {
        Player = player;
        AttackPosition = attackPosition;
        Player.GetComponent<PartyMemberManager>().activeCFP.ChangeStamina(-1);

        facedDirection = directionFaced;
        startMechanicalPosition = Player.transform.position;
        endMechanicalPoint = startMechanicalPosition + directionFaced.normalized * chainLength;

        startGraphicPosition = AttackPosition.transform.position;
        endGraphicPoint = startGraphicPosition + directionFaced.normalized * chainLength;

        float distance = Vector2.Distance(startMechanicalPosition, endGraphicPoint);
        Vector2 direction = ((startMechanicalPosition - endGraphicPoint).normalized) * -1;

        RaycastHit2D hit = Physics2D.Raycast(startMechanicalPosition, direction, distance, tallObjects);

        if (hit.distance != 0)
        {
            endGraphicPoint = (startGraphicPosition + directionFaced.normalized * hit.distance);
            endMechanicalPoint = (startMechanicalPosition + directionFaced.normalized * hit.distance);
            duration = duration / (chainLength * 1.2f - hit.distance);
            if (hit.collider.gameObject.CompareTag("Scalable"))
            {
                hitScalable = true;
            }
            if (hit.collider.gameObject.CompareTag("Draggable"))
            {
                getDragable = true;
                draggedItem = hit.collider.gameObject.transform;
            }
        }
        else
        {
            duration = 0.3f;
        }

        StartCoroutine("LerpChain");
    }

    IEnumerator LerpChain()
    {
        float time = 0;

        while (time < duration)
        {
            ShowChain(Player, gameObject);

            gameObject.transform.position = Vector2.Lerp(startGraphicPosition, endGraphicPoint, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.position = endGraphicPoint;
        distanceSafe++;

        if (hitScalable)
        {
            endGraphicPoint = endGraphicPoint + facedDirection * 1.2f;
            StartCoroutine("LerpChainOverScalable");
        }
        else
        {
            StartCoroutine("LerpChainBack");
        }

    }
    IEnumerator LerpChainBack()
    {
        if (getDragable)
        {
            StartCoroutine("LerpDraggedItem");
        }

        float time = 0;
        while (time < duration)
        {
            DeleteChain(Player, gameObject);

            gameObject.transform.position = Vector2.Lerp(endGraphicPoint, startGraphicPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.position = startGraphicPosition;

        foreach (var item in chainLinkCount)
        {
            Destroy(item);
        }
        chainLinkCount.Clear();

        pim.canMove = true;
        pim.animatingStop = false;
        pim.isAttacking = false;

        Destroy(gameObject);
    }

    IEnumerator LerpDraggedItem()
    {
        float time = 0;
        while (time < duration)
        {
            draggedItem.position = Vector2.Lerp(endGraphicPoint, startGraphicPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        draggedItem.position = startGraphicPosition;
        if (Player.GetComponent<PartyMemberManager>().activeCFP.playerStats.stamina.currValue - 1 >= 0)
        {
            Player.GetComponent<PartyMemberManager>().activeCFP.ChangeStamina(-1);
        }
    }

    IEnumerator LerpChainOverScalable()
    {

        Player.GetComponent<PartyMemberManager>().activeCFP.ChangeDurability(-10);
        if (Player.GetComponent<PartyMemberManager>().activeCFP.playerStats.stamina.currValue - 2 >= 0)
        {
            Player.GetComponent<PartyMemberManager>().activeCFP.ChangeStamina(-2);
        }

        float time = 0;
        //duration = 3;
        while (time < duration)
        {
            DeleteChainBehind(Player, gameObject);

            Player.transform.position = Vector2.Lerp(startMechanicalPosition, endMechanicalPoint, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Player.transform.position = endMechanicalPoint + Player.GetComponent<PlayerMovement>().directionFaced * 2;

        foreach (var item in chainLinkCount)
        {
            Destroy(item);
        }
        chainLinkCount.Clear();

        pim.canMove = true;
        pim.animatingStop = false;
        pim.isAttacking = false;
        Destroy(gameObject);
    }


    void ShowChain(GameObject A, GameObject B)
    {
        int distance = (int)(Vector2.Distance(A.transform.position, B.transform.position) / 0.3);

        if (distance != distanceSafe)
        {
            distanceSafe = distance;

            chainLinkCount.Add(Instantiate(chainLink, new Vector2(B.transform.position.x, B.transform.position.y), Quaternion.identity));
        }
    }

    void DeleteChain(GameObject A, GameObject B)
    {
        int distance = (int)(Vector2.Distance(A.transform.position, B.transform.position) / 0.3);

        if (distance > chainLinkCount.Count)
        {
            distance = chainLinkCount.Count;
        }

        if (chainLinkCount[chainLinkCount.Count - 1] != null)
        {
            Destroy(chainLinkCount[chainLinkCount.Count - 1]);
        }
        if (distance - 1 >= 0)
        {
            Destroy(chainLinkCount[distance - 1]);
        }
    }

    void DeleteChainBehind(GameObject A, GameObject B)
    {
        int distance = (int)(Vector2.Distance(A.transform.position, B.transform.position) / 0.3);
        distance++;

        if (distance > chainLinkCount.Count)
        {
            distance = chainLinkCount.Count;
        }

        if (chainLinkCount.Count > 0 && chainLinkCount[0])
        {
            Destroy(chainLinkCount[0]);
        }
        if (chainLinkCount.Count - distance > 0 && chainLinkCount[chainLinkCount.Count - distance] != null)
        {
            Destroy(chainLinkCount[chainLinkCount.Count - distance]);
        }
    }
}
