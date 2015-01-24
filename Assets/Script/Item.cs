using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.rigidbody2D.AddTorque(50);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
