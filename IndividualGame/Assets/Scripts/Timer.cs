using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class Timer : MonoBehaviour {

    public Text timerText;
    public float t;

    // Use this for initialization
    void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
        t = Time.timeSinceLevelLoad;
        string seconds = (t).ToString("f0");
        timerText.text = seconds;

        if (t >= 30)
        {
            Health.health -= 0.2f;
        }
    }
}
