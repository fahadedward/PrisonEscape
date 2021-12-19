using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class playerInputHandler : MonoBehaviour { 
    private Mover mover;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var movers = FindObjectsOfType<Mover>();
        var index = playerInput.playerIndex;
        mover = movers.FirstOrDefault(mover => mover.GetPlayerIndex() == index);
    }

 

    public void OnMove(InputAction.CallbackContext context)
    {
        print("Moving");
        if (mover != null)
        {
          //  mover.SetInputVector(context.ReadValue<Vector2>());

        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        print("Jump");
        //if (mover != null)
        //{
        //    mover.SetInputVector(context.ReadValue<Vector2>());

       // }

    }

    public void PickUp(InputAction.CallbackContext context)
    {
        print("Pickup");
        //if (mover != null)
        //{
        //    mover.SetInputVector(context.ReadValue<Vector2>());

        // }

    }

    public void Use(InputAction.CallbackContext context)
    {
        print("Use");
        //if (mover != null)
        //{
        //    mover.SetInputVector(context.ReadValue<Vector2>());

        // }

    }


}
