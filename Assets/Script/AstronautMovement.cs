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

			iTween.MoveTo(gameObject, iTween.Hash("x", mousePos3D.x, "y", mousePos3D.y, "easeType", "easeInOutCubic", "loopType", "none", "delay", .2, "speed", 2.3));

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider != null)
			{
				if(hit.collider.gameObject.tag == "Item"){
					Debug.Log ("Item");
					GameObject[] selectedObjects = GameObject.FindGameObjectsWithTag("SelectedItem");
					
					foreach(GameObject obj in selectedObjects)
					{
						obj.tag = "Item";
						obj.renderer.material.color = Color.white;
					}
					
					hit.collider.gameObject.tag = "SelectedItem";
					hit.collider.gameObject.renderer.material.color = Color.blue;
				}else if(hit.collider.gameObject.tag == "Portal"){
					Debug.Log ("Portal");

					GameObject[] selectedObjects = GameObject.FindGameObjectsWithTag("SelectedPortal");
					foreach(GameObject obj in selectedObjects)
					{
						obj.tag = "Portal";
					}

					hit.collider.gameObject.tag = "SelectedPortal";
				}

			}
		}
	}
}
