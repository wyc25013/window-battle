using UnityEngine;
using System.Collections;

public class StartGameScript2 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	public float speed = 10f;
	
	
	
	// Update is called once per frame
	void OnMouseDown() {
		Debug.Log ("start clicked");
		Application.LoadLevel ("ocean_single");
	}
}