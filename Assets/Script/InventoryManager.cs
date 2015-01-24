using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	Item[] currentItems;
	int maxItems = 3;

	void Start () 
	{

	}
	
	bool InsertItem (Item item) 
	{

	}

	bool CombineItems (Item item1, Item item2)
	{

	}

	void DropItem (Item item)
	{

	}

	private bool canAddItem()
	{
		return currentItems.Length < maxItems;
	}

	void Update ()
	{
	
	}
}
