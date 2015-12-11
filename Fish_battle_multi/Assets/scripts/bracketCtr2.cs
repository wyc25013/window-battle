﻿using UnityEngine;
using System.Collections;

public class bracketCtr2 : MonoBehaviour {
	
	public float bracketSpeed = 0.5f;
	public Vector3 playerPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float yPos = gameObject.transform.position.y + (Input.GetAxis ("Vertical2") * bracketSpeed);
		float xPos = gameObject.transform.position.x + (Input.GetAxis ("Horizontal2") * bracketSpeed);
		playerPos = new Vector3 (Mathf.Clamp(xPos, 0, 30), Mathf.Clamp (yPos, -24, 24), 0);
		gameObject.transform.position = playerPos;
	}

	void OnCollisionEnter( Collision coll ) {                               // 2
		// Find out what hit this basket
		GameObject collidedWith = coll.gameObject;                          // 3
		if ( collidedWith.tag == "bonus_ball" ) {  
			if(gameObject.transform.localScale.x < 120){
				gameObject.transform.localScale *= 1.03f;
				BoxCollider collider = GetComponent<BoxCollider>();
				collider.size *= 1.03f;
			}
			Destroy( collidedWith );
			
		}
		if ( collidedWith.tag == "punish_ball" ) {  
			gameObject.transform.localScale /= 1.08f;
			BoxCollider collider = GetComponent<BoxCollider>();
			collider.size /= 1.03f;
			Destroy( collidedWith );
		}
		
		// Parse the text of the scoreGT into an int
		//		int score = int.Parse( scoreGT.text );                              // 4
		// Add points for catching the apple
		//		score += 100;
		// Convert the score back to a string and display it
		//		scoreGT.text = score.ToString();
		
		// Track the high score
		//		if (score > HighScore.score) {
		//			HighScore.score = score;
		//		}
	}
}
