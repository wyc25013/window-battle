using UnityEngine;
using System.Collections;

public class bonus_tut : MonoBehaviour {
	
	// Prefab for instantiating apples
	public GameObject   bonusPrefab;
	
	// Speed at which the AppleTree moves in meters/second
	public float        speed = 5f;
	
	// Distance where AppleTree turns around
	public float        leftAndRightEdge = 50f;
	
	// Chance that the AppleTree will change directions
	public float        chanceToChangeDirections = 0.2f;
	
	// Rate at which Apples will be instantiated
	public float        secondsBetweenBonusDrops = 4f;
	
	// Use this for initialization
	void Start () {
		// Dropping apples every second
		InvokeRepeating( "DropBonus", 2f, secondsBetweenBonusDrops );
	}
	
	void DropBonus() {
		GameObject bonus = Instantiate( bonusPrefab ) as GameObject;
		bonus.transform.position = transform.position;
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
