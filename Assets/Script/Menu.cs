using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Return)) {
			Application.LoadLevel("Playground");
		}else if(Input.GetKeyUp(KeyCode.C)){
			Application.LoadLevel("Credits");
		}else if(Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();
		}		
	}
}
