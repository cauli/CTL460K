using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int maxItens;
	public Item[] inventario;
	public InventoryAdapter inventoryAdapter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool InsertItem (Item item) 
	{
		for (int i = 0; i < inventario.Length; i++) {
			if(inventario[i] == null){
				inventario[i] = item;
				item.renderer.enabled = false;
				inventoryAdapter.UpdateInventory();
				return true;
			}
		}
		return false;
	}
	
	public void DropItem (Item item)
	{
		Debug.Log("ENTROU NO DROP");
		for (int i = 0; i < inventario.Length; i++) {
			if(inventario[i] == item){
				Debug.Log("DROPA ESSA PORRAAA");
				inventario[i].renderer.enabled = true;
				inventario[i].gameObject.transform.position = gameObject.transform.position;
				inventario[i] = null;
			}
		}	
		inventoryAdapter.UpdateInventory();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "SelectedItem") {
			// Adicionar item no inventario se ele nao estiver cheio
			Item item = coll.gameObject.GetComponent<Item>();
			bool added = InsertItem(item);
		}else if (coll.gameObject.tag == "SelectedPortal"){
			Portal portal = coll.gameObject.GetComponent<Portal>();
			
			float x = portal.destination.mapa.gameObject.transform.position.x;
			float y = portal.destination.mapa.gameObject.transform.position.y;
			
			Vector3 toPosition = new Vector3(x,y,-45);
			// Mover camera para outro mapa 
			iTween.Stop();
			Camera.main.transform.position = toPosition;
			gameObject.transform.position = portal.destination.initialCharacterPosition.position;
		}
	}
}
