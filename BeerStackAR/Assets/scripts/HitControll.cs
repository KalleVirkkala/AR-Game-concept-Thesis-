using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitControll : MonoBehaviour {

    // Use this for initialization
    Rigidbody rb;
    public float bulletForce;
    bool firstTime = false;
    Vector3 direction;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.GetComponent<AudioSource>().Play(0);
    }


    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        firstTime = true;
    }


    void FixedUpdate()
    {
        if (firstTime)
        {
            rb.AddForce(direction * bulletForce);
            firstTime = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyMovement>().death();
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject, 4f);

        }
        
    }
}
