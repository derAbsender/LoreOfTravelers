using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FigurSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Draggable.Slot typeOfThisToken = Draggable.Slot.CharacterToken;

	[SerializeField]
	private string figureID;

	public string FIGURE_ID
	{
		get { return figureID; }
		set { figureID = value; }
	}

	[SerializeField]
	private Text figureName;

	public Text FIGURE_NAME
	{
		get { return figureName; }
		set { figureName = value; }
	}

	[SerializeField]
	private string slotPositionID_SPAWN;

	public string SPAWN_POSITION_ID
	{
		get { return slotPositionID_SPAWN; }
		set { slotPositionID_SPAWN = value; }
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		FigureToken ft = eventData.pointerDrag.GetComponent<FigureToken>();

		if (d != null)
		{
			if (typeOfThisToken == d.typeOfThisToken)
			{				
				if (this.transform.childCount != 0)
				{
					Debug.Log(true+" FIGURTOKEN");
					this.transform.GetChild(0).transform.SetParent(d.parentToReturnTo);
				}
				else
				{
					Debug.Log(false + " FIGURTOKEN");
				}
				d.parentToReturnTo = this.transform;
			}
		}
		if (ft != null)
		{
			if (typeOfThisToken == d.typeOfThisToken && typeOfThisToken == Draggable.Slot.CharacterToken)
			{
				Debug.Log(true);
				Debug.Log("this."+ SPAWN_POSITION_ID);				
				ft.SPAWN_POSITION_ID = this.SPAWN_POSITION_ID;
				Debug.Log("ft." + ft.SPAWN_POSITION_ID);
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//Debug.Log("OnPointerExit");		
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
