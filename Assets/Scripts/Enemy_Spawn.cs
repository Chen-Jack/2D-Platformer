using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour {
	public Transform monster;
	public float spawnTime = 3;

	void Update () {
		InvokeRepeating ("SpawnEnemies", 2.5f, spawnTime);
	}

	void SpawnEnemies(){
		Instantiate (monster, transform.position, Quaternion.identity);
	}
}
