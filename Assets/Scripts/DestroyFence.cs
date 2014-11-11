using UnityEngine;
using System.Collections;

public class DestroyFence : MonoBehaviour {

	bool bDestroy = false;
	float angle = 0;
	float step = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(bDestroy)
		{
			step += 0.015f;
			angle = Mathf.Lerp(0, -100, step);
			transform.rotation = Quaternion.Euler(0,0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision2d)
	{
		bDestroy = true;
		rigidbody2D.isKinematic = false;
		Destroy (gameObject, 3);
	}

}
