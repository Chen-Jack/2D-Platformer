using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
	public int playerSpeed = 10;
	public float playerJumpPower = 900;
	public LayerMask p;

	private float moveX;
	private float moveY;
	public bool facingRight = true;
	private bool isGrounded;
	public float gravityStore;

	private Collision2D platform;
	public bool onLadder;
	private bool hitsFeet;
	private bool hitsHead;

	void Start(){
		onLadder = false;
		gravityStore = GetComponent<Rigidbody2D> ().gravityScale;
	}
	void Awake(){
		//destroys duplicates made by DontDestroyOnLoad (Singleton thing)
		DontDestroyOnLoad (gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		}
	}

	void Update () {
		PlayerMove ();
		if (!onLadder) {
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
			gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		}
		DontDestroyOnLoad (gameObject);
	}
		
	void PlayerMove(){
		moveX = Input.GetAxis ("Horizontal");
		if (moveX < 0.0f && facingRight) {
			FlipPlayer ();
		} else if (moveX > 0.0f && !facingRight) {
			FlipPlayer ();
		}
		if (Input.GetKeyDown ("space") && isGrounded == true) {
			Jump ();
		}
		//jump off ladder
		if (onLadder && Input.GetKey ("space") && (Input.GetAxis("Horizontal") != 0)) {
			onLadder = false;
			GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
			Jump ();
		}
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void FlipPlayer(){
		facingRight = !facingRight;
		Vector2 scale = gameObject.transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void Jump(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}
		
	void OnTriggerStay2D(Collider2D col){
		//climbing ladders
		moveY = Input.GetAxis ("Vertical");
		if (col.gameObject.tag == "ladder") {
			//colliders for feet and head of player
			hitsFeet = Physics2D.OverlapCircle (this.transform.GetChild(1).position, 1, p);
			hitsHead = Physics2D.OverlapCircle (this.transform.GetChild(0).position, 1, p);

			//if player wants to go up ladder(from start)
			if (hitsFeet && hitsHead) {
				if (Input.GetKey ("up")) {
					onLadder = true;
				}
			}

			//if player wants to go down ladder(from start)
			if (hitsFeet && !hitsHead) {
				if(Input.GetKey("down")){
					onLadder = true;
					//allow player to climb through platform(going down)
					Physics2D.IgnoreCollision (platform.collider, GetComponent<Collider2D> ());
				}
			}

			if (onLadder) {
				//make sure player is stuck to ladder
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
				gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

				//----
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, moveY * playerSpeed);
			}
		}
	}
		
	void OnTriggerExit2D(Collider2D col){
		//once player gets to the top of the ladder
		onLadder = false;

		//turn off ignorecollision for platform and player
		if (platform != null) {
			Physics2D.IgnoreCollision (platform.collider, GetComponent<Collider2D> (), false);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		//makes player only jump once
		if (col.gameObject.tag == "ground" || col.gameObject.tag == "platform") {
			isGrounded = true;
		}

//		//for ladder stuff, so that platform can be defined
//		if (col.gameObject.tag == "platform") {
//			platform = col;
//		}
//
//		//climb ladder through platform(going up)
//		if (onLadder && col.gameObject.tag == "platform") {
//			platform = col;
//			Physics2D.IgnoreCollision (platform.collider, GetComponent<Collider2D> (), true);
//		}
//
//		//when player goes all the way down on the ladder(hits ground), gets off ladder
//		if (onLadder && col.gameObject.tag == "ground") {
//			onLadder = false;
//		}
	}
}

