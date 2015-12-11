using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ball_sync_pos : NetworkBehaviour {

	[SyncVar]
	private Vector3 sycPos;

	public float ballVelocity = 1000f;
	//	[SyncVar]
	private Rigidbody rb;
	//	[SyncVar]
	bool isPlay; //true when the ball is moving
	//	[SyncVar]
	//int randInt; //rand

	[SerializeField] Transform myTran;
	[SerializeField] float lerpRate = 15;

	void Awake () {
		//when the ball is created
		rb = gameObject.GetComponent<Rigidbody> ();
		//randInt = Random.Range (1, 2);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isPlay == false){
			transform.parent = null;
			isPlay = true;
			rb.isKinematic = false;
//			if(randInt == 1){
//				rb.AddForce(new Vector3(ballVelocity, ballVelocity, 0));
//			}
			//if(randInt == 2){
				rb.AddForce(new Vector3(-ballVelocity, -ballVelocity, 0));
			//}
		}
		TransmitPos ();
		LerpPos ();
	}

	void LerpPos(){
		if (!isLocalPlayer) {
			myTran.position = Vector3.Lerp (myTran.position, sycPos, Time.deltaTime * lerpRate);
			Debug.Log("is not Local");
			Debug.Log(myTran.position);
		}
	}

	[Command]
	void CmdProvidePosToServer(Vector3 pos){
		sycPos = pos;
	}

	[ClientCallback]
	void TransmitPos(){
		if (isLocalPlayer) {
			CmdProvidePosToServer (myTran.position);
			Debug.Log("is Local");
			Debug.Log(myTran.position);

		}
	}
}
