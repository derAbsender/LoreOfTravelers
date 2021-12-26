using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArmorToken : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    //[SerializeField] private Canvas canvas;
    private CanvasGroup cg;
    Transform parentToReturnTo = null;
    Vector2 onScreenPosition = Vector2.zero;
    public Armor armor;
    public GameObject trashArea;

    void Start()
    {
        cg = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        onScreenPosition = this.transform.position;
        this.transform.SetParent(this.transform.parent.parent);
        cg.blocksRaycasts = false;
        trashArea.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        this.transform.position = onScreenPosition;
        cg.blocksRaycasts = true;
        trashArea.SetActive(false);
    }
}
