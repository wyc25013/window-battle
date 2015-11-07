using UnityEngine;
using System.Collections;

public class bracketCtr : MonoBehaviour {

	public float bracketSpeed = 1;
	public Vector3 playerPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float yPos = gameObject.transform.position.y + (Input.GetAxis ("Vertical") * bracketSpeed);
		playerPos = new Vector3 (-5, Mathf.Clamp (yPos, -11, 11), 0);
		gameObject.transform.position = playerPos;
	}
}
