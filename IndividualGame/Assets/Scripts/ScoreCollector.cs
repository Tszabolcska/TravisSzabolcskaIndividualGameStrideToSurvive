using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCollector : MonoBehaviour {

    public Text score;
    public Text highscore;

    private void Start()
    {
        score.text = PlayerPrefs.GetInt("Score").ToString();
        highscore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
