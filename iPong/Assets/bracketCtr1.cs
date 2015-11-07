using UnityEngine;
using System.Collections;

public class bracketCtr1 : MonoBehaviour {

	public float bracketSpeed = 1;
	public Vector3 playerPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float yPos = gameObject.transform.position.y + (Input.GetAxis ("Vertical1") * bracketSpeed);
		float xPos = gameObject.transform.position.x + (Input.GetAxis ("Horizontal1") * bracketSpeed);
		playerPos = new Vector3 (Mathf.Clamp(xPos, -5, 0), Mathf.Clamp (yPos, -11, 11), 0);
		gameObject.transform.position = playerPos;
	}
}
