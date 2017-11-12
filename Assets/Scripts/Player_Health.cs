using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {
	public bool dead;
	public int health;
	public int healthMax = 100;

	private float x;
	private float y;
	// Use this for initialization
	void Start () {
		health = healthMax;
		dead = false;

		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -7) {
			dead = true;
		}

		if (dead == true || health <= 0) {
			dead = false;
			health = healthMax;

			SceneManager.LoadScene ("game", LoadSceneMode.Single);
			gameObject.transform.position = new Vector2 (x, y);
		}

	}
}
