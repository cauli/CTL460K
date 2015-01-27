using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {

	public int maxItens;
	public Item[] inventario;
	public InventoryAdapter inventoryAdapter;

	public AudioSource audioSrc;
	public GameObject cameraGO;

	public AudioClip inventoryFull;

	private Canvas inventoryCanvas;

	private bool disableInteraction = false;

	void Start ()
	{
		inventoryCanvas = inventoryAdapter.gameObject.GetComponent<Canvas>();
	}

	bool InsertItem (Item item) 
	{
		Debug.Log ("Tried insert");
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
		for (int i = 0; i < inventario.Length; i++) {
			if(inventario[i] == item){
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
			else
			{
				Debug.Log ("Couldnt add");
			}
		}
		else if( coll.gameObject.name == "EndCollider" )
		{
			if(Puzzle.levelEnded)
			{
				iTween.Stop();

				Application.LoadLevel ("Credits");
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		CollidingWithSelected(coll);
	}

	void OnCollisionStay2D(Collision2D coll) {
		CollidingWithSelected(coll);
	}

	void CollidingWithSelected(Collision2D coll)
	{
		if(!disableInteraction)
		{

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
				else
				{
					Debug.Log("Not added");

					GameObject.FindGameObjectWithTag("SelectedItem").tag = "Item";
					StartCoroutine(disableForAWhile());
					StartCoroutine(unableToAdd());
				}
			}
		}
	}

	private IEnumerator disableForAWhile()
	{
		disableInteraction = true;
		yield return new WaitForSeconds(1f);
		disableInteraction = false;
	}
	private IEnumerator unableToAdd()
	{

		inventoryCanvas.enabled = false;

		audioSrc.PlayOneShot (inventoryFull);

		yield return new WaitForSeconds(0.1f);

		inventoryCanvas.enabled = true;


		yield return new WaitForSeconds(0.1f);

		inventoryCanvas.enabled = false;

		
		audioSrc.PlayOneShot (inventoryFull);

		yield return new WaitForSeconds(0.1f);

		inventoryCanvas.enabled = true;


	}

	
}
