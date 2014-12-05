using UnityEngine;
using System.Collections;

public class blast : MonoBehaviour {

	private float startradius=0.1f;
	private float currentradius=0.1f;
	private float maxradius=12.0f;
	public float smooth=3.0f;

	// Use this for initialization
	void Start () {

		RadiusChanging();
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.GetComponent<CircleCollider2D>().radius=currentradius;

	}

	void RadiusChanging(){

		currentradius= Mathf.Lerp(startradius, maxradius, smooth * Time.deltaTime);
		Invoke("DestroyBlast",0.5f);
	}

	void DestroyBlast(){
		Destroy (gameObject);
	}
}
