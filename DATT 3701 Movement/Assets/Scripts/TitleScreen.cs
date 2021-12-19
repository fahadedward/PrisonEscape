using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject controlWindow;
    //public GameObject settingWindow;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //resume the time
        Time.timeScale = 1f;
        //hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ControlsWindow()
    {
        controlWindow.SetActive(true);
    }

    public void CloseControl()
    {
        controlWindow.SetActive(false);
    }

    public void SettingsWindow()
    {

    }
}
