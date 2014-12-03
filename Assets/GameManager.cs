using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	private Every dropObject;

	// Use this for initialization
	void Start () {

		dropObject = new Every(3f); // Every 2000 ms
		//dropObject.IsTriggered = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (dropObject.IsTriggered)
		{
			DropNewObject();
		}
	}

	public void DropNewObject()
	{
		if (FallingObjectFactoryScript.fallingobjectpool.Count > 0)
		{
			foreach (KeyValuePair<int,GameObject> pair in FallingObjectFactoryScript.fallingobjectpool)
			{
				if ( pair.Value!=null)
				{
					GameObject dropit = pair.Value;
					dropit.GetComponent<CrateScript>().Drop();
					FallingObjectFactoryScript.fallingobjectpool.Remove(pair.Key);
					break;
				}
			}
		}
		else
		{
			Debug.Log("no more element in fallingobjectpool");
		}	
	}	
}
