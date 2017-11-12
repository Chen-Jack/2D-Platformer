using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour {

	public string platform_name;
	public int platform_speed;

	private bool activated;
	// Use this for initialization
	void Start () {
		activated = false;
	}

	// Update is called once per frame
	void Update () {
		if (activated == true) {
			movePlatform();
		}
	}

	public void activatePlatform(){
		activated = true;
	}

	public void movePlatform(){
		GameObject platform = GameObject.Find ("Items").transform.Find (platform_name).gameObject;
		platform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (platform_speed, 0);
	}

	public void OnTriggerEnter2D(Collider2D col){
		this.transform.Find("Text_Prompt").GetComponent<MeshRenderer>().enabled = true;
	}

	public void OnTriggerExit2D(Collider2D col){
		this.transform.Find("Text_Prompt").GetComponent<MeshRenderer>().enabled = false;
	}
}
