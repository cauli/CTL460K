using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject progressBar;

	IEnumerator LoadPlayground() {
		AsyncOperation async = Application.LoadLevelAsync("Playground");



		while(async.isDone == false) {
			float p = async.progress *100f;
			int pRounded = Mathf.RoundToInt(p);
			string perc = pRounded.ToString();

			progressBar.transform.localScale = new Vector3( Mathf.Lerp(0, 128, async.progress), progressBar.transform.localScale.y, progressBar.transform.localScale.z); 

			Debug.Log (" async.progress = " + async.progress );
			Debug.Log ("but this should do: loading level:" + perc + " %.");
			
			yield return true;
   		}


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Return) || Input.GetButtonDown ("Fire1")) {
			iTween.Stop ();

			GameObject.Find ("Instructions").gameObject.SetActive(false);

			StartCoroutine (LoadPlayground());

		}else if(Input.GetKeyUp(KeyCode.C)){
			iTween.Stop ();
			Application.LoadLevel("Credits");
		}else if(Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();
		}		
	}
}
