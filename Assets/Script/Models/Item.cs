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


		if(gameObject.name == "Adesivo")
		{
			iTween.MoveBy(gameObject, iTween.Hash("y",0.3f,"time",4,"looptype","pingpong","easetype","easeInOutQuad"));		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
