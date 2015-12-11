using UnityEngine;
using System.Collections;

public class Back_to_menu : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseDown() {
		Debug.Log ("menu clicked");
		Application.LoadLevel ("GameRule");
	}
}
