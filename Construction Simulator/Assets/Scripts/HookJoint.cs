using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HookJoint : MonoBehaviour {
	
	bool hasJoint = false;
	public AudioSource inicio;

    public UIManager UIMngr;

    private bool isTouching = false;
    private Transform objetoUnion;
    private float rotationSpeed = 0.25f;

    // Restricciones del gancho cuando esta libre o cuando esta ocupado
    private RigidbodyConstraints defaultConstraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    private RigidbodyConstraints hookedConstraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;

    // Restricciones del objeto cuando esta libre o enganchado
    private RigidbodyConstraints hookedObjectContraints = RigidbodyConstraints.FreezeRotationY;

    // Use this for initialization
    void Start () {
        InvokeRepeating("makeSensorFree", 0, 1.5f);
	}
	
	void OnCollisionEnter (Collision collision)
	{
        Debug.Log("OnCollisionEnter fired!");
		if (collision.gameObject.GetComponent<Rigidbody>() != null) {

            if (!hasJoint && Input.GetButton("Jump")) {
                gameObject.AddComponent<FixedJoint>();
                gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
                GetComponent<Rigidbody>().constraints = hookedConstraints;
                GetComponent<Collider>().enabled = false;

                // cambios en el otro objeto
                objetoUnion = collision.transform;
                objetoUnion.GetComponent<Rigidbody>().constraints = hookedObjectContraints;

                hasJoint = true;
                inicio.Play();
                UIMngr.setHookSensorStatus(UIManager.HookStatus.Loaded);
            }
		}
	}

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            isTouching = true;
            UIMngr.setHookSensorStatus(UIManager.HookStatus.CloseToLoad);
        }
    }

    void makeSensorFree(){
        isTouching = false;
    }
    
    // Update is called once per frame
    void Update () {

        if (Input.GetButton("Fire3") && hasJoint) {
			Destroy(gameObject.GetComponent<FixedJoint>());
            GetComponent<Rigidbody>().constraints = defaultConstraints;
            GetComponent<Collider>().enabled = true;
            // Cambios en el otro objeto
            objetoUnion.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            objetoUnion = null;

            hasJoint = false;
			inicio.Play();
        }

        // Controles de rotacion izquierda y derecha SOLO cuando haya un objeto enganchado
        if(objetoUnion != null) {
            if(Input.GetButton("Q")) {
                objetoUnion.Rotate(new Vector3(0, -rotationSpeed, 0));
            }

            if(Input.GetButton("E")) {
                objetoUnion.Rotate(new Vector3(0, rotationSpeed, 0));
            }
        }
        else {
            if (!isTouching)
                UIMngr.setHookSensorStatus(UIManager.HookStatus.Free);
        }
    }
}
