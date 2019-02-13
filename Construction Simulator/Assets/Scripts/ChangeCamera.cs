using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {
	
	public Camera FirstPersonCam, ThirdPersonCam;
	public bool camSwitch = false;
	private bool cameraswitch = true;

	// Use this for initialization
	void Start () {
		
	}
	
	void SetTrue() {
		cameraswitch = true;
	}
	
	void Update()
     {
         if (Input.GetButton("Camera") && cameraswitch)
         {
             camSwitch = !camSwitch;
             FirstPersonCam.gameObject.SetActive(camSwitch);
             ThirdPersonCam.gameObject.SetActive(!camSwitch);
			 cameraswitch = false;
			 Invoke("SetTrue", 0.5f);
         }
     }
}
