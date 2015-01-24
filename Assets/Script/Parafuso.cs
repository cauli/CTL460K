using UnityEngine;
using System.Collections;

public class Parafuso : MonoBehaviour {

	public Item[] parafusadeiras;
	public Sprite[] parafusos;

	// Use this for initialization
	void Start () {

		int index = Random.Range (0,parafusadeiras.Length);
		Item parafusadeira = parafusadeiras[index];

		gameObject.GetComponent<SpriteRenderer>().sprite = parafusos[index];

		gameObject.GetComponent<Droppable>().accepts[0] = parafusadeira;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
