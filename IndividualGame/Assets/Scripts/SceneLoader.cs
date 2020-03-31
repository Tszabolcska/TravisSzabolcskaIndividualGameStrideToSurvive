using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    void Start()
    {
        //Debug.Log("We have loaded the end game screen.");
        //Make the cursor visble.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            LoadHowTo();
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadHowTo()
    {
        SceneManager.LoadScene("HowToPlay");
    }

}
