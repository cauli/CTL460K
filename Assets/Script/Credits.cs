using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public GameObject credits;
	
	private bool isAllowedToQuit = false;

	void Start () {
		StartCoroutine(allowQuit ());

		animateCredits ();
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

	public IEnumerator allowQuit()
	{
		yield return new WaitForSeconds(3.0f);
		isAllowedToQuit = true;
	}


	void animateCredits(){
		iTween.MoveTo(credits, iTween.Hash("y", 36.6f,"time",15,"easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop));
	}

}	
