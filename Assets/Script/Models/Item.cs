using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public Item[] possibleCombinations;
	public string description;

	// Use this for initialization
	void Start () {
		gameObject.rigidbody2D.AddTorque(Random.Range(-1,1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
