using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItemScript : MonoBehaviour
{
	[SerializeField]
	private GameObject itemWindow;

	public GameObject ITEM_WINDOW
	{
		get { return itemWindow; }
		set { itemWindow = value; }
	}

	public Button[] individualItemButton;

	[SerializeField]
	private string[] itemNameID;

	public string[] ITEM_NAME_ID
	{
		get { return itemNameID; }
		set { itemNameID = value; }
	}
}
