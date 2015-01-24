using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public Triggerable triggerable;

	public void Triggered () {
		triggerable.Trigger();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
