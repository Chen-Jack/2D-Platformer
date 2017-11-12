using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPower_Coin : MonoBehaviour {
	public float jumpPower;
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpPower, ForceMode2D.Impulse);
			Destroy (gameObject);
		}
	}
}
