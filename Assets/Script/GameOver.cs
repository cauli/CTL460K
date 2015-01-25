using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		StartCoroutine(autoQuit ());

		iTween.MoveBy(gameOver, iTween.Hash("y",0.5f,"time",4,"looptype","pingpong","easetype","easeInOutQuad"));				
	}

	public IEnumerator autoQuit()
	{
		yield return new WaitForSeconds(7.0f);
		Application.LoadLevel("MainMenu");
	}

	void Update () {
		if (Input.anyKey)
			Application.LoadLevel("MainMenu");
	}
}
