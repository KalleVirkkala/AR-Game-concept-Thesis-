using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PickupObject : MonoBehaviour
{
    GameObject mainCamera;
    public bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    // Use this for initialization

    gameController gameController;



    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");



        // GetComponent<AudioSource>().loop = true;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<gameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying)
        {
            carry(carriedObject);
        }

    }

    void rotateObject()
    {
        carriedObject.transform.Rotate(5, 10, 15);
    }

    void carry(GameObject carry)
    {

        carry.transform.position = Vector3.Lerp(carry.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);

    }

    public void pickup()
    {




        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            Pickupable p = hit.collider.GetComponent<Pickupable>();
            if (p != null)
            {
                carrying = true;
                carriedObject = p.gameObject;
                carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
                carriedObject.transform.LookAt(mainCamera.transform);
                p.gameObject.GetComponent<BoxCollider>().enabled = false;
                p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                p.gameObject.GetComponent<Animation>().Play();
                p.gameObject.GetComponent<AudioSource>().Play(0);
            }
        }


    }




    public void dropObject()
    {
        if (carrying)
        {
            carriedObject.gameObject.GetComponent<BoxCollider>().enabled = true;
            carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
            carriedObject = null;
            carrying = false;

            gameController.SpawnNewCan();
        }
    }




}

