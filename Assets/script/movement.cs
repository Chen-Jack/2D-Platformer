using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class movement : MonoBehaviour {


	public float playerSpeed;
	public float jumpPower;

	private float x;
	private 
	// Use this for initialization
	void Start () {
		
		gameObject.transform.position = new Vector2 (0, 3);

	}
	
	// Update is called once per frame
	void Update () {
		move ();
		jump ();
		x = Input.GetAxis ("Horizontal");
		FlipPlayer ();
	}

	void FlipPlayer(){
		Vector2 scale = gameObject.transform.localScale;
		float xValue = Math.Abs (scale.x);
		if (x > 0) {
			scale.x = -(xValue);
		}if (x < 0) {
			scale.x = xValue;
		}

		transform.localScale = scale;
	}

	//GetComponent<Hit>().
	void move(){
		
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (x * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);


	}

	void jump(){
		if (Input.GetKeyUp("up")){
			GetComponent<Rigidbody2D> ().AddForce(Vector2.up* jumpPower);
			//GameObject.Find ("InventoryWindow").GetComponent<Inventory> ().rotate_focus_right ();
		}
	}


}


