using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter_Area : MonoBehaviour {
	public string level;
	public Scene scene;
	public GameObject portal;

	private IEnumerator coroutine;
	// Update is called once per frame
	void Update (){ 
		
	}

	void OnTriggerStay2D(Collider2D col){
		coroutine = ChangeScene (col);
		StartCoroutine (coroutine);
	}

	IEnumerator ChangeScene(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if (Input.GetKeyDown ("up")) {
				//portal = this.gameObject;

				SceneManager.LoadSceneAsync (level, LoadSceneMode.Single);
				yield return null;
//				scene = SceneManager.GetSceneByName (level);
//				SceneManager.MoveGameObjectToScene (col.gameObject, scene);
			}
		}
	}



}
