using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class showHighscore : MonoBehaviour {
    TextMeshProUGUI TextPro;
   
	// Use this for initialization
	void Start () {

        TextPro = gameObject.GetComponent<TextMeshProUGUI>();
       
    }
	
	// Update is called once per frame
	void Update () {
        setHighscore();
        
	}
    void setHighscore() {

        int highScore = PlayerPrefs.GetInt("highscore", 0);
		TextPro.text = "Highscore: "+ highScore;
    }
}
