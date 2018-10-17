using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class contador : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool finish = false;

    void Start()
    {
        //timerText = GetComponent<Text>();
        startTime = Time.time;
    }

    void Update()
    {
        if (finish)
        {
            PlayerPrefs.SetString("tiempo", timerText.text);
            return;
        }
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public void Finnish()
    {
        finish = true;
        timerText.color = Color.yellow;
    }


}