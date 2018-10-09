using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyCubes : MonoBehaviour {

    public float numEstrellas = 4;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Estrella" || col.gameObject.name == "Estrellalvl2")
        {
            Destroy(col.gameObject);
            this.numEstrellas--;
        }
        
        if(this.numEstrellas <= 0)
        {
            string sname = SceneManager.GetActiveScene().name;

            if (sname == "FirstScene")
                sname = "SecondScene";
            else if (sname == "SecondScene")
                sname = "ThirdScene";
            else if (sname == "ThirdScene")
                sname = "FirstScene";

            try
            {
                SceneManager.LoadScene(sname, LoadSceneMode.Single);
            } catch(Exception)
            {
                EditorUtility.DisplayDialog(
                    "Error", 
                    "Escena " + sname + " no cargada en el paquete principal", 
                    "Cancelar", "Continuar");
            }
        }
    }
}
