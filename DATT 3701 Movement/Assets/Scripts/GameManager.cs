using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Light light;

    [SerializeField]
    AudioSource monkeyWinSound;
    //end scene ui
    public GameObject winloseStageUI;
    //menuUI
    public GameObject menu;

    public GameObject Settings;

    public Sprite Onsprite;
    public Sprite Offsprite;


    public GameObject moneky1SafeWindow;
    public GameObject moneky2SafeWindow;
    public GameObject moneky3SafeWindow;

    //default game is Not paused 
    public static bool GameIsPaused = false;


    public GameObject defaultImage;
    public GameObject firstImage;
    public GameObject secondImage;
    public GameObject thirdImage;

    // Monkey monkey;

    private void Start()
    {
        //monkey = GetComponent<Monkey>();
        defaultImage.SetActive(true);
        firstImage.SetActive(true);
    }

    void Update()
    {
        //if the starting window is active, then the game is always paused
        if (defaultImage.activeSelf)
        {
            //pause the time
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        //&& if next button is pressed
        if (firstImage.activeSelf && Input.GetKeyUp(KeyCode.E))
        {
            // Time.timeScale = 1f;

            firstImage.SetActive(false);
            // Time.timeScale = 0f;
            if (!firstImage.activeSelf)
            {
                secondImage.SetActive(true);
                print("Second image");
            }


        }
        //&& if next button is pressed
        if (secondImage.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            // Time.timeScale = 1f;
            print("Reached");
            secondImage.SetActive(false); 
            // Time.timeScale = 0f;
            if (!secondImage.activeSelf)
            {
                thirdImage.SetActive(true);
            }


        }
        //&& if the skip button is pressed, game start
        if (firstImage.activeSelf && Input.GetKey(KeyCode.R))
        {
            defaultImage.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;

        }
        //&& if the start button is pressed, game start
        if (secondImage.activeSelf && Input.GetKey(KeyCode.R))
        {
            defaultImage.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        //&& if the start button is pressed, game start
        if (thirdImage.activeSelf && Input.GetKey(KeyCode.R))
        {
            defaultImage.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

    }

    //what if scientist win
    public void ScientistWin()
    {
        winloseStageUI.SetActive(true);
        winloseStageUI.transform.GetChild(0).GetComponent<Text>().text = "Scientist Win!";

        if (moneky1SafeWindow.activeSelf)
        {
            moneky1SafeWindow.SetActive(false);
        }
        if (moneky2SafeWindow.activeSelf)
        {
            moneky2SafeWindow.SetActive(false);
        }
        if (moneky3SafeWindow.activeSelf)
        {
            moneky3SafeWindow.SetActive(false);
        }
        //pause the time
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //what if monkey win
    public void MonkeyWin()
    {
        winloseStageUI.SetActive(true);
        winloseStageUI.transform.GetChild(0).GetComponent<Text>().text = "Monkey Win!";
        moneky1SafeWindow.SetActive(false);
        moneky2SafeWindow.SetActive(false);
        moneky3SafeWindow.SetActive(false);
        //pause the time
        Time.timeScale = 0f;
        GameIsPaused = true;
        monkeyWinSound.Play();
    }

    //what if moneky1 enter safe zone
    public void Monkey1Safe()
    {
        moneky1SafeWindow.SetActive(true);
        //should we consider disable monkey controls after they enter safe zone
    }

    //what if moneky2 enter safe zone
    public void Monkey2Safe()
    {
        moneky2SafeWindow.SetActive(true);
    }


    //what if moneky3 enter safe zone
    public void Monkey3Safe()
    {
        moneky3SafeWindow.SetActive(true);
    }

    //restart button
    public void Restart()
    {
        if (winloseStageUI.activeSelf)
        {
            winloseStageUI.SetActive(false);


        }
        else if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        light.transform.rotation = Quaternion.Euler(0.868f, 148.085f, 163.642f);
    }

    //home button
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void SettingsWindow()
    {
        menu.SetActive(false);
        Settings.SetActive(true);
    }

    public void CloseSetting()
    {

        Settings.SetActive(false);
        menu.SetActive(true);
    }

    public void Menu()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            //show cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.SetActive(true);
            //pause the time
            Time.timeScale = 0f;
            GameIsPaused = true;
        }



    }

    public void Resume()
    {
        //hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //set the pause menu ui to disable
        menu.SetActive(false);
        //resume the time
        Time.timeScale = 1f;
        GameIsPaused = false;

    }


    public void toggleButton()
    {
        var toggles = GameObject.FindGameObjectsWithTag("toggle");

        foreach (var t in toggles)
        {
            if (t.GetComponent<Slider>().value == 0)
            {
                //t.transform.GetChild(0).GetComponent<Image>().sourceimage = Offsprite;
                t.transform.GetChild(0).GetComponent<Image>().sprite = Offsprite;

            }
            else
            {
                //t.transform.GetChild(0).GetComponent<Image>().sourceimage = Onsprite;
                t.transform.GetChild(0).GetComponent<Image>().sprite = Onsprite;

            }
        }

    }
}
