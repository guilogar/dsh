using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
	public int speed;
	bool delante = false;
	bool detras = false;
	public AudioSource inicio;
	public AudioSource fin;
	private bool gruasonando;


	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.name == "Limit1")
        {
            delante = true;
        }
		
		if(other.gameObject.name == "Limit2")
        {
            detras = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Vertical") < 0)
		  delante = false;
	  
		if (Input.GetAxis("Vertical") > 0)
		  detras = false;
	  
		if(!delante && !detras) {
			var x = Input.GetAxis("Vertical") * Time.deltaTime * speed;

			transform.Translate(-x, 0, 0);
		}
		
		if(Input.GetAxis("Vertical") != 0 && !gruasonando) {
			inicio.Play();
			gruasonando = true;
			Debug.Log("Sueno");
		}
		
		if(Input.GetAxis("Vertical") == 0 && gruasonando) {
			inicio.Stop();
			fin.Play();
			gruasonando = false;
		}
	}
}
