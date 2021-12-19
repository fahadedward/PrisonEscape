using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scientist : MonoBehaviour
{
    [SerializeField]
    GameObject monkey1;
    [SerializeField]
    GameObject monkey2;
    [SerializeField]
    GameObject monkey3;
    [SerializeField]
    Transform caughtDestM1;
    [SerializeField]
    Transform caughtDestM2;
    [SerializeField]
    Transform caughtDestM3;

   

    [SerializeField]
    bool isFPressed;

    [SerializeField]
    GameObject destination;
    void Start()
    {
        
    }
     
    
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameManager.instance.Menu();
        }

      
    }

    
    public bool GetIsFPressed()
    {
        return isFPressed;
    }
    
    private void OnUseKeyboard(InputValue value)
    {
        isFPressed = value.isPressed;
    }
  
    private void OnControllerColliderHit(ControllerColliderHit hit)
{
    if(hit.gameObject.tag == "Monkey1" && isFPressed)
    {
            hit.gameObject.SetActive(false);
            monkey1.transform.position = caughtDestM1.transform.position;
            hit.gameObject.SetActive(true);
            print(hit.gameObject.tag);
    }
    if (hit.gameObject.tag == "Monkey2" && isFPressed)
    {
            hit.gameObject.SetActive(false);
            monkey2.transform.position = caughtDestM2.transform.position;
            hit.gameObject.SetActive(true);

            print(hit.gameObject.tag);
        }
    if (hit.gameObject.tag == "Monkey3" && isFPressed)
    {
            hit.gameObject.SetActive(false);

            monkey3.transform.position = caughtDestM3.transform.position;
            hit.gameObject.SetActive(true);

            print(hit.gameObject.tag);
        }
   
    } 
}
