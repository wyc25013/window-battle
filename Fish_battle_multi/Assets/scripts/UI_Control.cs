using UnityEngine;
using System.Collections;

public class UI_Control : MonoBehaviour {
	
	public void changeScene(string sceneName){
		GameObject a = GameObject.Find("lobbyManager");
//		Debug.Log (a.ToString ());
//		Debug.Log (GameObject.Find ("foo").ToString ());
		Destroy (a);
		Application.LoadLevel (sceneName);
	}

	public void quit(){
		Application.Quit ();
	}
}

