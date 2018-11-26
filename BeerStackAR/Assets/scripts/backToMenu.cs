using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class backToMenu : MonoBehaviour {


    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
