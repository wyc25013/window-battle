using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballVelocity = 1000;
	private Rigidbody rb;
	
	bool isPlay; //true when the ball is moving
	int randInt; //random direction

	void Awake () {
		//when the ball is created
		rb = gameObject.GetComponent<Rigidbody> ();
		randInt = Random.Range (1, 2);
	}

	void Update () {
		if(Input.GetMouseButton(0) == true && isPlay == false){
			transform.parent = null;
			isPlay = true;
			rb.isKinematic = false;
			if(randInt == 1){
				rb.AddForce(new Vector3(ballVelocity, ballVelocity, 0));
			}
			if(randInt == 2){
				rb.AddForce(new Vector3(-ballVelocity, -ballVelocity, 0));
			}
		}
	}
}
