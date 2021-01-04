using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Draggable.Slot typeOfThisToken = Draggable.Slot.CharacterToken;

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();

		if (d != null)
		{
			if (typeOfThisToken == d.typeOfThisToken)
			{
				
				if (this.transform.childCount != 0)
				{
					Debug.Log(true);
					this.transform.GetChild(0).transform.SetParent(d.parentToReturnTo);
				}
				else
				{
					Debug.Log(false);
				}
				d.parentToReturnTo = this.transform;
			}			
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnPointerEnter");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnPointerExit");		
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
