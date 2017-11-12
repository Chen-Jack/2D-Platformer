using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Action : MonoBehaviour {
	public GameObject projectile;
	private int x;

	void Start(){

	}
	// Update is called once per frame
	void Update () {
		if (GetComponent<Player_Movement> ().facingRight) x = 1;
		else x = -1;
	
		if (Input.GetKeyDown ("k")) {
			GameObject bullet = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2(x, 0) * 450);
			Destroy (bullet, 3);
		}
	}

}
