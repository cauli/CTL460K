using UnityEngine;
using System.Collections;

public class Droppable : MonoBehaviour {

	public Sprite sprite;

	public Item[] accepts;

	public bool destroysSelfWhenAccepted= false;

	public Puzzle puzzle;


	// Checks if this droppable accepts
	// the item dragged to it
	public bool checkAccept(Item droppedItem)
	{
		foreach(Item item in accepts)
		{
			if(item == droppedItem)
			{
				if(destroysSelfWhenAccepted)
				{
				

					if(gameObject.name == "Parafuso")
					{
						gameObject.GetComponent<AudioSource>().Play();

						StartCoroutine(RotateAndDestroy());

						Parafuso.removedCount++;

						if(Parafuso.removedCount == 2)
						{
							GameObject.Find("Caixa").GetComponent<AudioSource>().Play ();
							GameObject.Find("Caixa").GetComponent<ParticleSystem>().Play();
							GameObject.Destroy (GameObject.Find("Tampa"));
						}
					}

			

				}else if(gameObject.name == "Caixa"){

					if(Parafuso.removedCount >= 2)
					{
						// Arrumou a caixa com o adesivo
						
						GameObject.Find("Caixa").GetComponent<ParticleSystem>().Stop ();
						SpriteRenderer spriteCaixa = gameObject.gameObject.GetComponent<SpriteRenderer>();
						spriteCaixa.sprite = sprite;
						
						puzzle.EndLevel();
					}


				}

				return true;
			}
		}

		return false;
	}

	private IEnumerator RotateAndDestroy() 
	{
		iTween.RotateBy(gameObject, new Vector3(0,0,980), 2);

		yield return new WaitForSeconds(1.50f);
		iTween.FadeTo(gameObject, 0, 0.5f);
		yield return new WaitForSeconds(5f);
		GameObject.Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		puzzle = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Puzzle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
