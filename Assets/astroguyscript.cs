using UnityEngine;
using System.Collections;

public class astroguyscript : MonoBehaviour {

	private ForceMode2D forceMode = ForceMode2D.Impulse;
	private ForceMode2D grav = ForceMode2D.Force;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float k = Mathf.Sign(transform.position.x);
		rigidbody2D.AddForce(new Vector2((9.81f*k), 0.0f), grav);
	}

	void Update()
	{
		float k = Mathf.Sign(transform.position.x);
		transform.rotation = Quaternion.AngleAxis((90f*k), Vector3.forward);

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
		{

			if (coll.transform.position.x < transform.position.x)
			{
				Debug.Log ("collision of astroguy");
				transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
			}
			else if (coll.transform.position.x > transform.position.x)
			{
				Debug.Log ("collision of astroguy");
				transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
			}


			StopMoving();
		}
		
	}

	void StopMoving(){

		rigidbody2D.velocity = Vector2.zero;

		rigidbody2D.angularVelocity = 0f; 
	}
}
