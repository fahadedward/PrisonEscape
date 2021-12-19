using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    GameObject portal;

    [SerializeField]
    AudioSource portalSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monkey1")
        {
            bool asd1 = other.GetComponent<Monkey>().teleportMonkey[0];
            if (!asd1)
            {
                other.gameObject.SetActive(false);
                other.transform.position = portal.transform.position;
                other.gameObject.SetActive(true);
                other.GetComponent<Monkey>().DisablingPortal(0);
                portalSound.Play();
            }     
        }
        if (other.tag == "Monkey2")
        {
            bool asd2 = other.GetComponent<Monkey>().teleportMonkey[1];
            if (!asd2)
            {
                other.gameObject.SetActive(false);
                other.transform.position = portal.transform.position;
                other.gameObject.SetActive(true);
                other.GetComponent<Monkey>().DisablingPortal(1);
                portalSound.Play();
            }
        }
        if (other.tag == "Monkey3")
        {
            bool asd3 = other.GetComponent<Monkey>().teleportMonkey[2];
            if (!asd3)
            {
                other.gameObject.SetActive(false);
                other.transform.position = portal.transform.position;
                other.gameObject.SetActive(true);
                other.GetComponent<Monkey>().DisablingPortal(2);
                portalSound.Play();
            }
        }
        /* if (other.tag == "Monkey2" && !teleportMonkey[1])
         {
             portal.GetComponent<Portal>().DisablingPortal(1);
             other.gameObject.SetActive(false);
             other.transform.position = portal.transform.position;
             other.gameObject.SetActive(true);
             teleportMonkey[1] = true;
         }

         if (other.tag == "Monkey3"  && !teleportMonkey[2])
         {
             portal.GetComponent<Portal>().DisablingPortal(2);
             other.gameObject.SetActive(false);
             other.transform.position = portal.transform.position;
             other.gameObject.SetActive(true);
             teleportMonkey[2] = true;
         } */

    }
}
