using UnityEngine;
using System.Collections;

public class SpawnFence : MonoBehaviour {
	
	public GameObject fence;

	private float spawnTimer;
	
	// Use this for initialization
	void Start () 
	{
		spawnTimer = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnTimer -= Time.deltaTime;

		if(spawnTimer < 0)
		{
			
			spawnTimer = Random.Range (2,6);

			Instantiate(fence, transform.position, transform.rotation);
		}
	}
}
