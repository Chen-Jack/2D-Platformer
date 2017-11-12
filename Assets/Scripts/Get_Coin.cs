using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Coin : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){	
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
			col.gameObject.GetComponent<Player_Score> ().score += 5;
			PlayerPrefs.SetInt ("score", col.gameObject.GetComponent<Player_Score> ().score);
		}
	}
}
