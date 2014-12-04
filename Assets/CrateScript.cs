using UnityEngine;
using System.Collections;

public class CrateScript : MonoBehaviour {

	private Vector3 startPosition = new Vector3(0,2.5f,0);
	public Sprite crate_1_image;
	public Sprite crate_2_image;
	public Sprite crate_3_image;
	public Sprite crate_4_image;
	public Sprite crate_5_image;
	public Transform source;
	private string cratetype; 
	private ForceMode2D forceMode = ForceMode2D.Impulse;
	private float torque = (Random.Range(-20.0f,20.0f)/10.0f);
	private bool justhit = false;
	private bool onscreen = false;
	private bool craterotate=false;
	public bool dropping = false;
	public GameObject explosion;
	public GameObject Blast;
	public GameObject astroguy;


	// Use this for initialization and this is a test comment
	void Start () {
		transform.position=startPosition;
		//gameObject.GetComponent.<Rigidbody2D>().gravityScale = 0;
		gameObject.GetComponent<SpriteRenderer>().rigidbody2D.gravityScale = 0;
	
	}

	void OnEnable(){
		IT_Gesture.onSwipeStartE += OnSwipeStart;
		IT_Gesture.onSwipeEndE += OnSwipeEnd;
		
		IT_Gesture.onSwipeE += OnSwipe;
		
		IT_Gesture.onSwipingE += OnSwiping;

	}

	public void SetType(string t)
	{	
		cratetype=t;
		switch (t)
		{

		case "crate1": // if a is an integer
			gameObject.GetComponent<SpriteRenderer>().sprite = crate_1_image;
			break;
		case "crate2": // if a is an integer
			gameObject.GetComponent<SpriteRenderer>().sprite = crate_2_image;
			break;
		case "crate3": // if a is an integer
			gameObject.GetComponent<SpriteRenderer>().sprite = crate_3_image;
			break;
		case "crate4": // if a is an integer
			gameObject.GetComponent<SpriteRenderer>().sprite = crate_4_image;
			break;
		case "crate5": // if a is an integer
			gameObject.GetComponent<SpriteRenderer>().sprite = crate_5_image;
			break;
		}
	}

	// Update is called once per frame
	void Update ()
	{	
		if (craterotate)
			rigidbody2D.AddTorque(torque);
		
		if (transform.position.y < -2)
		{
			destroy();
		}


		
	}


	void OnSwipeStart(SwipeInfo sw){

	}

	void OnSwipe(SwipeInfo sw)
	{	
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit2d =  Physics2D.Raycast(pos, Vector2.zero);

	
		if (hit2d != null && hit2d.collider != null && hit2d.transform.gameObject == gameObject)
		{
			Debug.Log ("I'm hitting "+hit2d.collider);
	
			justhit=true;
		}

	}

	void OnSwiping(SwipeInfo sw){
		if (onscreen && !justhit)
		{
			StopDrop();
			dropping=false;
			if (sw.direction.x < 0)
			{
				rigidbody2D.AddForce(new Vector2(-3.8f,0), forceMode);
			}
			if (sw.direction.x > 0)
			{
				rigidbody2D.AddForce(new Vector2(3.8f,0), forceMode);
			}
			justhit = true;
		}
	}

	//when a swipe has end, valid or not
	void OnSwipeEnd(SwipeInfo sw)
	{
	

	}
	


	public void Drop()
	{
		dropping=true;
		transform.position = new Vector3(0,1.5f,0);
		rigidbody2D.gravityScale = 0.3f;
		craterotate=true;
		onscreen = true;
	}

	public void StopDrop()
	{

		rigidbody2D.gravityScale = 0.0f;
		onscreen = true;
		craterotate=false;
	}

	public void GroundHit()
	{
		Debug.Log("hit ground");
		if (cratetype == "crate1")
		{
			Invoke("Explode",0.3f);
		}
		else if (cratetype == "crate2")
		{
			Invoke("OpenCrate",1f);
		}

	}

	public void OpenCrate()
	{
		GameObject astro = Instantiate(astroguy, transform.position, Quaternion.identity) as GameObject;


		 destroy();
	}

	public void Explode()
	{

		renderer.enabled=false;
		GameObject explo = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
		GameObject blast = Instantiate(Blast, transform.position, Quaternion.identity) as GameObject;
		Invoke("destroy",0.5f);
	}



	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
		{
			StopMoving();
		}
		
	}
	
	void StopMoving(){
		
		rigidbody2D.velocity = Vector2.zero;
		
		rigidbody2D.angularVelocity = 0f; 
	}

	public void destroy()
	{
		Debug.Log ("destroy...");
		IT_Gesture.onSwipeStartE -= OnSwipeStart;
		IT_Gesture.onSwipeEndE -= OnSwipeEnd;
		
		IT_Gesture.onSwipeE -= OnSwipe;
		
		IT_Gesture.onSwipingE -= OnSwiping;
		onscreen = false;
		
		Destroy(gameObject);

	}



}
