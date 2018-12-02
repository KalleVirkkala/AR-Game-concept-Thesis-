using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCan : MonoBehaviour {


    //variabler för tid mellan kast och spelobjektet
    public GameObject thrownObject;
    public float timeBetweenThrows = 0.5f;
    private float timestamp;


    public void throwCan()
    {
        //tid mellan kast 0.5 sekunder
        if (Time.time >= timestamp) { 
        
        //variabler för kamerans mittpunkt
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        // initiera en "Ray cast" (stråle) från kamerans mittpunkt
        Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
        
        // initiera en ny Hopskrynklad burk spelobjekt
        HitControll newThrowCan = Instantiate(thrownObject.gameObject).GetComponent<HitControll>();

        newThrowCan.transform.position = gameObject.transform.position;
        
        //sätt direktionen av hopskrynklade burk spel objektet med strålen som initerats från kameran mittpunkt
        newThrowCan.SetDirection(ray.direction);

            //förstör hoskrynklade burken 3 sekunder efter att den initialiserats.
            Destroy(newThrowCan, 3f);

        timestamp = Time.time + timeBetweenThrows;

        }
    }
}

