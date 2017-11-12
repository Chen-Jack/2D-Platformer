using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Projectile : MonoBehaviour {
	void Update(){
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "monster") {
			col.gameObject.GetComponent<Enemy_Health> ().health -= 1;
			Destroy (gameObject);
		}
		if (col.gameObject.tag == "hitPlayer") {
			Destroy (gameObject);
			Destroy (col.gameObject);
		}
		if (col.gameObject.tag == "ground") {
			Destroy (gameObject);
		}
	}
}
 