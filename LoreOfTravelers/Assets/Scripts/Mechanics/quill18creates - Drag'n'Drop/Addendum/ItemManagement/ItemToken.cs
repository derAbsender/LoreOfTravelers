using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemToken : DraggableItem, IPointerEnterHandler, IPointerClickHandler
{
	//public Draggable.Slot typeOfThisToken = Draggable.Slot.CharacterToken;

	//[SerializeField]
	//private string ItemID;

	//public string ITEM_ID
	//{
	//	get { return ItemID; }
	//	set { ItemID = value; }
	//}

	[SerializeField]
	private string inventoryPositionID;

	public string INVENTORY_POSITION_ID
	{
		get { return inventoryPositionID; }
		set { inventoryPositionID = value; }
	}

	[SerializeField]
	GameObject ItemPrefab;

	public void OnPointerEnter(PointerEventData eventData)
	{

	}

	public void OnPointerClick(PointerEventData eventData)
	{
		bool destroy = false;
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			if (GameMenu.instance.BAGPACK_OPEN && !controlSpace())
			{
				GetComponent<Item>().AMOUNT--;
				for (int i = 0; i < GameMenu.instance.item_SlotBagPack.Length; i++)
				{
					if (GameMenu.instance.item_SlotBagPack[i].transform.childCount == 0)
					{
						ItemToken newStack = Instantiate(this, GameMenu.instance.item_SlotBagPack[i].transform);
						newStack.GetComponent<Item>().AMOUNT = 1;
						newStack.GetComponent<Item>().updateInventoryPositionID(newStack.GetComponentInParent<ItemSlot>().SLOT_ID);
						newStack.updateAmount();
						//Debug.Log(newStack.GetComponent<Item>().OWNER);	
						//GameMenu.instance.addItemToInventory(newStack.GetComponent<Item>().OWNER, newStack.GetComponent<Item>());
						break;
					}
				}
			}
			updateAmount();
			//Debug.Log(GetComponent<Item>().AMOUNT <= 0);
			if (GetComponent<Item>().AMOUNT <= 0)
			{
				Destroy(this.gameObject);
			}
			GameMenu.instance.updateInventoryArrangement(GetComponent<Item>().OWNER);
		}
	}
	private bool controlSpace()
	{
		bool isFull = true;

		foreach (var item in GameMenu.instance.item_SlotBagPack)
		{
			if (item.transform.childCount == 0)
			{
				isFull = false;
			}
		}
		//Debug.Log(isFull);
		return isFull;
	}
	public void destroyThis()
	{
		Destroy(this.gameObject);
	}

	// Start is called before the first frame update
	void Start()
	{
		//Debug.Log("TOKEN "+ this.GetComponent<Item>().INVENTORY_ID);
		this.inventoryPositionID = this.GetComponent<Item>().INVENTORY_ID;
			
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void updateAmount()
	{
		GetComponentInChildren<Text>().text = GetComponent<Item>().AMOUNT.ToString();
	}
	
}
