using UnityEngine;
using System.Collections;

public class Droppable : MonoBehaviour {


	public Item[] accepts;

	public bool destroysSelfWhenAccepted= false;


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
					GameObject.Destroy(gameObject);

					if(gameObject.name == "Parafuso")
					{
						Parafuso.removedCount++;
						if(Parafuso.removedCount == 2)
						{
							GameObject.Destroy (GameObject.Find("Tampa"));
						}
					}
				}

				return true;
			}
		}

		return false;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
