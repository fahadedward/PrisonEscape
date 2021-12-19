using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTT : MonoBehaviour
{
    [SerializeField]
    ParticleSystem explosion;
    
    //MoverScientist scientist = new MoverScientist();

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "AddOn" || collision.collider.tag == "Scientist")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            DestroyObject();
           
        }
    }
}
