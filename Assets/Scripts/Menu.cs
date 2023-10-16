using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject ControlsTxt;
    public GameObject DisplayObjs;

    void Start ()
    {
        ControlsTxt.SetActive(false);
        DisplayObjs.SetActive(true);
    }
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play Initiated");
    }

    public void OnQuitButton ()
    {
        Application.Quit();
        Debug.Log("Quit Initiated");
    }

    public void OnControlsButton ()
    {
        ControlsTxt.SetActive(true);
        DisplayObjs.SetActive(false);
    }
}
