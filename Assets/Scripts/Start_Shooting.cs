using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Shooting : MonoBehaviour {
	public GameObject enemy;
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			enemy.GetComponent<Enemy_Shoot> ().Turret ();
		}
	}
}
