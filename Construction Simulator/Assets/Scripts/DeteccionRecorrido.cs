using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionRecorrido : MonoBehaviour {
	
	static int cont;
	private bool completado = false;
	public AudioSource inicio;

    public LevelManager lvlMngr;

	// Use this for initialization
	void Start () {
		DeteccionRecorrido.cont = 0;
	}

	void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.name == "ObjetoCogida1" && !completado)
        {
			DeteccionRecorrido.cont += 1;
			completado = true;
			GameObject particles = GameObject.Find("magic_ring_green1");
			if (particles){
				Destroy (particles.gameObject);
				inicio.Play();
			}
            lvlMngr.LevenEnd();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
