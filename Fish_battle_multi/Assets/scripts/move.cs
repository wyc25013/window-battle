using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class move : NetworkBehaviour {

	public string axis = "Horizontal";
	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isLocalPlayer) {
			transform.position += Input.GetAxis (axis) * Vector3.right * speed * Time.deltaTime;	
		}
	}
}
