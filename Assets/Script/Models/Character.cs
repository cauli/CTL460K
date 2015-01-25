using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public int maxItens;
	public Item[] inventario;
	public InventoryAdapter inventoryAdapter;

	public AudioSource audioSrc;
	public GameObject cameraGO;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool InsertItem (Item item) 
	{

		foreach(Item itemNoInventorio in inventario)
		{
			if(itemNoInventorio == item)
			{
				return false;
			}
		}

		for (int i = 0; i < inventario.Length; i++) {
			if(inventario[i] == null){
				item.renderer.enabled = false;
				item.gameObject.SetActive(false);
				inventario[i] = item;
				inventoryAdapter.UpdateInventory();
				return true;
			}
		}

		return false;
	}
	
	public void DropItem (Item item)
	{
		Debug.Log("ENTROU");
		for (int i = 0; i < inventario.Length; i++) {
			if(inventario[i] == item){
				Debug.Log("DROPOU");
				inventario[i].renderer.enabled = true;
				item.gameObject.SetActive(true);
				inventario[i].gameObject.transform.position = gameObject.transform.position;
				inventario[i].gameObject.transform.rigidbody2D.AddTorque(Random.Range(-10,10));
				inventario[i].gameObject.transform.rigidbody2D.AddForce(new Vector2(Random.Range(-20,20),Random.Range(-20,20)));
				inventario[i] = null;
			}
		}	
		inventoryAdapter.UpdateInventory();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "SelectedPortal"){
			Portal portal = coll.gameObject.GetComponent<Portal>();
			
			float x = portal.destination.mapa.gameObject.transform.position.x;
			float y = 0;
			
			Vector3 toPosition = new Vector3(x,y,-45);
			// Mover camera para outro mapa 
			iTween.Stop();

			cameraGO.GetComponent<Puzzle>().currentMap = portal.destination.mapa;
			cameraGO.GetComponent<Puzzle>().setMapConfig();

			Camera.main.transform.position = toPosition;
			gameObject.transform.position = portal.destination.initialCharacterPosition.position;
		}
		else if(coll.gameObject.tag == "SelectedItem" && (coll.gameObject.name == "Adesivo" || coll.gameObject.name == "Laika")){
			// Adicionar item no inventario se ele nao estiver cheio
			Item item = coll.gameObject.GetComponent<Item>();
			bool added = InsertItem(item);

			if(added)
			{
				coll.gameObject.tag = "Item";
				coll.gameObject.collider2D.isTrigger = false;
				coll.gameObject.rigidbody2D.isKinematic = false;
				coll.gameObject.renderer.material.color = Color.white;

				audioSrc.Play ();
			}
		}
		else if( coll.gameObject.name == "EndCollider" )
		{
			if(Puzzle.levelEnded)
			{
				Application.LoadLevel ("Credits");
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "SelectedItem") {
			// Adicionar item no inventario se ele nao estiver cheio
			Item item = coll.gameObject.GetComponent<Item>();
			bool added = InsertItem(item);

			if(added)
			{
				coll.gameObject.tag = "Item";
				coll.gameObject.renderer.material.color = Color.white;
				
				audioSrc.Play ();
			}
		}
	}
}
