using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	public GameObject gameOver;

	private bool isAllowedToQuit = false;
	// Use this for initialization
	void Start () {

		StartCoroutine(allowQuit ());

		iTween.MoveBy(gameOver, iTween.Hash("y",0.5f,"time",4,"looptype","pingpong","easetype","easeInOutQuad"));				
	}

	public IEnumerator autoQuit()
	{
		yield return new WaitForSeconds(4.0f);

		iTween.Stop ();
		Application.LoadLevel("MainMenu");
	}

	
	public IEnumerator allowQuit()
	{
		yield return new WaitForSeconds(3.0f);
		isAllowedToQuit = true;
		StartCoroutine(autoQuit ());
	}


	void Update () {
		if(isAllowedToQuit)
		{	
			if (Input.anyKey)
			{
				iTween.Stop ();
				Application.LoadLevel("MainMenu");
			}
		}
	
	}
}
