using UnityEngine;
using System.Collections;

public class rotate_light : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}	
	// Update is called once per frame
	void Update() {
		transform.Rotate(0, 0.7f, 0.7f);
	}
}