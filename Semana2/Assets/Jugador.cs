using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour {
    public Camera camara;
    public Text puntuacion;
    public float force = 5;
    private float puntos = 0;

    private Vector3 offset;
    private Rigidbody rb;
    private bool changeDir;
    private Vector3 dir;
    public float x = 0;
    public float z = 0;
    public GameObject prefab; //el cubo que voy  a duplicar
    public GameObject diamante;
    public GameObject bola;

    //Variable para el retraso
    private float myDealy = 0.5f;

    // Use this for initialization
    void Start()
    {
        //Obtenemos la posición inicial de la cámara
        offset = camara.transform.position;
        rb = GetComponent<Rigidbody>();
        changeDir = true;
        dir = new Vector3(0, 0, 0);

        //Trabajar con el prefab
        //Empezamos a crear GameObject, el primero debemos desplazarlos
        GameObject elcubo = Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
        GameObject eldiamante = Instantiate(diamante, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
        z = z + 6.01f;
        elcubo.transform.position = new Vector3(x, 0, z);
        //Creamos unos cuantos cuadros iniciales
        for (int i = 0; i < 10; i++)
        {
            float ran = Random.Range(0f, 1f);
            if (ran < 0.5f)
            {
                x = x + 6.01f;
            }
            else
            {
                z = z + 6.01f;
            }
            elcubo = Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
            eldiamante = Instantiate(diamante, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(puntos == 3)
        {
            SceneManager.LoadScene(2);
        }
        //Vamos moviendo la cámara
        camara.transform.position = this.transform.position + offset;
        //Según vaya pulsando el botón de espacio se mueve en una dirección
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.Sleep();
            if (changeDir)
            {
                dir = new Vector3(0, 0, 1);
                changeDir = false;
            }
            else
            {
                dir = new Vector3(1, 0, 0);
                changeDir = true;
            }
        }
    }

    //Movimiento continuo de la bola
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + dir * Time.deltaTime * force);
    }

    //Cada vez que salimos de un bloque creamos otros y dejamos caer este
    void OnCollisionExit(Collision col)
    {
        Debug.Log("Entrado en OnCollisionExit");
        if (col.transform.tag == "suelo")
        {
            Debug.Log("si es suelo");
            StartCoroutine(Destruir(col));
            float ran = Random.Range(0f, 1f);
            if (ran < 0.5f)
            {
                x = x + 6.01f;
            }
            else
            {
                z = z + 6.01f;
            }
            GameObject elcubo = Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity) as GameObject;
            GameObject eldiamante = Instantiate(diamante, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
        }
    }

    //Comer diamante
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("diamante"))
        {
            other.gameObject.SetActive(false);
            this.puntuacion.text = "Puntos: " + (++this.puntos);
        }
    }

    //Caida con retraso.
    IEnumerator Destruir(Collision col)
    {
        yield return new WaitForSeconds(myDealy);
        col.rigidbody.isKinematic = false;
    }
}
