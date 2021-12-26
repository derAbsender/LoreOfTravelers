using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;

    // Start is called before the first frame update
    void Start()
    {
        if (transitionName == PlayerInputManager.instance.GetComponent<PartyResources>().areaTransitionName)
        {
            PlayerInputManager.instance.gameObject.transform.position = this.gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
