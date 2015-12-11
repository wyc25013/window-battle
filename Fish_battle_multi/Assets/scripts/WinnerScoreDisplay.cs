using UnityEngine;
using System.Collections;

public class WinnerScoreDisplay : MonoBehaviour {
	private TextMesh WinnerScore;
	private TextMesh HighestScoreText;
	static private int highest_score;
	// Use this for initialization
	void Start () {
		GameObject a = GameObject.Find ("lobbyManager");
//		Debug.Log (a.ToString ());
		Destroy (a);
//		Debug.Log (a.ToString ());
		WinnerScore = GameObject.Find("WinnerScore").GetComponent<TextMesh>();
		HighestScoreText = GameObject.Find("HighestScore").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		WinnerScore.text = "Winner's Score: " + Ball.score.ToString();
		if (highest_score < Ball.score) {
			highest_score = Ball.score;
		}
		HighestScoreText.text = "Highest Score: " + Ball.score.ToString();
	}
}
