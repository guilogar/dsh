using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMenu : MonoBehaviour {

    public GameObject panelMain;
    public GameObject panelLvlSelect;

    public void OnLevelSelectionClick() {
        panelMain.SetActive(false);
        panelLvlSelect.SetActive(true);
        EventSystem.current.SetSelectedGameObject(panelLvlSelect.transform.GetChild(0).gameObject);
    }

    public void OnLevelSelectionClose()
    {
        panelLvlSelect.SetActive(false);
        panelMain.SetActive(true);
        EventSystem.current.SetSelectedGameObject(panelMain.transform.GetChild(3).gameObject);
    }

}
