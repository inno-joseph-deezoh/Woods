using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public TextMeshProUGUI gameBarScore;
    public TextMeshProUGUI pausedScore;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI highScore;

    public int score;

    //gameobject variables
    public GameObject gameOver;
    public GameObject gameBar;
    public GameObject pausedMenu;
    public GameObject startMenu;
    public GameObject player;

    //boolean variables
    public bool gameStarted;
    public bool gameStopped;
    public bool isSpawning;
    public bool pullSpawn;
    public bool reStarted;
    public bool gamePaused;

    //level_index
    public static int gameIndex;


    private void Awake()
    {
        Instance = this;
        gameStarted = false;
        isSpawning = false;
        gameStopped = false;
        pullSpawn = false;
        reStarted = false;
        gamePaused = false;
        gameIndex = PlayerPrefs.GetInt("gameIndex", 1);
    }

    private void Start()
    {
        highScore.text = "" + PlayerPrefs.GetInt("HighScore", 0);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameStarted == true)
        {
            startMenu.SetActive(false);
            gameBar.SetActive(true);
            gameStopped = false;
            isSpawning = true;
        }

        if (gameStopped ==  true)
        {
            gameOver.SetActive(true);
            gameBar.SetActive(false);
            player.SetActive(false);
            isSpawning = false;
            gameOverScore.text = score.ToString();
        }

        if (gamePaused == true)
        {
            gameBar.SetActive(false);
            isSpawning = false;
            player.SetActive(false);
            pausedMenu.SetActive(true);
        }
    }

    public void IncreaseScore()
    {
        score++;
        gameBarScore.text = score.ToString();
        Debug.Log(score);
    }

    public void StartGame()
    {
        gameStarted = true;
        player.SetActive(true);
        //SpawnManager.Instance.SpawnObs();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
     public void PauseGame()
    {
        gameStarted = false;
        gamePaused = true;
        SpawnManager.Instance.DisableOnPause();
        pausedScore.text = score.ToString();
    }

    public void LoadScene()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        score = 0;
        SceneManager.LoadScene("Game");
    }
}
