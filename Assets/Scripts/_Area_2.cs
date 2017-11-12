using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _Area_2 : MonoBehaviour {
	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Vector2 portal = GameObject.FindGameObjectWithTag ("portal").transform.position;
		GameObject player = GameObject.FindGameObjectWithTag ("Player").GetComponentInParent<Player_Movement> ().gameObject;
		player.transform.position = portal;
	}
}
