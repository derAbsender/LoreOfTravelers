using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public DraggableItem.Slot typeOfThisToken = DraggableItem.Slot.GeneralItemHolder;

	[SerializeField]
	private string itemID;

	public string ITEM_ID
	{
		get { return itemID; }
		set { itemID = value; }
	}

	[SerializeField]
	private Text amount;

	public Text AMOUNT
	{
		get { return amount; }
		set { amount = value; }
	}

	[SerializeField]
	private string slotID;

	public string SLOT_ID
	{
		get { return slotID; }
		set { slotID = value; }
	}

	[SerializeField]
	private Text ActionButtonText;

	public Text ACTION_BUTTON_TEXT
	{
		get { return ActionButtonText; }
		set { ActionButtonText = value; }
	}


	[SerializeField]
	private GameObject figureView;

	public GameObject FIGURE_VIEW
	{
		get { return figureView; }
		set { figureView = value; }
	}

	[SerializeField]
	private GameObject figureTokenHolder;

	public GameObject FIGURE_TOKEN_HOLDER
	{
		get { return figureTokenHolder; }
		set { figureTokenHolder = value; }
	}

	[SerializeField]
	private GameObject itemDescription;

	public GameObject ITEM_DESCRIPTION
	{
		get { return itemDescription; }
		set { itemDescription = value; }
	}

	[SerializeField]
	private GameObject bagpack;

	public GameObject BAGPACK
	{
		get { return bagpack; }
		set { bagpack = value; }
	}


	public void OnDrop(PointerEventData eventData)
	{
		DraggableItem d = eventData.pointerDrag.GetComponent<DraggableItem>();
		ItemToken it = eventData.pointerDrag.GetComponent<ItemToken>();
		Item i = eventData.pointerDrag.GetComponent<Item>();		
		ItemToken itThis = this.GetComponentInChildren<ItemToken>();
		Item iThis = this.GetComponentInChildren<Item>();


		if (d != null)
		{
			if (typeOfThisToken == DraggableItem.Slot.GeneralItemHolder || typeOfThisToken == d.typeOfThisToken)
			{				
				if (this.transform.childCount != 0)
				{
					if (iThis.ITEM_NAME == i.ITEM_NAME)
					{
						//Debug.Log(GameMenu.instance.IS_DRAGGING);
						iThis.AMOUNT += i.AMOUNT;
						iThis.updateAmount();
						if (iThis.AMOUNT > iThis.STACK_SIZE)
						{
							int newAmount = iThis.AMOUNT - iThis.STACK_SIZE;
							iThis.AMOUNT = iThis.STACK_SIZE;
							i.AMOUNT = newAmount;

							Debug.Log(itThis.GetComponent<Item>().AMOUNT);
							Debug.Log(iThis.AMOUNT);

							itThis.updateAmount();
							it.updateAmount();
						}
						else
						{
							itThis.updateAmount();
							GameMenu.instance.deleteItemInPool(i.OWNER, i.INVENTORY_ID);
							
							Destroy(it.gameObject);
							
							GameMenu.instance.updateInventoryPosition(i.OWNER, this.SLOT_ID, i.INVENTORY_ID);
						}
					}
					else
					{
						this.transform.GetChild(0).transform.SetParent(d.parentToReturnTo);
						d.parentToReturnTo = this.transform;
					}					
				}
				else
				{
					d.parentToReturnTo = this.transform;
				}				
			}
		}
		if (it != null)
		{
			if (typeOfThisToken == d.typeOfThisToken || typeOfThisToken == DraggableItem.Slot.GeneralItemHolder)
			{
				//It is not yet safe to assume the correct owner. However this will assume the correct owner:
				GameMenu.instance.updateInventoryPosition(i.OWNER, this.SLOT_ID, i.INVENTORY_ID);
				it.INVENTORY_POSITION_ID = this.slotID;
				i.INVENTORY_ID = this.slotID;
			}
			if (typeOfThisToken == DraggableItem.Slot.Dispose)
			{
				it.INVENTORY_POSITION_ID = this.slotID;
				Destroy(it.gameObject);
				i.OWNER.removeItemFromInventory(i);
				GameMenu.instance.deleteItemInPool(i.OWNER, i.INVENTORY_ID);
			}
		}
		GameMenu.instance.IS_DRAGGING = false;
		GameMenu.instance.changeButtonToCloseBag();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		//Debug.Log("OnPointerExit");		
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		//Debug.Log("OnPointerEnter");
	}

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (typeOfThisToken == DraggableItem.Slot.Dispose)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				if (figureView.activeInHierarchy)
				{
					figureView.SetActive(false);
					if (figureTokenHolder.activeInHierarchy)
					{
						figureTokenHolder.SetActive(false);
					}
					ActionButtonText.text = "Put away Bagpack";
					itemDescription.SetActive(true);
					bagpack.SetActive(true);
					GameMenu.instance.BAGPACK_OPEN = true;
				}
				else
				{
					itemDescription.SetActive(false);
					if (bagpack.activeInHierarchy)
					{
						bagpack.SetActive(false);
					}
					ActionButtonText.text = "Open Bagpack";
					figureView.SetActive(true);
					figureTokenHolder.SetActive(true);
					GameMenu.instance.BAGPACK_OPEN = false;
				}
			}
		}
	}
}
