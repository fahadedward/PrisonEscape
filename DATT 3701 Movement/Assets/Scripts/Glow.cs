using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    [SerializeField]
    Component glow;
    float size;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        size += Time.deltaTime;
       // this.GetComponent("Halo").
    }
}
