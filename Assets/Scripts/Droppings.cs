using UnityEngine;
using System.Collections;

public class Droppings : MonoBehaviour {

	public GameObject dropping;
	private float currentTime;

	bool bDropComplete = true;
	int numOfDrops = 0;
	// Use this for initialization
	void Start () 
	{
		currentTime = Random.Range (1, 10);
		numOfDrops = Random.Range(3, 26);
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentTime -= Time.deltaTime;

		//when the timer reaches 0
		//get a random number of droppings
		//turn droppings on
		if(currentTime < 0)
		{
			currentTime = 100;
			bDropComplete = false;
		}

		//if all of the droppings have been dropped
		//turn droppings off
		if(numOfDrops <= 0)
		{
			bDropComplete = true;
			currentTime = Random.Range (1, 10);			
			numOfDrops = Random.Range(3, 18);
		}

		if(!bDropComplete && numOfDrops > 0)
		{
			--numOfDrops;
			Instantiate(dropping, transform.position, Quaternion.identity);
		}


	}
}
