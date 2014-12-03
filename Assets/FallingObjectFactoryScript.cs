using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FallingObjectFactoryScript : MonoBehaviour {

	private Every dropObject;
	private Transform closest;
	public GameObject crate;
	private string[] objecttypes = {"crate1","crate2","crate3","crate4","crate5"};
	public static Dictionary<int, GameObject> fallingobjectpool = new Dictionary<int, GameObject>();
	private int num_objects;


	void Start()
	{
		CreateObjectPool();

	}
	
	void Update()
	{


	}

	private void CreateObjectPool()
	{
		while (fallingobjectpool.Count < 10)
		{
			string t = objecttypes[Random.Range(0,5)];
			fallingobjectpool.Add(fallingobjectpool.Count,(CreateNewObject(t)));
		}
	}


	private GameObject CreateNewObject(string t)
	{
		GameObject go = Instantiate(crate, new  Vector3(0,0,0), Quaternion.identity) as GameObject;
		go.GetComponent<CrateScript>().SetType(t);
		go.transform.position=new Vector3(0,4,0);
		return go;
	}



}
