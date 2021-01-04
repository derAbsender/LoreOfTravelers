using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public enum Slot { Weapon, Armor, Totem, CharacterToken, GeneralItemHolder, Pockets};

	public Slot typeOfThisToken = Slot.GeneralItemHolder;
	/////////////////////////////////



	public Transform parentToReturnTo;

	public void OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("OnBeginDrag");

		parentToReturnTo = this.transform.parent;
		this.transform.SetParent(this.transform.parent.parent);

		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Debug.Log("OnDrag");

		this.transform.position = eventData.position;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("OnEndDrag");
		this.transform.SetParent(parentToReturnTo);
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		FigureToken ft = eventData.pointerDrag.GetComponent<FigureToken>();
		if (this.typeOfThisToken == Slot.CharacterToken)
		{
			for (int i = 0; i < GameMaster.instance.PLAYER_PARTY.Count; i++)
			{
				if (GameMaster.instance.PLAYER_PARTY[i].FIGURE_ID == ft.FIGURE_ID)
				{
					GameMaster.instance.PLAYER_PARTY[i].SPAWN_POSITION_ID = ft.SPAWN_POSITION_ID;
				}
			}
			
		}
	}
}
