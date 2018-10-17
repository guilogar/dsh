using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cr : MonoBehaviour {

    public Text texto;

	// Use this for initialization
	void Start () {
        texto.text = PlayerPrefs.GetString("tiempo");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
