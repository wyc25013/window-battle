using UnityEngine;
using System.Collections;


public class punish : MonoBehaviour {
	
	// Prefab for instantiating apples
	public GameObject   punishPrefab;
	
	// Speed at which the AppleTree moves in meters/second
	public float        speed = 5f;
	
	// Distance where AppleTree turns around
	public float        leftAndRightEdge = 50f;
	
	// Chance that the AppleTree will change directions
	public float        chanceToChangeDirections = 0.2f;
	
	// Rate at which Apples will be instantiated
	public float        secondsBetweenPunishDrops = 2f;
	
	// Use this for initialization
	void Start () {
		// Dropping apples every second
		InvokeRepeating( "DropPunish", 4f, secondsBetweenPunishDrops );
	}
	
	void DropPunish() {
		GameObject punish = Instantiate( punishPrefab ) as GameObject;
		punish.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Basic Movement
		Vector3 pos = transform.position;
		pos.x += 10 * speed * Time.deltaTime;
		transform.position = pos;
		// Changing Direction
		if ( pos.x < -leftAndRightEdge ) {
			speed = Mathf.Abs(speed);  // Move right
		} else if ( pos.x > leftAndRightEdge ) {
			speed = -Mathf.Abs(speed); // Move left
		}
	}
	
	void FixedUpdate(){
		// Changing Direction Randomly
		if ( Random.value < chanceToChangeDirections ) {
			speed *= -1;  // Change direction
		}
	}	
}
