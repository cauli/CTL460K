using UnityEngine;
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
		}
		else
		{
			originAllowedClick = new Vector2(1000,0);
		}
	}
}
