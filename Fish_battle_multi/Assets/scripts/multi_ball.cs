using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class multi_ball : NetworkBehaviour {
	
	//public float ballVelocity = 1000;
//	[SyncVar]
	public float ballVelocity = 500f;
//	[SyncVar]
	private Rigidbody rb;
	[SyncVar]
	bool isPlay; //true when the ball is moving
//	[SyncVar]
	//int randInt; //random direction
	[SyncVar]
	private int left_count = 100;
	[SyncVar]
	private int right_count = 100;

	private TextMesh textObject_left;
	private TextMesh textObject_right;
	Text GameOverText;
	Text Left;
	Text Right;

//	void Awake(){
//		CmdAwake ();
//	}
//	[Command]
	void Awake () {
		textObject_left = GameObject.Find("Score_left").GetComponent<TextMesh>();
		textObject_right = GameObject.Find("Score_right").GetComponent<TextMesh>();
		textObject_left.text = "Your Score: " + left_count.ToString ();
		textObject_right.text = "Your Score: " + right_count.ToString ();
		GameOverText = GameObject.Find("Text").GetComponent<Text>(); 
		Left = GameObject.Find("Left_text").GetComponent<Text>(); 
		Right = GameObject.Find("Right_text").GetComponent<Text>();
		//when the ball is created
		rb = gameObject.GetComponent<Rigidbody> ();
		//randInt = Random.Range (1, 2);
		//rb.AddForce(new Vector3(ballVelocity, ballVelocity, 0));

	}

//	void Update(){
//		CmdUpdate ();
//	}
	//[Command]
	void Update () {
		if(isPlay == false){
			transform.parent = null;
			isPlay = true;
			rb.isKinematic = false;
		
			rb.AddForce(new Vector3(ballVelocity, ballVelocity, 0));
		}
		
		
		if (Mathf.Abs(rb.position.x) >= 30 ||Mathf.Abs(rb.position.y) >= 22) {
			rb.position = Vector3.zero;
			rb.velocity = Vector3.zero;
			rb.AddForce(new Vector3(ballVelocity, ballVelocity, 0));
		}
		
		if (Mathf.Abs (rb.velocity.x) > 1.5f*ballVelocity || Mathf.Abs(rb.velocity.y) > 1.5f*ballVelocity) {
			rb.position = Vector3.zero;
			rb.velocity = Vector3.zero;
			rb.AddForce(new Vector3(ballVelocity, ballVelocity, 0));
		}
		if ( Mathf.Abs(rb.velocity.x) <= 0.1f || Mathf.Abs (rb.velocity.y) <= 0.1f) {
			rb.position = Vector3.zero;
			rb.velocity = Vector3.zero;
			rb.AddForce(new Vector3(ballVelocity, ballVelocity, 0));
		}

		if(!isServer){
			textObject_left.text = "Your Score: " + left_count.ToString ();
			textObject_right.text = "Your Score: " + right_count.ToString ();
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (isServer) {
			if (left_count > 0 && right_count > 0) {
				if (collision.gameObject.name == "bound_left") {
					left_count = left_count - 5;
					textObject_left.text = "Your Score: " + left_count.ToString ();
				} else if (collision.gameObject.name == "bound_right") {
					right_count = right_count - 5;
					textObject_right.text = "Your Score: " + right_count.ToString ();
				}
			} else if (left_count <= 0) {
				Ball.score = right_count;
				StartCoroutine (MyMethod ());
				//Application.LoadLevel("_Scene_2");
			} else {
				Ball.score = left_count;
				StartCoroutine (MyMethod ());
				//Application.LoadLevel("_Scene_2");
			}	
		}
	}

	IEnumerator MyMethod() {
		Debug.Log("Before Waiting 5 seconds");
		GameOver ();
		yield return new WaitForSeconds(3);
		Debug.Log("After Waiting 5 Seconds");
		GameObject a = GameObject.Find ("lobbyManager");
//		NetworkManagerHUD b = a.GetComponent<NetworkManagerHUD> ();
//		Destroy (b);
//		Destroy (a);
//		Network.CloseConnection (Network.connections[0],false);
		NetworkLobbyManager b = a.GetComponent<NetworkLobbyManager> ();

		b.StopHost ();
		a = GameObject.Find ("lobbyManager");
		Debug.Log (a.ToString());
		Destroy (a);
		Debug.Log (a.ToString());
		Application.LoadLevel("score");

	}
	
	void GameOver () {
		GameOverText.text = "Game Over";
		if (left_count <= 0) {
			Right.text = "Winner !";
		}
		else{
			Left.text = "Winner !";
		}
	}
}
