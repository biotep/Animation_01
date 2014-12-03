using UnityEngine;
using System.Collections;

public class leftwallscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		rigidbody2D.AddForce(new Vector2(-232f, 0));
	}
}
