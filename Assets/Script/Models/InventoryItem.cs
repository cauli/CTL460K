using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {

	public Item item;

	Image itemImage;
	Vector3 originalPosition;
	GameObject player;
	Character character;

	bool hasDragged = false;

	public void OnPointerClick(PointerEventData eventData) {
		if(!hasDragged)
		{
			iTween.Stop();
			Debug.Log ("Drop! TALLES BUURROO");

			if(gameObject.tag != "Dropped"){
				character.DropItem(item);
			}
		}
	}

	public void OnBeginDrag (PointerEventData pointerEventData) {
		originalPosition = gameObject.transform.position;
		iTween.Stop();
	}

	public void OnDrag(PointerEventData pointerEventData) {
		hasDragged = true;
		gameObject.transform.position = new Vector3(pointerEventData.position.x, pointerEventData.position.y);
	}

	public void OnEndDrag(PointerEventData pointerEventData) {
		hasDragged = false;

		Debug.Log ("DragEnd!");
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		bool reject = true;

		if(hit.collider != null)
		{

			if(hit.collider.gameObject.tag == "Droppable"){
				Droppable droppable = hit.collider.gameObject.GetComponent<Droppable>();

				if(droppable.checkAccept(item))
				{
					Debug.LogWarning ("Droppable accepted item " + item.name);

					iTween.MoveTo(character.gameObject, iTween.Hash("x", droppable.transform.position.x, "y", droppable.transform.position.y, "easeType", 
					                                                "easeInOutCubic", "loopType", "none", "delay", .2, "speed", 2.3));
				//	character.DropItem(item);

					reject = false;
					gameObject.tag = "Dropped";
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

		if(item.gameObject != null);
		{
			itemImage = item.gameObject.GetComponent<Image>();
		}
	}

	void Update () {
	
	}



}
