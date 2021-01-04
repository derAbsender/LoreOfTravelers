using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FigureToken : Draggable, IPointerEnterHandler
{
	[SerializeField]
	private string figureID;

	public string FIGURE_ID
	{
		get { return figureID; }
		set { figureID = value; }
	}

	[SerializeField]
	private string spawnPositionID;

	public string SPAWN_POSITION_ID
	{
		get { return spawnPositionID; }
		set { spawnPositionID = value; }
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		if (typeOfThisToken == Draggable.Slot.CharacterToken)
		{			
			GameMenu.instance.updateMainStats(figureID);
		}
	}



	// Start is called before the first frame update
	void Start()
	{
		if (SPAWN_POSITION_ID == "")
		{
			this.SPAWN_POSITION_ID = this.GetComponentInParent<FigurSlot>().SPAWN_POSITION_ID;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
