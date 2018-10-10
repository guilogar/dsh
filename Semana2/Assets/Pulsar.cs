using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pulsar : MonoBehaviour {

    int mostrar;
    bool count;
    Button elboton;
    Image myImage;
    public Sprite unoImage;
    public Sprite dosImage;
    public Sprite tresImage;
    private float myDealy = 1;

	// Use this for initialization
	void Start () {
        count = false;
        elboton = GetComponent<Button>();
        myImage = GetComponent<Image>();
        elboton.onClick.AddListener(BotonPulsado);
        mostrar = 3;
	}
	
    void BotonPulsado()
    {
        count = true;
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(count)
        {
            switch(mostrar)
            {
                case 0: SceneManager.LoadScene(1); break;
                case 1: myImage.sprite = unoImage; break;
                case 2: myImage.sprite = dosImage; break;
                case 3: myImage.sprite = tresImage; break;
            }

            StartCoroutine(Esperar());
            mostrar--;
            count = false;
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(myDealy);
        count = true;
    }
}
