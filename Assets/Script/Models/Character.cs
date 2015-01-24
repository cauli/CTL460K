using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int maxItens;
	public Item[] inventario;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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

}
