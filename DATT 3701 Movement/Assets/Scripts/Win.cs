using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    [SerializeField]
    Transform destination;
    [SerializeField]
    GameObject scientist;

    bool monkey1Win = false;
    bool monkey2Win = false;
    bool monkey3Win = false;

    void Update()
    {
        if (monkey1Win && monkey2Win && monkey3Win)
        {
            GameManager.instance.MonkeyWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scientist")
        {
            scientist.SetActive(false);
            scientist.transform.position = destination.transform.position;
            scientist.SetActive(true);
        }

        if (other.tag == "Monkey1")
        {
            GameManager.instance.Monkey1Safe();
            monkey1Win = true;
        }
        if (other.tag == "Monkey2")
        {
            GameManager.instance.Monkey2Safe();
            monkey2Win = true;
        }
        if (other.tag == "Monkey3")
        {
            GameManager.instance.Monkey3Safe();
            monkey3Win = true;
        }


        // if(other.tag == "Monkey1" && other.tag == "Monkey2" && other.tag == "Monkey3")
        // {
        //  GameManager.instance.MonkeyWin();
        // }

    }
}

