using UnityEngine;
using System.Collections;

public class Pickupable : MonoBehaviour
{

    // Use this for initialization
    public int scoreValue;
    gameController scoreControll;
    bool hasScored = false;
    BoxCollider BottomCollider;

    void Start()
    {

        BottomCollider = GetComponent<BoxCollider>();


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
    void Update()
    {

        if (scoreControll.GameOver == true)
        {

            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;


        }


    }


    void OnTriggerEnter(Collider other)
    {
        if (!hasScored)
        {


            if (other.gameObject.tag == "Can")
            {
                Debug.Log("!!");

                scoreControll.AddScore(scoreValue);
                hasScored = true;

                gameObject.GetComponent<Rigidbody>().isKinematic = true;




            }
        }


    }

}
