using UnityEngine;
using System.Collections;

public class SheepMovement : MonoBehaviour {

	//Vector3 velocity = Vector3.zero;
	Vector3 tempVelocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 jumpVelocity;
	public float jumpHeight;
	public float jumpStride;

	public float forwardSpeed = 1.0f;
	private float defaultForwardSpeed;
	public float maxSpeed;

	bool bJump = false;



	//Scores???
	int fencesHit = 0;

	// Use this for initialization
	void Start () 
	{
		fencesHit = 0;
		defaultForwardSpeed = forwardSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//When the player presses the jump key
		//Set jump to true
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			bJump = true;
		}


	}

	void FixedUpdate () 
	{
		//Decrease forward speed to default
		if(forwardSpeed > defaultForwardSpeed)
		{
			forwardSpeed -= 2.0f * Time.deltaTime;
		}
		//Increase forward speed to default
		if(forwardSpeed < defaultForwardSpeed)
		{
			forwardSpeed += 2.0f * Time.deltaTime;
		}

		//Set the forward speed at a constant rate.
		//velocity.x = forwardSpeed;
		tempVelocity = rigidbody2D.velocity;
		tempVelocity.x = forwardSpeed;
		rigidbody2D.velocity = tempVelocity;


		//Reduce the players velocity by gravity
		//velocity -= gravity * Time.deltaTime;

		//if the player has pressed the jump button
		//
		if(bJump == true)
		{
			bJump = false;
			rigidbody2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
			forwardSpeed += 2;

			//velocity = Vector3.zero;
			//velocity.x = forwardSpeed;
			//velocity += jumpVelocity;
		}




		//Update the position to move the sheep
		//transform.position += velocity * Time.deltaTime;

		float angle = 0;

		if (rigidbody2D.velocity.y < 0) 
		{			
			angle = Mathf.Lerp(0, -25, -rigidbody2D.velocity.y / maxSpeed);
		}
		else
		{
			angle = Mathf.Lerp(0, +25, rigidbody2D.velocity.y / maxSpeed);
		}

		transform.rotation = Quaternion.Euler(0,0, angle);
	}

	void OnCollisionEnter2D(Collision2D collision2d)
	{
		if(collision2d.transform.tag == "Fence")
		{
			++fencesHit;
			Debug.Log ("Fences hit: " + fencesHit);
			forwardSpeed -= 1;

			//Disable both colliders
			collision2d.collider.enabled = false;
			collision2d.gameObject.collider2D.enabled = false;
			//break fence
		}
	}
}
