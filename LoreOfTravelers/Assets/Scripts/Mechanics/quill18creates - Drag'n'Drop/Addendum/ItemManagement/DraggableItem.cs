using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public enum Slot { Weapon, Armor, Totem, GeneralItemHolder, Pockets, Dispose };

	public Text ActionButton;

	public Slot typeOfThisToken = Slot.GeneralItemHolder;
	/////////////////////////////////



	public Transform parentToReturnTo;

	public void OnBeginDrag(PointerEventData eventData)
	{
		GameMenu.instance.IS_DRAGGING = true;
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent(this.transform.parent.parent.parent);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		GameMenu.instance.changeButtonToDisposable();
	}

	public void OnDrag(PointerEventData eventData)
	{
		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		GameMenu.instance.IS_DRAGGING = false;
		this.transform.SetParent(parentToReturnTo);
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		ItemToken it = eventData.pointerDrag.GetComponent<ItemToken>();
	}
}
