using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public TextMeshProUGUI gameScore;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI highScore;

    public int score;

    //gameobject variables
    public GameObject gameOver;
    public GameObject startMenu;
    public GameObject player;

    //boolean variables
    public bool gameStarted;
    public bool gameStopped;
    public bool isSpawning;

    //level_index
    public static int gameIndex;


    private void Awake()
    {
        Instance = this;
        gameStarted = false;
        isSpawning = false;
        gameStopped = false;
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
            gameScore.gameObject.SetActive(true);
            gameStopped = false;
            isSpawning = true;
        }

        if (gameStopped ==  true)
        {
            gameOver.SetActive(true);
            isSpawning = false;
            gameScore.gameObject.SetActive(false);
            gameOverScore.text = score.ToString();
        }
    }

    public void IncreaseScore()
    {
        score++;
        gameScore.text = score.ToString();
    }

    public void StartGame()
    {
        gameStarted = true;
        SpawnManager.Instance.SpawnObs();
    }

    public void QuitGame()
    {
        Application.Quit();
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
