using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Functionality : MonoBehaviour {

	public int sceneIndex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyUp ("up")) {
				SceneManager.LoadScene (sceneIndex);
			}
		}
	}
}
