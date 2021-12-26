using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler
{
    public UserInterface ui;
    public GameObject Player;

    public void OnDrop(PointerEventData eventData)
    {
        Player.GetComponent<PartyMemberManager>().activeCFP.juggernaut.UnequipArmor(eventData.pointerDrag.GetComponent<ArmorToken>().armor);
        eventData.pointerDrag.GetComponent<Image>().sprite = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
