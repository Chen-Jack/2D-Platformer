using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
	// Use this for initialization
	void Start () {

		Sprite shroom = Resources.Load<Sprite>("new_pic");
		GetComponent<Image>().sprite = shroom;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
	