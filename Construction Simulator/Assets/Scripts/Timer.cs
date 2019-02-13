using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text txtTimer;
    private float startTime;
    private bool running;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        running = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(running)
            txtTimer.text = getCurrentTime();
	}

    public void setTextLabel(Text timerText) {
        txtTimer = timerText;
    }

    public void setRunning(bool b) {
        running = b;
    }

    public string getCurrentTime() {
        float t = Time.time - startTime;

        string mins = ((int)t / 60).ToString("00");
        string secs = (t % 60).ToString("00.00");

        return mins + ':' + secs;
    }
}
