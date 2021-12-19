using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickingUpAndThrowing : MonoBehaviour
{
    [SerializeField]
    Transform destination;


    Mover mover;
    [SerializeField]
    Monkey monkey1;
    [SerializeField]
    Monkey monkey2;
    [SerializeField]
    Monkey monkey3;

    GameObject prefab;
    GameObject heldItem;
    [SerializeField]
    public int M1blueTTCount = 0;
    [SerializeField]
    int M2blueTTCount = 0;
    [SerializeField]
    int M3blueTTCount = 0;
    GameObject TestTube;

    private Vector3 currentMove;
    public bool isBPressed = false;

    bool cooldown;

    float throwSpeed = 700;

    public bool tossing = false;
    public bool test = false;

    public float counter = 0.625f;

    [SerializeField]
    MonkeyRotation throwss;

    [SerializeField]
    AudioSource monkeyThrow;
    private void Start()
    {
        prefab = Resources.Load("ThrownBlueTT") as GameObject;
        mover = GetComponent<Mover>();
        monkey1 = GetComponent<Monkey>();
        monkey2 = GetComponent<Monkey>();
        monkey3 = GetComponent<Monkey>();
        //TestTube = GameObject.FindGameObjectWithTag("BlueTestTube");
    }

    private Vector3 standThrow()
    {
        Vector3 throwing;
        if(mover.GetMoveDirection().magnitude <= 0.1f)
        {
            throwing = transform.forward;
            throwing = new Vector3(throwing.x, 0.3f, 0.3f);
        }
        else
        {
            throwing = currentMove;
            throwing = new Vector3(throwing.x, 0.3f, throwing.y);
        }
        return throwing;
    }
    
    private void OnUse(InputValue b)
    {

        isBPressed = b.isPressed;
        test = true;

        
        if (M1blueTTCount == 1)
        {

            if (mover.GetPlayerIndex() == 0 && isBPressed)
            {
                print(test);
                    throwss.monkeyThrow();
                    GameObject thrownItem = Instantiate(prefab) as GameObject;
                    thrownItem.transform.position = destination.transform.position;
                    Rigidbody rb = thrownItem.GetComponent<Rigidbody>();
                    Vector3 throwing = standThrow();
                print("yay");
                      if (!test) {
                    rb.AddForce(throwing.normalized * throwSpeed);
                                 }
                print("yay22");
                tossing = true;
                monkeyThrow.Play();
                Destroy(heldItem);
                    M1blueTTCount--;
                    print(test);

            }
            tossing = false;
        } 
        
        if(M2blueTTCount == 1)
        {
            if (mover.GetPlayerIndex() == 1 && isBPressed)
            {

                GameObject thrownItem = Instantiate(prefab) as GameObject;
                thrownItem.transform.position = destination.transform.position;
                Rigidbody rb = thrownItem.GetComponent<Rigidbody>();
                Vector3 throwing = standThrow();
                rb.AddForce(throwing.normalized * throwSpeed);
                //print(throwing);
                tossing = true;
                monkeyThrow.Play();
                Destroy(heldItem);
                M2blueTTCount--;
            }
            tossing = false;
        }
         if (M3blueTTCount == 1)
        {
            if (mover.GetPlayerIndex() == 2 && isBPressed)
            {

                GameObject thrownItem = Instantiate(prefab) as GameObject;
                thrownItem.transform.position = destination.transform.position;
                Rigidbody rb = thrownItem.GetComponent<Rigidbody>();
                Vector3 throwing = standThrow();
                rb.AddForce(throwing.normalized * throwSpeed);
                //print(throwing);
                tossing = true;
                monkeyThrow.Play();
                Destroy(heldItem);
                M3blueTTCount--;
            }
            tossing = false;
        }

    }
    //Throwing
    private void Update()
    {
        currentMove = mover.GetMoveDirection();
        TestTube = GameObject.FindGameObjectWithTag("BlueTestTube");
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1f);
        cooldown = false;
    }
    // PickingUp
    private void OnTriggerStay(Collider other)
    {
        if (cooldown)
        {
            return;
        }
        if (other.tag == "BlueTestTube" && monkey1.isXPressed && M1blueTTCount == 0)
        {
           // this.BlueTT.transform.position = this.destinationp1.transform.position;
            other.gameObject.transform.position = this.destination.transform.position; 
            other.gameObject.transform.parent = this.destination.transform;
           // this.BlueTT.transform.parent = GameObject.Find("Player1Destination").transform;
            cooldown = true;
            StartCoroutine(enumerator());
            M1blueTTCount++;
            heldItem = other.gameObject;


        }
        if (other.tag == "BlueTestTube" && monkey2.isXPressed && M2blueTTCount == 0)
        {
            other.gameObject.transform.position = this.destination.transform.position;
            other.gameObject.transform.parent = this.destination.transform;
            cooldown = true;
            StartCoroutine(enumerator());
            M2blueTTCount++;
            heldItem = other.gameObject;
        }
        if (other.tag == "BlueTestTube" && monkey3.isXPressed && M3blueTTCount == 0)
        {
            other.gameObject.transform.position = this.destination.transform.position;
            other.gameObject.transform.parent = this.destination.transform;
            cooldown = true;
            StartCoroutine(enumerator());
            M3blueTTCount++;
            heldItem = other.gameObject;
        } 
        if(tossing == true && other.tag == "BlueTestTube" && TestTube.transform.position == destination.transform.position)
        {
            Destroy(TestTube);
        }
        if (tossing == true && other.tag == "BlueTestTube" && TestTube.transform.position == destination.transform.position)
        {
            Destroy(TestTube);
        }
        if (tossing == true && other.tag == "BlueTestTube" && TestTube.transform.position == destination.transform.position)
        {
            Destroy(TestTube);
        }
    }
}
