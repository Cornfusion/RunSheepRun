using UnityEngine;
using System.Collections;

public class BG_Looper : MonoBehaviour {

	int numBGPanels = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		float widthOfBGPanel = ((BoxCollider2D)collider).size.x;

		Vector3 newPos = collider.transform.position;

		newPos.x += (widthOfBGPanel * numBGPanels + widthOfBGPanel*1) - 0.1f;

		collider.transform.position = newPos;
	}
}
