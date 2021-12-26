using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultTile : MonoBehaviour
{
    long timeCount = 0;

    PlayerMovement pm;

    //bool staysOnTile = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pm != null)
        {
            timeCount++;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            pm.currentSpeed = pm.speed;
            timeCount = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (timeCount > 60)
            {
                //pm.currentSpeed = pm.speed * 0.25f;
                pm.HandleSpeed();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm = other.gameObject.GetComponent<PlayerMovement>();
            pm.onDifficultTerrain = true;
            //staysOnTile = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pm.currentSpeed = pm.speed;
            pm.onDifficultTerrain = false;
            //staysOnTile = false;
        }
    }
}
