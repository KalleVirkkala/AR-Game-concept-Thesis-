﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    gameController scoreControll;
    Transform Toster;
    int scoreValue = 2;
    public float movespeed;
    bool dead;


    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        scoreControll = gameControllerObject.GetComponent<gameController>();
        Toster = GameObject.FindGameObjectWithTag("Toster").transform;



    }
	
	// Update is called once per frame
	void Update () {

        if (!dead) { 
        transform.LookAt(Toster);
        transform.position = Vector3.MoveTowards(transform.position, Toster.position, movespeed * Time.deltaTime);

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
        

           if(other.gameObject.tag == "Toster")
        { 
        
            scoreControll.TakeDamage(1);
            death();
        }
          
    }       





        
        


    
}