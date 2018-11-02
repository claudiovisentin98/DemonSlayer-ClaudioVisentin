using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(640, 480, true);
        Application.targetFrameRate = 60;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape) | Input.GetKey (KeyCode.Joystick1Button7))
        {
            Application.Quit();
        }
	}
}
