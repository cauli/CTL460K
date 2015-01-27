using UnityEngine;
using System.Collections;

public class AstronautMovement : MonoBehaviour {

	public Puzzle puzzle;

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

			// TODO this was hardcoded for the left map.
			if(puzzle.originAllowedClick.x < mousePos3D.x || puzzle.currentMap.name == "MapaInicial")
			{
				iTween.MoveTo(gameObject, iTween.Hash("x", mousePos3D.x, "y", mousePos3D.y, "loopType", "none", "delay", .2, "speed", 2.3));
			}


		}
	}
}
