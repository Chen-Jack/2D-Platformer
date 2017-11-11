using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour {

	private GameObject player;
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void LateUpdate(){

		if (player != null) {
			float x = Mathf.Clamp (player.transform.position.x, minX, maxX);
			float y = Mathf.Clamp (player.transform.position.y, minY, maxY);
			gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
		}
	}
}
