using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class movement : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
		gameObject.transform.position = new Vector2 (0, 3);

	}
	
	// Update is called once per frame
	void Update () {
		move ();
		jump ();

	}

	//GetComponent<Hit>().
	void move(){
		float x = 2*Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (Math.Abs(x)*x,0);


	}

	void jump(){
		if (Input.GetKeyUp("up")){
			GetComponent<Rigidbody2D> ().AddForce(Vector2.up*900);
		}
	}


}


