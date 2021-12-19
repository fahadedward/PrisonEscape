using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed = 7f;

    //bool moving = false;
    public int playerIndex = 0;

    private CharacterController controller;

    public Vector3 moveDirection = Vector3.zero;
    

    public Vector2 mover;

   
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetPlayerIndex(int playerIndex)
    {
        this.playerIndex = playerIndex;
    }

    private void OnMovement(InputValue move)
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
      /* if(transform.position.y > 0.375f)
        {
            transform.rotation.y = 0.375f;
        }*/
        moveDirection = new Vector3(mover.x, 0, mover.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= MoveSpeed;
       
        controller.Move(moveDirection * Time.deltaTime);
    }
}
