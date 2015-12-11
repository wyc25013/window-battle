using UnityEngine;
using System.Collections;

public class ReStartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClicked() {
		Debug.Log ("start clicked");
		Application.LoadLevel ("castle_single");
	}
}
