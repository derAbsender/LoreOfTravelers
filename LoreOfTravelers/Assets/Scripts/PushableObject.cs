using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    GameObject Player;
    public float duration = 0.1f;
    float distanceAdjuster;
    public LayerMask tallObjects;
    public Collider2D[] objectsHit;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObject()
    {
        StartCoroutine("LerpObject");
    }

    IEnumerator LerpObject()
    {
        float time = 0;
        distanceAdjuster = GetComponent<SpriteRenderer>().sprite.bounds.size.y * .5f;

        Vector2 dirFace = Player.GetComponent<PlayerInputManager>().directionFaced.normalized;
        Vector2 endPoint = gameObject.transform.position + (Vector3)dirFace * 1.5f;
        Vector2 startPoint = gameObject.transform.position;
        float distance = Vector2.Distance(startPoint, endPoint);

        Debug.Log((distance + distanceAdjuster));

        RaycastHit2D hit = Physics2D.Raycast(startPoint, dirFace, distance, tallObjects);
        //Debug.DrawRay(startPoint, dirFace * (distance + distanceAdjuster), Color.green);

        if (hit.distance != 0)
        {
            endPoint = (startPoint + dirFace * (hit.distance - distanceAdjuster));
        }

        while (time < duration)
        {
            gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, endPoint, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        gameObject.transform.position = endPoint;
    }

    //public bool CheckSurrounding()
    //{
    //    bool isStuck = false;
    //    objectsHit = Physics2D.OverlapCircleAll(this.transform.position, .25f, tallObjects);
    //    if (objectsHit.Length > 0)
    //    {
    //        foreach (Collider2D hit in objectsHit)
    //        {
    //            isStuck = true;
    //        }
    //    }
    //    return isStuck;
    //}
}
