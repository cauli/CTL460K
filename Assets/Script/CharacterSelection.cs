using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelection : MonoBehaviour {

	public Image selection;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


	

		if (Input.GetButtonDown ("Fire1")) {

			if(hit.collider != null)
			{
				//Debug.Log(hit.collider.gameObject.tag);
				if(hit.collider.gameObject.tag == "Item"){
					GameObject[] selectedObjects = GameObject.FindGameObjectsWithTag("SelectedItem");
					
					foreach(GameObject obj in selectedObjects)
					{
						obj.tag = "Item";
						obj.renderer.material.color = Color.white;
					}
					
					hit.collider.gameObject.tag = "SelectedItem";
					//hit.collider.gameObject.renderer.material.color = Color.blue;
				}else if(hit.collider.gameObject.tag == "Portal"){
					//	Debug.Log ("Portal");
					
					GameObject[] selectedObjects = GameObject.FindGameObjectsWithTag("SelectedPortal");
					foreach(GameObject obj in selectedObjects)
					{
						obj.tag = "Portal";
					}
					
					hit.collider.gameObject.tag = "SelectedPortal";
				}else if(hit.collider.gameObject.tag == "Trigger")
				{
					hit.collider.gameObject.GetComponent<Trigger>().Triggered();
					Debug.Log("Trigger");
				}
				else if(hit.collider.gameObject.tag == "InventoryItem"){
					
				}
				else if(hit.collider.gameObject.tag == "Mikhail")
				{
					Mikhail mikhail = hit.collider.gameObject.GetComponent<Mikhail>();
					
					mikhail.replay();
				}
			}
		}
		else
		{
			if(hit.collider != null)
			{

				if(hit.collider.gameObject.tag == "Item" || 
				   hit.collider.gameObject.tag == "Trigger" ){
					selection.enabled = true;
					selection.transform.position = Camera.main.WorldToScreenPoint(hit.collider.transform.position);
					selection.GetComponent<RectTransform>().localRotation = hit.collider.gameObject.transform.localRotation;
				}
				else if(hit.collider.gameObject.tag == "SelectedItem")
				{
					selection.enabled = true;
					selection.transform.position = Camera.main.WorldToScreenPoint(hit.collider.transform.position);
					selection.GetComponent<RectTransform>().localRotation = hit.collider.gameObject.transform.localRotation;
				}
				else
				{
					selection.enabled = false;
				}
			}
			else
			{
				selection.enabled = false;
			}
		}
	}
}


