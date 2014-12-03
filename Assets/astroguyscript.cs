using UnityEngine;
using System.Collections;

public class astroguyscript : MonoBehaviour {

	private ForceMode2D forceMode = ForceMode2D.Impulse;

	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce(new Vector2(-0.2f,0), forceMode);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	
	}

	void Update()
	{
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
		{
			Debug.Log ("collision");
			StopMoving();
		}
		
	}

	void StopMoving(){

		rigidbody2D.velocity = Vector2.zero;

		rigidbody2D.angularVelocity = 0f; 
	}
}
