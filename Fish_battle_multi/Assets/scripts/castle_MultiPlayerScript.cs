﻿using UnityEngine;
using System.Collections;

public class castle_MultiPlayerScript : MonoBehaviour {

	
	// Use this for initialization
	void Start () {
		
	}
	//public float speed = 10f;
	
	
	
	// Update is called once per frame
	void OnMouseDown() {
		Debug.Log ("multiplayer clicked");
		Application.LoadLevel ("castle_lobby");
	}
}
