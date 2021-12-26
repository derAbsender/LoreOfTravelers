using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject MainObject;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerInputManager.instance == null)
        {
            Instantiate(MainObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
