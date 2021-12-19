using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    MoverScientist scientist = new MoverScientist();
    Animator animator;
    [SerializeField]
    Transform firingPoint;
    [SerializeField]
    GameObject bullet;
    bool shooting = false;

    [SerializeField]
    AudioSource shootingSound;
    float timer = 5f;
    GameObject clone;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.33f);
        Shoot();
    }

    IEnumerator animStandEnd()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("isStandShoot", false);
    }
    IEnumerator animRunEnd()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("isShooting", false);
    }
    void Timer()
    {

    }
    // Update is called once per frame
    void Update()
    {

        Vector3 currPos = transform.position;

        Vector3 newPos = new Vector3(scientist.mover.x, 0, scientist.mover.y);

        Vector3 posToLookAt = currPos + newPos;
        transform.LookAt(posToLookAt);
        //Quaternion.slerp
        if (scientist.mover.magnitude >= 0.1)
        {
            animator.SetBool("isSRunning", true);

        }
        else
        {
            animator.SetBool("isSRunning", false);

        }
        if (scientist.mover.magnitude == 0 && timer == 5)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isStandShoot", true);
                Invoke("Shoot", 0.3f);
            }
           
            // StartCoroutine(waitTime());
        }
        else
        {
            StartCoroutine(animStandEnd());
        }
        if (Input.GetKey(KeyCode.Space) && timer == 5)
        {
            Invoke("PlayingAnimation", 0.01f);
            Invoke("Shoot", 0.6f);
            
        }
       
        else
        {
            StartCoroutine(animRunEnd());
            
        }
        
        if (shooting)
        {
            timer -= Time.deltaTime;
            print(timer);
        }
        if (timer <= 0)
        {
            print("entered");
            timer = 5f;
            shooting = false;
        }
    }

    void Shoot()
    {
        if (clone != null)
        {
            return;
        }
            
        else
        {
            shootingSound.Play();
            clone = Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
            shooting = true;   
        }       
    }
    void PlayingAnimation()
    {
        animator.SetBool("isShooting", true);
    }
}
