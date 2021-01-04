using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseOnTargetButton : MonoBehaviour
{
	[SerializeField]
	private Combatant target;

	public Combatant TARGET
	{
		get { return target; }
		set { target = value; }
	}

	[SerializeField]
	private Item assignedItem;

	public Item ASSIGNED_ITEM
	{
		get { return assignedItem; }
		set { assignedItem = value; }
	}

	public void initializeItemUse()
	{
		assignedItem.useItem(target, assignedItem);
	}
}
