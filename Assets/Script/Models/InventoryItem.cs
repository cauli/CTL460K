using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public Item item;
	Image itemImage;
	Vector3 originalPosition;
	GameObject player;
	Character character;


	public void OnBeginDrag (PointerEventData pointerEventData) {
		originalPosition = gameObject.transform.position;
	}

	public void OnDrag(PointerEventData pointerEventData) {
		gameObject.transform.position = new Vector3(pointerEventData.position.x, pointerEventData.position.y, 0);
	}

	public void OnEndDrag(PointerEventData pointerEventData) {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		bool reject = true;

		if(hit.collider != null)
		{
			Debug.Log ("Collider exists");

			if(hit.collider.gameObject.tag == "Droppable"){
				Droppable droppable = hit.collider.gameObject.GetComponent<Droppable>();

				if(droppable.checkAccept(item))
				{
					Debug.LogWarning ("Droppable accepted item " + item.name);

				//	character.DropItem(item);

					reject = false;
				}
				else
				{
					Debug.LogWarning ("Droppable didnt accept item " + item.name);
				}
			}			
		}


		// Send UI item back to original position
		if(reject)
		{
			gameObject.transform.position = originalPosition;
		}
	}

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		character = player.GetComponent<Character>();

		if(item != null);
		{
			itemImage = item.gameObject.GetComponent<Image>();
		}
	}

	void Update () {
	
	}



}
