using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFront : MonoBehaviour
{
    public Transform front;

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
        switch (collision.gameObject.layer)
        {
            case 10: front = collision.gameObject.transform; break;
            case 8: front = collision.gameObject.transform; break;
            default:
                break;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.layer)
        {
            case 10: front = collision.gameObject.transform; break;
            case 8: front = collision.gameObject.transform; break;
            default:
                break;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        front = null;
    }
}
