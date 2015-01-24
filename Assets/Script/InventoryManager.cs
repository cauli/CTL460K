using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public GameObject[] currentItems;
	int maxItems = 3;

	void Start () 
	{

	}
	
	bool InsertItem (Item item) 
	{
		return true;
	}

	bool CombineItems (Item item1, Item item2)
	{
		return true;
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
