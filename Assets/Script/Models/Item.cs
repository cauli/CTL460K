using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public Item[] possibleCombinations;
	public string description;
	public bool startsWithTrigger = false;
	// Use this for initialization
	void Start () {
		startsWithTrigger = gameObject.collider2D.isTrigger;
		gameObject.rigidbody2D.AddTorque(Random.Range(-2,1));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
