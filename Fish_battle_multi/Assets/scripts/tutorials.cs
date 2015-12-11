using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tutorials : MonoBehaviour {

	public int num_step = 0;

	public GameObject   fishPrefab;
	public GameObject   bonusPrefab;
	public GameObject   ballPrefab;
	public GameObject   punishPrefab;

	public GameObject bonusObject;

	public void on_click(){
		if (num_step == 0) {
			showfish ();
			++num_step;
		} else if (num_step == 1) {
			showball ();
			++num_step;
		} else if (num_step == 2) {
			showbonus ();
			++num_step;
		} else if (num_step == 3) {
			destroybonus();
			showpunish ();
			++num_step;
		} else {
			// end the tutorial
			Application.LoadLevel("GameRule");
		}
	}

	public void showfish(){
		GameObject fish = Instantiate (fishPrefab) as GameObject;
		fish.transform.position = new Vector3(-20,0,0);
		Debug.Log ("here");
		GameObject.Find ("instructions").GetComponent<Text> ().text = "Try to move the fish around! Using W, A, D, S to go Up, Left, Right and Down";
		GameObject.Find ("Button").GetComponentInChildren<Text> ().text = "click again to show next step!";
	}

	public void showball(){
		GameObject ball = Instantiate( ballPrefab ) as GameObject;
		GameObject.Find("instructions").GetComponent<Text>().text = "Click the red ball! Try to hit it when it’s coming to your side";
	}

	public void showbonus(){
		bonusObject = Instantiate( bonusPrefab ) as GameObject;
		GameObject.Find ("instructions").GetComponent<Text> ().text = "Bonus are coming, eat it to become bigger!";
	}

	public void destroybonus(){
		Destroy (bonusObject);
	}

	public void showpunish(){
		//Destroy (bonusPrefab);
		GameObject punish = Instantiate( punishPrefab ) as GameObject;
		GameObject.Find ("instructions").GetComponent<Text> ().text = "Avoid punishments of becoming smaller";
		GameObject.Find ("Button").GetComponentInChildren<Text> ().text = "You're done! Click to go back!";

	}
}
