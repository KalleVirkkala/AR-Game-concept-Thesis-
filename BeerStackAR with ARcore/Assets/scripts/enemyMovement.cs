using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    gameController gameControl;
    Transform Coaster;
    public float movespeed;
    bool dead;


    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        gameControl = gameControllerObject.GetComponent<gameController>();
        Coaster = GameObject.FindGameObjectWithTag("Coaster").transform;

    }
	
	// Update is called once per frame
	void Update () {

        if (!dead) { 
        transform.LookAt(Coaster);
        transform.position = Vector3.MoveTowards(transform.position, Coaster.position, movespeed * Time.deltaTime);

        }

    }


    public void death()
    {

            dead = true;
            gameObject.GetComponent<ParticleSystem>().Play();
             gameObject.GetComponent<AudioSource>().Play(0);
            Destroy(gameObject,1);
    }

    private void OnTriggerEnter(Collider other)
    {

           if(other.gameObject.tag == "Coaster")
        {
            gameControl.TakeDamage(1);
            death();
        }
          
    }       





        
        


    
}
