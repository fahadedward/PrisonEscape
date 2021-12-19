using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 25f;
    [SerializeField]
    Rigidbody rb;
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        Invoke("DestroyBullet", 4f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
