using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDoor : MonoBehaviour
{
    public Animation dooropen;
   
    [SerializeField]
    Monkey monkey1 = new Monkey();
    [SerializeField]
    Monkey monkey2 = new Monkey();
    [SerializeField]
    Monkey monkey3 = new Monkey();
    [SerializeField]
    Scientist scientist = new Scientist();
    Monkey redDoor = new Monkey();

    [SerializeField]
    AudioSource openDoor;


    private void OnTriggerStay(Collider other)
    {
        //yellow
        if (other.tag == "Monkey1" && monkey1.isXPressed && monkey1.GetM1YellowKeyCount() >= 1 && gameObject.tag != "WinDoor" && gameObject.tag != "GreenDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();


        }
        if (other.tag == "Monkey2" && monkey2.isXPressed && monkey2.GetM2YellowKeyCount() >= 1 && gameObject.tag != "WinDoor" && gameObject.tag != "GreenDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();

        }
        if (other.tag == "Monkey3" && monkey3.isXPressed && monkey3.GetM3YellowKeyCount() >= 1 && gameObject.tag != "WinDoor" && gameObject.tag != "GreenDoor" && gameObject.tag != "RedDoor") 
        {
            dooropen.Play();
            openDoor.Play();

        }
        // green
        if (other.tag == "Monkey1" && monkey1.isXPressed && monkey1.GetM1GreenKeyCount() >= 1 && gameObject.tag != "WinDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();
        }
        if (other.tag == "Monkey2" && monkey2.isXPressed && monkey2.GetM2GreenKeyCount() >= 1 && gameObject.tag != "WinDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();
        }
        if (other.tag == "Monkey3" && monkey3.isXPressed && monkey3.GetM3GreenKeyCount() >= 1 && gameObject.tag != "WinDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();

        }
        if (other.tag == "Scientist" && Input.GetKey(KeyCode.F) && gameObject.tag != "WinDoor" && gameObject.tag != "FirstDoor") 
        {
            dooropen.Play();
            openDoor.Play();

        }
        // win
        if (other.tag == "Monkey1" && monkey1.isXPressed && monkey1.GetM1WinKeyCount() >= 1 && gameObject.tag != "GreenDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();

        }
        if (other.tag == "Monkey2" && monkey2.isXPressed && monkey2.GetM2WinKeyCount() >= 1 && gameObject.tag != "GreenDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();

        }
        if (other.tag == "Monkey3" && monkey3.isXPressed && monkey3.GetM3WinKeyCount() >= 1 && gameObject.tag != "GreenDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor")
        {
            dooropen.Play();
            openDoor.Play();
        }

        if (other.tag == "Monkey1" && monkey1.isXPressed && gameObject.tag != "GreenDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor" && gameObject.tag != "WinDoor")
        {
            dooropen.Play();
            openDoor.Play();
        }
        if (other.tag == "Monkey2" && monkey2.isXPressed && gameObject.tag != "GreenDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor" && gameObject.tag != "WinDoor")
        {
            dooropen.Play();
            openDoor.Play();
        }
        if (other.tag == "Monkey3" && monkey3.isXPressed && gameObject.tag != "GreenDoor" && gameObject.tag != "YellowDoor" && gameObject.tag != "RedDoor" && gameObject.tag != "WinDoor")
        {
            dooropen.Play();
            openDoor.Play();
        }
    }
}
