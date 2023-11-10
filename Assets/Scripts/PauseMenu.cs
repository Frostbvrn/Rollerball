using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool isPaused;


    void Start()
    {
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame ()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame ()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void OnReturnButton ()
    {
        SceneManager.LoadScene(0);
        ResumeGame();
    }
    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
