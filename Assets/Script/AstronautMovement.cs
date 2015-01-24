using UnityEngine;
using System.Collections;

public class AstronautMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//iTween.MoveTo(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}

	void MoveTo() {
		//iTween.MoveTo(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Fire1")) {

			Vector3 mousePos2D = Input.mousePosition;
			
			iTween.MoveTo(gameObject, iTween.Hash("x", mousePos2D.x, "y", mousePos2D.y, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));

			// Construct a ray from the current mouse coordinates
			/*var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray)) {
				// Create a particle if hit
				Instantiate (particle, transform.position, transform.rotation);
			}*/
		}
	}
}
