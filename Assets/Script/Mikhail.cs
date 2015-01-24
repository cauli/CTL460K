using UnityEngine;
using System.Collections;

public class Mikhail : MonoBehaviour {

	public Sprite[] soundWaves;
	public SpriteRenderer waveRenderer;
	private NarrativeManager narrative;
	// Use this for initialization
	void Start () {
		narrative = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<NarrativeManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setRandomWave() {
		waveRenderer.sprite = soundWaves[Random.Range (0,soundWaves.Length)];
	}

	public void setSilentWave() {
		waveRenderer.sprite = soundWaves[0];
	}

	public void replay()
	{
		narrative.replay();
	}
}
