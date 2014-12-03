using UnityEngine;
using System.Collections;

public class Gravblock : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Crate")
		{
			Debug.Log("Object entered trigger");
			//other.GetComponent<CrateScript>().StopDrop();
			//other.GetComponent<Rigidbody2D>().AddForce(new Vector2(2.0f,0));
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Crate"  && other.GetComponent<CrateScript>().dropping == false)
		{
			Debug.Log("Object is in trigger");
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f,0f));
			// Here you add negative forces to object that is within the fan area
			// Other is the object, that should be pushed away
			//			Vector2 position = transform.position;
			//			Vector2 targetPosition = other.transform.position;
			//			Vector2 direction = targetPosition - position;
			//			direction.Normalize();
			//			int moveSpeed = 10;
			
			//other.transform.position += direction * moveSpeed * Time.deltaTime;
		}
		
	}
	
	
	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("Object left the trigger");
	}
	
	
}
