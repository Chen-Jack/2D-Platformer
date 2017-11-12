using UnityEngine;
using System.Collections;

public class parallax : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parallaxScales; //Proportion of camera to BGs
	public float smoothing = 1f; //

	private Transform cam;
	private Vector3 previousCamPos; //Store position of camera in prev frame

	void Awake (){ //awake func is called before Start, called on wake up
//		cam = Camera.main.transform;

	}

	void Start () {
		previousCamPos = cam.position;
		parallaxScales = new float[backgrounds.Length]; //inside brackets declare length
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}

	void Update () {
		for (int i = 0; i < backgrounds.Length; i++) {
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);                                		
		}
		previousCamPos = cam.position;

	}	
}
