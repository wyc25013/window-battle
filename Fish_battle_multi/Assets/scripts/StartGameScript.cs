using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float speed = 10f;
	
	

	// Update is called once per frame
	void OnMouseDown() {
		Debug.Log ("start clicked");
		Application.LoadLevel ("castle_single");
	}
}
