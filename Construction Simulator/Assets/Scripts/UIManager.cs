using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public GameObject panelHookSensor;
    public GameObject panelTimer;
    public GameObject panelLevelEnd;

    private Text txtHookStatus;

    Timer temporizador;

    public enum HookStatus { Free, Loaded, CloseToLoad }

    // Use this for initialization
    void Start () {
        temporizador = gameObject.AddComponent<Timer>();
        temporizador.setTextLabel(panelTimer.GetComponentInChildren<Text>());

        txtHookStatus = panelHookSensor.GetComponentsInChildren<Text>()[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showLevelEndPanel() {
        // Parar contador y ocultar paneles
        temporizador.setRunning(false);
        panelHookSensor.SetActive(false);
        panelTimer.SetActive(false);
        // Quitamos los scripts para evitar que siga funcionando la grua
        GameObject Grua = GameObject.Find("Grua");
        Destroy(Grua.GetComponentInChildren<Crane>());
        Destroy(Grua.GetComponentInChildren<Hook>());
        Destroy(Grua.GetComponentInChildren<Rope>());
        GameObject.Find("Gancho").SetActive(false);
        // Texto tiempo empleado y mostrar el panel de nivel completado
        Text txtTime = panelLevelEnd.transform.Find("txtTime").GetComponent<Text>();
        txtTime.text = "Tiempo empleado: " + temporizador.getCurrentTime();
        panelLevelEnd.SetActive(true);
        EventSystem.current.SetSelectedGameObject(panelLevelEnd.transform.Find("BtnNextLevel").gameObject);
    }

    // Codigo UI sensor del gancho (hook sensor)
    public void setHookSensorStatus(HookStatus status){
        switch (status) {
            case HookStatus.Free:
                txtHookStatus.text = "Estado: Libre";
            break;
            case HookStatus.Loaded:
                txtHookStatus.text = "Estado: Con carga";
            break;
            case HookStatus.CloseToLoad:
                txtHookStatus.text = "Estado: Detectada carga cerca. Listo para coger";
            break;
        }
    }
    

}
