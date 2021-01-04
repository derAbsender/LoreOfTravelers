using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
	[SerializeField]
	private Item assignedItem;

	public Item ASSIGNED_ITEM
	{
		get { return assignedItem; }
		set { assignedItem = value; }
	}

	[SerializeField]
	private Image itemImage;

	public Image ITEM_IMAGE
	{
		get { return itemImage; }
		set { itemImage = value; }
	}
}
