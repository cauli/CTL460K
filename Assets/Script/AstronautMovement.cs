using UnityEngine;
using System.Collections;

public class AstronautMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.MoveTo(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}

	void MoveTo() {
		iTween.MoveTo(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
	// Update is called once per frame
	void Update () {
		
	}
}
