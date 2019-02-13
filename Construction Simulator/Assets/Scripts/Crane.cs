using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : MonoBehaviour {
	public int speed;
	public AudioSource inicio;
	public AudioSource fin;
	private bool gruasonando;

	// Use this for initialization
	void Start () {
		gruasonando = false;
	}
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		transform.Rotate(0, x, 0);
		
		if(Input.GetAxis("Horizontal") != 0 && !gruasonando) {
			inicio.Play();
			gruasonando = true;
			Debug.Log("Sueno");
		}
		
		if(Input.GetAxis("Horizontal") == 0 && gruasonando) {
			inicio.Stop();
			fin.Play();
			gruasonando = false;
		}
		
	}
}
