using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_movement : MonoBehaviour {

	public bool isGrounded;
	public int jump;
		// Use this for initialization
	void Start () {
		isGrounded = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		float move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * 7, GetComponent<Rigidbody2D> ().velocity.y);
		Jump ();

	}

	void Jump(){
		float moveY = Input.GetAxis ("Vertical");
		if (Input.GetKeyDown ("space") && isGrounded) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jump);
			isGrounded = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
		}
	}
}
