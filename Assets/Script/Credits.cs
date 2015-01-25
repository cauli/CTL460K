using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject credits;

	// Use this for initialization
	void Start () {
		animateCredits ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey)
			Application.LoadLevel("MainMenu");
	}

	void animateCredits(){
		iTween.MoveTo(credits, iTween.Hash("y", 36.6f,"time",15,"easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
	}
}	
