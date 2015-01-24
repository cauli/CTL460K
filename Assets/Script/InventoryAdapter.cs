using UnityEngine;
using System.Collections;

public class InventoryAdapter : MonoBehaviour {

	public Character character;

	public Transform inventorySlot;

	void Start () {

		//inventorySlot.SetParent(gameObject.transform, true);

		int currentX = 0;

		foreach(Item item in character.inventario)
		{
			currentX += 150;

			GameObject iSlot = (GameObject) Instantiate (inventorySlot, new Vector3(currentX, 0, 0), Quaternion.identity);
			iSlot.transform.parent = gameObject.transform;
		}
	}

	void Update () {
	
	}
}
