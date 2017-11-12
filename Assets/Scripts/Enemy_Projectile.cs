using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 6);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player_Health> ().health -= 5;
		}
		Destroy (gameObject);
	}
}
