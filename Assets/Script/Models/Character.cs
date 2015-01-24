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

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Trigger Portal" + other.gameObject);
		if (other.gameObject.tag == "SelectedPortal") {
			Debug.Log ("Portal Certo" + other.gameObject);

			Portal portal = other.gameObject.GetComponent<Portal>();

			float x = portal.destination.mapa.gameObject.transform.position.x;
			float y = portal.destination.mapa.gameObject.transform.position.y;

			Vector3 toPosition = new Vector3(x,y,-45);
			// Mover camera para outro mapa 
			Camera.main.transform.position = toPosition;

			Debug.Log(portal);
		}
	}
}
