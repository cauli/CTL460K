using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer: MonoBehaviour {
	
	public Text timer;

	float minutes = 6;
	float seconds = 0;

	void Start() {
		StartCoroutine (StartTimer());
	}

	private IEnumerator StartTimer() {

		if(seconds <= 0){
			minutes--;
			seconds = 59;
		}
		else if(seconds >= 0){
			seconds--;
		}

		if(seconds < 10)
		{
			timer.text = string.Format("0{0}:0{1}", minutes, seconds);
		}
		else
		{
			timer.text = string.Format("0{0}:{1}", minutes, seconds);
		}

		if(seconds == 0 && minutes == 0)
		{
			Application.LoadLevel ("GameOver");
		}


		yield return new WaitForSeconds(1f);

		StartCoroutine (StartTimer());
	}
	void Update(){
		

	}
}

