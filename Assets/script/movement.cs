using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class movement : MonoBehaviour {


	public float playerSpeed;
	public float jumpPower;

	public bool isGrounded;
	private float x;

	// Use this for initialization
	void Start () {
		
		isGrounded = true;

	}
	
	// Update is called once per frame
	void Update () {
		move ();
		jump ();
		x = Input.GetAxis ("Horizontal");
		FlipPlayer ();
		borderPatrol ();
		DontDestroyOnLoad (gameObject);

		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
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

	//GetComponent<Hit>().b
	void move(){
		
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (x * playerSpeed, GetComponent<Rigidbody2D>().velocity.y);


	}

	void jump(){
		if (Input.GetKeyUp("up") && isGrounded){
			GetComponent<Rigidbody2D> ().AddForce(Vector2.up* jumpPower);
			isGrounded = false;
			//GameObject.Find ("InventoryWindow").GetComponent<Inventory> ().rotate_focus_right ();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
			
	}

	void OnTriggerStay2D(Collider2D col){
		if (Input.GetKeyUp ("x")) {
			Interact (col);
		}
	}

	void Interact(Collider2D col){
		string object_tag = col.gameObject.tag;
		if (object_tag == "item") {
			Sprite inventory_image = col.gameObject.GetComponent<SpriteRenderer> ().sprite;
			GameObject.Find ("InventoryWindow").GetComponent<Inventory> ().add_to_inventory (col.gameObject.name, inventory_image);
			Destroy (col.gameObject);
		} 
		else if (object_tag == "obstacle") {
			string required_item = col.gameObject.GetComponent<Obstacle> ().required_item;
			if (GameObject.Find ("InventoryWindow").GetComponent<Inventory> ().checkInteraction(required_item)) {
				Destroy (col.gameObject);
			}
		} 
		else {
			print ("Error with interacting?");
		}


	}

	void borderPatrol(){
		if (GetComponent<Rigidbody2D> ().position.y <= -6) {
			Destroy (gameObject);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}


}


