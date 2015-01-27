using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puzzle : MonoBehaviour {

	public int tempo;
	public Mapa[] mapas;
	public Mapa currentMap;
	public int currentLevel = 1;
	public Vector2 originAllowedClick;
	public Vector2 allowedClick;

	public GameObject portaFinal;
	public NarrativeManager narrativeManager;

	public Text narrativeText;

	public static bool levelEnded = false;
	
	public void EndLevel() {
	
		if(currentLevel == 1)
		{
			narrativeManager.finalL1();

			iTween.MoveBy(portaFinal, iTween.Hash("y", 5, "easeType", "easeInOutCubic", "loopType", "none", "time", 1.2));

			levelEnded = true;
		}
	}
	// Use this for initialization
	void Start () {
		Puzzle.levelEnded = false;
		Parafuso.removedCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			iTween.Stop ();
			Application.LoadLevel("MainMenu");
		}	
	}

	public void setMapConfig()
	{
		if(currentMap.gameObject.name == "Mapa2")
		{
			Debug.Log("setting Map config origin to mapa 2"); 
			originAllowedClick = new Vector2(-26,0);
			narrativeText.color = new Color(245f/255f,183f/255f,43f/255f);
		}
		else
		{
			originAllowedClick = new Vector2(1000,0);
			narrativeText.color = new Color(79f/255f,39f/255f,11f/255f);
		}
	}
}
