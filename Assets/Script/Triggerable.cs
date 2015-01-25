using UnityEngine;
using System.Collections;

public class Triggerable : MonoBehaviour {


	public bool state = false;
	public bool moving = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool Trigger () {
		if(gameObject.tag == "Window")
		{
			if(!moving)
			{
				moving = true;

				if(state == false)
				{
					gameObject.GetComponent<AudioSource>().Play();
					state = true;
					iTween.MoveBy(gameObject, iTween.Hash("y", 4, "easeType", "easeInOutCubic", "loopType", "none", "time", 1.2,"oncomplete","onEnd"));
					return false;
				}
				else
				{
					gameObject.GetComponent<AudioSource>().Play();
					state = false;
					iTween.MoveBy(gameObject, iTween.Hash("y", -4, "easeType", "easeInOutCubic", "loopType", "none", "time", 1.2,"oncomplete","onEnd"));
					return true;
				}
			}
			else
			{
				return !state;
			}
		}
		else
		{
			return !state;
		}
	}

	private void onEnd() {
		moving = false;
	}
}
