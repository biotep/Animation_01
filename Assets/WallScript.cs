


using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Crate" )
		{
//
			other.gameObject.GetComponent<CrateScript>().GroundHit();
//
//
//			
//			// Here you add negative forces to object that is within the fan area
//			// Other is the object, that should be pushed away
//			//			Vector2 position = transform.position;
//			//			Vector2 targetPosition = other.transform.position;
//			//			Vector2 direction = targetPosition - position;
//			//			direction.Normalize();
//			//			int moveSpeed = 10;
//			
//			//other.transform.position += direction * moveSpeed * Time.deltaTime;
		}
		
	}
}
