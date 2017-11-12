using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player_Score : MonoBehaviour {
	public int score;
	public Canvas UI;
	public GameObject scoreUI;
	// Update is called once per frame

	void Awake(){
		DontDestroyOnLoad (UI);
		if (FindObjectsOfType (UI.GetType ()).Length > 1) {
			Destroy (UI.gameObject);
		}
	}
	void Start(){
		PlayerPrefs.SetInt ("score", 0);
	}

	void Update () {
		scoreUI.gameObject.GetComponent<Text> ().text = "Score: " + PlayerPrefs.GetInt("score");
	}
}
