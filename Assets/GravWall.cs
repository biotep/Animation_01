using UnityEngine;
using System.Collections;

public class GravWall : MonoBehaviour {

	private ForceMode2D forcemode = ForceMode2D.Impulse;
	
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
		if ( other.GetComponent<CrateScript>().dropping == false)
		{
			if (other.transform.position.x > 0)
			{
				other.GetComponent<Rigidbody2D>().AddForce(new Vector2(20f,0f), forcemode);
			}
			else
			{
				other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20f,0f), forcemode);
			}
			
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
