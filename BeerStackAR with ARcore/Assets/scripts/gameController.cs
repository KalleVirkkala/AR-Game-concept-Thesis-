using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {
    private int score;
    private int highScore;
    public Text ScoreBox;
    public GameObject Can;
    public GameObject Enemy;
    private RaycastHit hit;
    public bool gamesceneSet;                 
    public Image dmgImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public int startHealth = 3;                            
    public int curHealth;
    public Vector3 size;
    bool damaged;
    public bool GameOver = false;
    public GameObject GameOverPanel;
 
    public GameObject SearchBox;
   // public GameObject newToster;
    public GameObject Coaster;

    // Use this for initialization
    void Start () {


        score = 0;
        UpdateScore();
        InvokeRepeating("spawnEnemy", 8, 8);


        curHealth = startHealth;

    }

    // Update is called once per frame
    void Update()
    {



        if (damaged)
        {
            dmgImage.color = flashColour;
        }
        else
        {

            dmgImage.color = Color.Lerp(dmgImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }


        damaged = false;


        if (GameOver)
        {
            GameOverPanel.gameObject.SetActive(true);

            

        }


        if (score > highScore) { 
        highScore = score;

        PlayerPrefs.SetInt("highscore", highScore);

            }

       /* if(score % 7 == 0 && score != 0) {


            SpawnNewToster();

        }*/

    }



    public void RestartGame()
    {
      
        SceneManager.LoadScene("GameSceneARcore");


    }
    public void MainMenu() {

        SceneManager.LoadScene("MainMenu");
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        curHealth -= amount;


        if (curHealth == 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            GameOver = true;
        }
    }
  /*  void SpawnNewToster(){
       
        Vector3 spawnPoint = new Vector3(0.2f, -1f, 0);
        Instantiate(newToster, spawnPoint, Quaternion.identity);

    }*/


    void spawnEnemy() {
        float Randx = Random.Range(size.x, size.y);
        float Randy = Random.Range(size.x, size.y);


        if (gamesceneSet) {

            SearchBox.gameObject.SetActive(false);
            Vector3 spawnPoint = new Vector3(Randx, -0.5f, Randy);
            GameObject enemy = Instantiate(Enemy, spawnPoint, Quaternion.identity);
            
     
        }
        

    }

    public void SpawnNewCan()
    {
        float Randx = Random.Range(-0.7f, 0.7f);
        float Randy = Random.Range(-0.7f, 0.7f);
        Vector3 spawnPoint = new Vector3(Randx, -0.5f, Randy);
        GameObject can = Instantiate(Can, spawnPoint, Quaternion.identity);

    }

  


    public void RemoveScore(int newScoreValue)
    {
        score -= newScoreValue;
        UpdateScore();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreBox.text = "Score: " + score.ToString();
    }
}
