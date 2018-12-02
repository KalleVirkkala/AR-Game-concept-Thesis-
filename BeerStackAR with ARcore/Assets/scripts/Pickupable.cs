using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour {

    // Use this for initialization
    public int scoreValue;
    gameController scoreControll;
    bool hasScored = false;
    
    void Start () {


        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            scoreControll = gameControllerObject.GetComponent<gameController>();
        }
        if (scoreControll == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {

        //checkIfStacked();

        if (scoreControll.GameOver == true) {

            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;


        }


    }
    /*
    void checkIfStacked() {

        if (scoreControll.hasBeenStacked == true)
        {
            
            Destroy(gameObject, 3f);
            scoreControll.hasBeenStacked = false;

        }

    }*/
    
    void OnTriggerEnter(Collider other)
    {
        if (!hasScored) {
       

              if (other.gameObject.tag == "Can"|| other.gameObject.tag == "Coaster") {
               
                scoreControll.SpawnNewCan();
              
                scoreControll.AddScore(scoreValue);
                hasScored = true;
                
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                
               


            }
        }

      
}

}
