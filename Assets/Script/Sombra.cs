using UnityEngine;
using System.Collections;

public class Sombra : MonoBehaviour {

	private float initY;
	public GameObject followWho;

	// Use this for initialization
	void Start () {
		initY = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.color = new Color(1,1,1, getOpacity() );
		gameObject.transform.position = new Vector3(followWho.transform.position.x, initY, followWho.transform.position.z);

		float scale = getScale();
		gameObject.transform.localScale = new Vector3 (15.0f * scale, 1.5f * scale,scale);
	}

	private float getOpacity() {
		return Mathf.Lerp(0.0f, 0.8f, followWho.transform.position.y + 0.5f);
	}

	private float getScale() {
		return Mathf.Lerp(0.5f, 1f, followWho.transform.position.y + 0.5f);
	}
}
