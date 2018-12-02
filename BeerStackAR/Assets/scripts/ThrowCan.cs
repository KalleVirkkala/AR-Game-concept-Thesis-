using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCan : MonoBehaviour {


    GameObject mainCamera;
    public GameObject thrownObject;
    public float timeBetweenThrows = 0.5f;
    private float timestamp;
    Vector3 offset;
    // Use this for initialization
    void Start () {
       // mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

       
    }
	
	// Update is called once per frame
	void LateUpdate() {
       // transform.position = mainCamera.transform.position;


    }



    public void throwCan()
    {
        if (Time.time >= timestamp)
        {

            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));

            HitControll newThrowCan = Instantiate(thrownObject.gameObject).GetComponent<HitControll>();

            newThrowCan.transform.position = gameObject.transform.position;

            newThrowCan.SetDirection(ray.direction);

            Destroy(newThrowCan, 3f);

            timestamp = Time.time + timeBetweenThrows;

        }

    }
}

