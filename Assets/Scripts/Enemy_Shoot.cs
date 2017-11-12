using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour {
	public GameObject projectile;

	private bool canShoot;
	private GameObject bullet;

	// Use this for initialization
	void Start () {
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (GetComponent<EnemyAI>().XMoveDirection, 0));

		if (hit) {
			if (hit.collider.tag == "Player") {
				if (hit.distance < 8.5f){
					if (canShoot) StartCoroutine ("WaitToShoot");
				} 				
			}
		}
	}

	IEnumerator WaitToShoot(){
		canShoot = false;
		yield return new WaitForSeconds (1.4f);
		Shoot ();
		canShoot = true;
	}

	public void Shoot(){
		bullet = Instantiate (projectile, new Vector2 (transform.position.x + 1.7f, transform.position.y), Quaternion.identity) as GameObject;
		bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2(GetComponent<EnemyAI>().XMoveDirection, 0) * 100);
	}

	public void Turret(){
		InvokeRepeating ("Shoot", 0, 2.7f);
	}
}
