using UnityEngine;
using System.Collections;

public class bonus_ball : MonoBehaviour {
	public static float     bottomY = -20f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( transform.position.y < bottomY ) {
			Destroy( this.gameObject );
			
			// Get a reference to the ApplePicker component of Main Camera
		//	bonus_picker apScript = Camera.main.GetComponent<bonus_picker>(); // 1

		//	bracketCtr1 b1 = Camera.main.GetComponent<bracketCtr1>();
		//	bracketCtr2 b2 = Camera.main.GetComponent<bracketCtr2>();
		//	b1.bonusDestroyed();
		//	b2.bonusDestroyed();
			// Call the public AppleDestroyed() method of apScript
		//	apScript.bonusDestroyed();                                      // 2
		}
		
	}
}
