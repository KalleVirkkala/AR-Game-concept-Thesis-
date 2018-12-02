using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
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
    Vector3 Coaster;

    // Use this for initialization
    void Start () {


        score = 0;
        UpdateScore();

        
        curHealth = startHealth;
    
       InvokeRepeating("spawnEnemy", 8f, 6f);
         Coaster = GameObject.FindGameObjectWithTag("Toster").transform.position;
    }
	
	// Update is called once per frame
	void Update () {


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
        

    }
    public void GameSceneSet( bool set)
    {
        gamesceneSet = set;

    }


    public void RestartGame()
    {

        SceneManager.LoadScene("GameScene");


    }
    public void MainMenu()
    {

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


    void spawnEnemy()
    {


        float Randx = Random.Range(-size.x, size.x);
        float Randy = Random.Range(-size.z, size.z);

        if (gamesceneSet)
        {

            Vector3 spawnPoint = Coaster + new Vector3(Randx, -0.5f, Randy);

            Instantiate(Enemy, spawnPoint, Quaternion.identity);


        }
    }
    public void SpawnNewCan()
    {
       
        float Randx = Random.Range(-1f, 1f);
        float Randy = Random.Range(-1f, 1f);
        Vector3 spawnPoint = new Vector3(Randx, -0.5f, Randy);
        var can = Instantiate(Can, spawnPoint, Quaternion.identity);
       
    
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
