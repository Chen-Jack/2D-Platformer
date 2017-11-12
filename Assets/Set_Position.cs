using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Set_Position : MonoBehaviour {


	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
		Vector2 start = GameObject.FindGameObjectWithTag ("start").transform.position;
		GameObject player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		player.transform.position = start;
	}
}
