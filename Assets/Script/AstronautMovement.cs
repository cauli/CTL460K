using UnityEngine;
using System.Collections;

public class AstronautMovement : MonoBehaviour {

	void Start () {
		Debug.Log ("Start");
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 mousePos2D = Input.mousePosition;
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);


			// Get Angle in Radians
			float AngleRad = Mathf.Atan2(mousePos3D.y - gameObject.transform.position.y, mousePos3D.x - gameObject.transform.position.x);
			// Get Angle in Degrees
			float AngleDeg = (180 / Mathf.PI) * AngleRad;
			// Rotate Object

			if(Mathf.Abs (AngleDeg) > 100)
			{
				this.transform.localScale = new Vector3(-1, 1, 1);
				this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 240);
			}
			else
			{		
				this.transform.localScale = new Vector3(1, 1, 1);
				this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg - 46);
			}

			iTween.MoveTo(gameObject, iTween.Hash("x", mousePos3D.x, "y", mousePos3D.y, "loopType", "none", "delay", .2, "speed", 2.3));

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
//				Debug.Log(hit.collider.gameObject.tag);
				if(hit.collider.gameObject.tag == "Item"){
					GameObject[] selectedObjects = GameObject.FindGameObjectsWithTag("SelectedItem");
					
					foreach(GameObject obj in selectedObjects)
					{
						obj.tag = "Item";
						obj.renderer.material.color = Color.white;
					}
					
					hit.collider.gameObject.tag = "SelectedItem";
					hit.collider.gameObject.renderer.material.color = Color.blue;
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
					Debug.Log("HUEHEUHEUHEUUHE");
				}
				else if(hit.collider.gameObject.tag == "Mikhail"){

					//Debug.Log("Clicked Mikhail");
					Mikhail mikhail = hit.collider.gameObject.GetComponent<Mikhail>();

					mikhail.replay();
				}
			}
		}
	}
}
