using UnityEngine;
using System.Collections;

public class Parafuso : MonoBehaviour {

	public Item[] parafusadeiras;
	public Sprite[] parafusos;
	public static int removedCount = 0;

	void Start () {
		int index = Random.Range (0,parafusadeiras.Length);

		Item parafusadeira = parafusadeiras[index];

		gameObject.GetComponent<SpriteRenderer>().sprite = parafusos[index];

		gameObject.GetComponent<Droppable>().accepts[0] = parafusadeira;
	}

	void Update () {
	
	}
}
