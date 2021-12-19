using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverScientist : MonoBehaviour
{

    
    public float MoveSpeed = 10f;

    [SerializeField]
    Transform thrownBlueTT;

    //bool moving = false;

    private CharacterController controller;

    public Vector3 moveDirection = Vector3.zero;

    [SerializeField]
    GameObject blueTestTube;
    public Vector2 mover;
    float timer = 5f;
    Vector3 velocity;
    float rotationSpeed = 75;

    [SerializeField]
    AudioSource scientistHitSound;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        
    }
    private void Start()
    {
      
    }
    private void OnMoveKeyboard(InputValue move)
    {

        mover = move.Get<Vector2>();
    }

    public Vector3 GetMoveDirection()
    {
        return mover;
    }
    // Update is called once per frame
   
    void Update()
    { 
          moveDirection = new Vector3(mover.x, 0, mover.y);
          moveDirection = transform.TransformDirection(moveDirection);
          moveDirection *= MoveSpeed;
         
          controller.Move(moveDirection * Time.deltaTime);

       
        if (MoveSpeed == 4)
        {
            timer -= Time.deltaTime;
            print(timer);
            if (timer <= 0)
            {
                MoveSpeed = 10;
                timer = 5f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ThrownBTT")
        {
            MoveSpeed = 4f;
            scientistHitSound.Play();
            Destroy(blueTestTube);
        }
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ThrownBTT")
        {
            MoveSpeed = 4f;
            Destroy(blueTestTube);
        }
    }*/


}

