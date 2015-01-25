using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Return) || Input.GetButtonDown ("Fire1")) {
			iTween.Stop ();
			Application.LoadLevel("Playground");
		}else if(Input.GetKeyUp(KeyCode.C)){
			iTween.Stop ();
			Application.LoadLevel("Credits");
		}else if(Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();
		}		
	}
}
