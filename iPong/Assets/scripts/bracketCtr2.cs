using UnityEngine;
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
		playerPos = new Vector3 (Mathf.Clamp(xPos, 0, 15), Mathf.Clamp (yPos, -11, 11), 0);
		gameObject.transform.position = playerPos;
	}
}
