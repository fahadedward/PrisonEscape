using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDoor : MonoBehaviour
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
    bool p1IsOn = false;
    bool p2IsOn = false;
    bool p3IsOn = false;
    private void OnTriggerStay(Collider other)
    {
        // && monkey1.GetM1ReDKeyCount() == 1  && monkey3.GetM3ReDKeyCount() == 1 && monkey1.isXPressed && monkey3.isXPressed
        if (other.tag == "Monkey1")
        {
            p1IsOn = true;
            //print("p1" + p1IsOn);
         // dooropen.Play();
        }
        if (other.tag == "Monkey3")
        {
            p3IsOn = true;
            //print("p3" + p3IsOn);
            // dooropen.Play();
        }

        if (other.tag == "Monkey2")
        {
            p2IsOn = true;
            //print("p3" + p3IsOn);
            // dooropen.Play();
        }
        if (monkey1.GetM1ReDKeyCount() == 1)
        {
            if (p1IsOn && p3IsOn && monkey1.isXPressed && monkey3.isXPressed)
            {
                dooropen.Play();
            }
        }
        if (monkey2.GetM2ReDKeyCount() == 1)
        {
            if (p2IsOn && p3IsOn && monkey2.isXPressed && monkey3.isXPressed)
            {
                dooropen.Play();
            }
        }
        if (monkey3.GetM3ReDKeyCount() == 1)
        {
            if (p2IsOn && p1IsOn && monkey2.isXPressed && monkey1.isXPressed)
            {
                dooropen.Play();
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        // && monkey1.GetM1ReDKeyCount() == 1  && monkey3.GetM3ReDKeyCount() == 1 && monkey1.isXPressed && monkey3.isXPressed
        if (other.tag == "Monkey1")
        {
            p1IsOn = false;
            //print("p1" + p1IsOn);
            // dooropen.Play();
        }
        if (other.tag == "Monkey3")
        {
            p3IsOn = false;
            //print("p3" + p3IsOn);
            // dooropen.Play();
        }
        if (other.tag == "Monkey2")
        {
            p2IsOn = false;
            //print("p3" + p3IsOn);
            // dooropen.Play();
        }
    }
}
