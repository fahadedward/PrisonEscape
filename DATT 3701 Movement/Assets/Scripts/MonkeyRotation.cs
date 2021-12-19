using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyRotation : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    Mover monkey = new Mover();
    [SerializeField]
    PickingUpAndThrowing throwing = new PickingUpAndThrowing();

    bool tossing = false;

    public float counter = 0.625f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (monkey.mover.magnitude > 0)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);

        }

       
        Vector3 currPos = transform.position;

        Vector3 newPos = new Vector3(monkey.mover.x, 0, monkey.mover.y);

        Vector3 posToLookAt = currPos + newPos;
        transform.LookAt(posToLookAt);

       // if (throwing.test)
       // {
       //     counter -= Time.deltaTime;
       //     print(counter);
       // }
    }

    public void monkeyThrow()
    {
        if (throwing.test)
        {
            animator.SetFloat("isThrowing", 1);
            Invoke("TestTubeThrow", 0.625f);
            
        }
    }

   
    void TestTubeThrow()
    {
        animator.SetFloat("isThrowing", 0);
        throwing.test = false;
        print(throwing.test);
       // if(counter <= 0)
       // {
        //    counter = 0.625f;
        //}
       
    }
}