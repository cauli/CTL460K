using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.rigidbody2D.AddTorque(Random.Range(-20,20));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
