using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {

	public Item item;

	private AudioSource negation;

	Image itemImage;
	Vector3 originalPosition;
	GameObject player;
	public Character character;

	bool hasDragged = false;

	public void OnPointerClick(PointerEventData eventData) {
		if(!hasDragged)
		{
			iTween.Stop();

			if(gameObject.tag != "Dropped"){
				if(item != null)
				{
					character.DropItem(item);
				}
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

		bool accepted = false;
//		Debug.Log ("DragEnd!");
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
				
					accepted = true;
				


				}
				else
				{
					Debug.LogWarning ("Droppable didnt accept item " + item.name);
				}
			}			
		}

		if(!accepted)
		{
			negation.Play ();
		}

		// Send UI item back to original position
		if(reject)
		{
			

			gameObject.transform.position = originalPosition;
		}
	}

	void Start ()
	{
		negation = gameObject.GetComponent<AudioSource>();
	}

	void Update () {
	
	}



}
