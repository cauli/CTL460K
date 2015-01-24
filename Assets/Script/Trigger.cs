using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public Triggerable triggerable;

	public Sprite[] stateSprites;

	private bool state = false;

	public void Triggered () {
		state = triggerable.Trigger();

		setState(state);
	}

	private void setState(bool state)
	{
		if(gameObject.name == "WindowButton")
		{
			if(state == true)
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stateSprites[0];
			}
			else
			{
				gameObject.GetComponent<SpriteRenderer>().sprite = stateSprites[1];
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
