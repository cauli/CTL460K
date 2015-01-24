using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryAdapter : MonoBehaviour {

	public Character character;

	public GameObject inventorySlot;

	void Start () {
		int currentX = 0;

		foreach(Item item in character.inventario)
		{

			GameObject iSlot = Instantiate (inventorySlot, new Vector3(currentX, 0, 0), Quaternion.identity) as GameObject;

			iSlot.transform.SetParent (gameObject.transform, false);

			if(item != null)
			{

				GameObject slotItem = iSlot.transform.GetChild(0).gameObject as GameObject;

				Image itemImage = slotItem.GetComponent<Image>();
			 
				InventoryItem inventoryItem = slotItem.GetComponent<InventoryItem>();

				inventoryItem.item = item;

				itemImage.sprite = inventoryItem.item.gameObject.GetComponent<SpriteRenderer>().sprite;
			}
			currentX += 55;
		}
	}

	void Update () {
	
	}
}
