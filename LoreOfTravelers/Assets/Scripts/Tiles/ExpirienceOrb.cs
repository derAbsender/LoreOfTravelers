using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpirienceOrb : MonoBehaviour
{
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
            other.GetComponent<PartyResources>().countExperienceOrb++;
            other.GetComponent<PartyResources>().countExperienceOrbTotal++;
            if (GameObject.FindGameObjectWithTag("MainObject").GetComponentInChildren<Inventory>())
            {
                GameObject.FindGameObjectWithTag("MainObject").GetComponentInChildren<Inventory>().setAvailableExpOrbInventory();
            }
            Destroy(this.gameObject);
        }
    }
}
