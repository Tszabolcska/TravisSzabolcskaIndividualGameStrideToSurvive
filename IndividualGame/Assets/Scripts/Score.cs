using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public GameObject enemy;
    public Text scoreText;
    public Text highScoreText;
    public static int score;
	// Use this for initialization
	void Start () {
        score = 0;
        highScoreText.text = "High Score:" + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("Score", score);

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score:" + score.ToString();
        }
    }
}
