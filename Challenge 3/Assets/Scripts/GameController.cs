using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float timeLeft = 30.0f;

    public Text Restart;
    public Text GameOver;
    public Text ScoreText;
    public Text Win;
    public Text TimeAttack;
    public Text HardMode;


    private bool hardOn;
    private bool keyOn;
    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {

        keyOn = false;
        gameOver = false;
        restart = false;
        Restart.text = "";
        GameOver.text = "";
        Win.text = "";
        TimeAttack.text = "Press 'E' to enter Time Attack mode";
        HardMode.text = "Press 'H' to enter Hard Mode";

        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());

    }
    void Update()
    {
        
        if (Input.GetKey("escape"))
            Application.Quit();

        if (Input.GetKey(KeyCode.E))
        {
            keyOn = true;
        }

        if (keyOn == true)
        {
            timerTrigger();
        }

        if (Input.GetKey(KeyCode.H))
        {
            hardOn = true;
            hardMode();
            
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Challenge3");
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.RandomRange(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(startWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                Restart.text = "Press 'T' to Reset";
                restart = true;
               
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100 && keyOn == false && hardOn == false)
        {

            hazardCount = 0;
            Win.text = "You win!" + System.Environment.NewLine + "Game Created By Tyler Barger";
            gameOver = true;
            restart = true;
            FindObjectOfType<MusicController>().Winner();
            FindObjectOfType<StarSpeed>().WinVelo();
        }

        if (score >= 300 && keyOn == false && hardOn == true)
        {

            hazardCount = 0;
            Win.text = "You win!" + System.Environment.NewLine + "Game Created By Tyler Barger";
            gameOver = true;
            restart = true;
            FindObjectOfType<MusicController>().Winner();
            FindObjectOfType<StarSpeed>().WinVelo();
        }


    }
    public void gameover()
    {
        GameOver.text = "Game Over!";
        gameOver = true;
        FindObjectOfType<MusicController>().Loser();
        FindObjectOfType<StarSpeed>().WinVelo();
    }

    public void timerTrigger()
    {
        waveWait = 1;
        TimeAttack.text = "Time Left:" + timeLeft.ToString();
        HardMode.text = "";
        timeLeft -= Time.deltaTime;
        FindObjectOfType<StarSpeed>().WinVelo();
        if (timeLeft < 0)
        {
            
            TimeAttack.text = "Time Left: 0";
            gameover();
        }
    }

    public void hardMode()
    {
        
        HardMode.text = "Hard Mode Enabled";
        hazardCount = 20;
        spawnWait = 0.2f;
        waveWait = 0;
        TimeAttack.text = "";
    }

}
