using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NarrativeManager : MonoBehaviour {

	public Text screenText;

	string pipe = "|";
	
	string curStr = "";

	bool isNarrating = false;

	public Mikhail mikhail;


	int narratingState = 0;

	void Start () {
		initL1();
	}

	public void initL1()
	{
		StartCoroutine(level1InitialScript ());
	}

	public void finalL1()
	{
		StartCoroutine(level1FinalScript ());
	}


	public void replay()
	{
		if(!isNarrating)
		{
			if(narratingState == 0)
			{
				initL1 ();
			}
			else if(narratingState == 1)
			{
				finalL1 ();
			}
		}
	}

	public IEnumerator level1InitialScript() 
	{
		isNarrating = true;
		setText ("MIKHAIL: Cosmonaut, I've found problem with the station.");
		yield return new WaitForSeconds(5.00f);
		setText ("MIKHAIL: I need you to look into it");
		yield return new WaitForSeconds(4.00f);
		setText ("MIKHAIL: What do we do right now?");
		yield return new WaitForSeconds(8.00f);

		deleteText ();
	}


	public IEnumerator level1FinalScript() 
	{
		isNarrating = true;
		setText ("MIKHAIL: This one was easy.");
		yield return new WaitForSeconds(5.00f);
		setText ("MIKHAIL: Let\'s see if you\'ll survive next time.");
		yield return new WaitForSeconds(8.00f);
		deleteText ();
	}


	void Update () {
		if((int)Time.fixedTime % 2 == 0)
		{
			pipe = "|";
		}
		else
		{
			pipe = "";
		}

		screenText.text = curStr + pipe; 
	}

	public void setText(string phrase){
		StartCoroutine(animateText (phrase));
	}

	public void deleteText() {
		if(mikhail != null)
		{
			mikhail.setSilentWave ();
		}

		StartCoroutine(animateErase ());
	}

	public IEnumerator animateErase()
	{
		yield return new WaitForSeconds(3.02f);

		string strComplete = curStr;

		int i = strComplete.Length;
		string str = strComplete;
		while(i > 0){


			str = str.Remove (str.Length - 1);
			i--;
			curStr = str;
			screenText.text = str + pipe;
			yield return new WaitForSeconds(0.05f);
		}

		isNarrating = false;
	}

	public IEnumerator animateText(string strComplete){
		int i = 0;
		string str = "";
		while(i < strComplete.Length){
			if(mikhail != null)
			{
				mikhail.setRandomWave ();
			}

			str += strComplete[i++];
			curStr = str;
			screenText.text = str + pipe;
			yield return new WaitForSeconds(0.02f);
		}

		if(mikhail != null)
		{
			mikhail.setSilentWave ();
		}

	}
}
