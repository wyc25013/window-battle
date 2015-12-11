using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tut_ball : MonoBehaviour {
	
	public float ballVelocity = 400f;
	private Rigidbody rb;
	private int left_count = 150;
	private int right_count = 150;
	static public int score = 0;
	private TextMesh textObject_left;
	private TextMesh textObject_right;
	bool isPlay; //true when the ball is moving
	int randInt; //random direction
	Text GameOverText;
	Text Left;
	Text Right;
	
	/*
	void Start(){
		textObject_left = GameObject.Find("Score_left").GetComponent<TextMesh>();
		textObject_right = GameObject.Find("Score_right").GetComponent<TextMesh>();
		textObject_left.text = "Your Score: " + left_count.ToString ();
		textObject_right.text = "Your Score: " + right_count.ToString ();
		GameOverText = GameObject.Find("Text").GetComponent<Text>(); 
		Left = GameObject.Find("Left_text").GetComponent<Text>(); 
		Right = GameObject.Find("Right_text").GetComponent<Text>(); 
	}*/
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
		randInt = Random.Range (1, 2);
	}
	void OnCollisionEnter(Collision collision) {
		if (left_count > 0 && right_count > 0) {
			if (collision.gameObject.name == "bound_left") {
				left_count = left_count - 5;
				textObject_left.text = "Your Score: " + left_count.ToString ();
			} else if (collision.gameObject.name == "bound_right") {
				right_count = right_count - 5;
				textObject_right.text = "Your Score: " + right_count.ToString ();
			}
		} else if (left_count <= 0) {
			score = right_count;
			MyMethod();
			//Application.LoadLevel("_Scene_2");
		} else {
			score = left_count;
			MyMethod();
			//Application.LoadLevel("_Scene_2");
		}
		
	}
	void Update () {
		if (Input.GetMouseButton (0) == true && isPlay == false) {
			transform.parent = null;
			isPlay = true;
			rb.isKinematic = false;
			if (randInt == 1) {
				rb.AddForce (new Vector3 (ballVelocity, ballVelocity, 0));
			}
			if (randInt == 2) {
				rb.AddForce (new Vector3 (-ballVelocity, -ballVelocity, 0));
			}
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
	}
	void MyMethod() {
		Debug.Log("Before Waiting 5 seconds");
		GameOver ();
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

