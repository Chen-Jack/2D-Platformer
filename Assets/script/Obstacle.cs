using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	public string required_item;

	void OnCollisionStay2D(Collision2D col){
		if (GetComponent<Inventory> ().currItem == required_item) {
			Destroy(transform.GetChild (0));
		}
	}

}
