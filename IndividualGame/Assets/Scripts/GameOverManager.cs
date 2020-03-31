using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

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
            LoadMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();
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
}
