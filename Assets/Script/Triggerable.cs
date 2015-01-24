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

	public void Trigger () {
		if(gameObject.tag == "Window")
		{
			if(!moving)
			{
				moving = true;

				if(state == false)
				{
					state = true;
					iTween.MoveBy(gameObject, iTween.Hash("y", 4, "easeType", "easeInOutCubic", "loopType", "none", "time", 3,"oncomplete","onEnd"));
				}
				else
				{
					state = false;
					iTween.MoveBy(gameObject, iTween.Hash("y", -4, "easeType", "easeInOutCubic", "loopType", "none", "time", 3,"oncomplete","onEnd"));
				}
			}
		}
	}

	private void onEnd() {
		moving = false;
	}
}
