using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public TextMeshProUGUI scoreText;
    public int score;

    public GameObject gameOver;
    public GameObject gameBar;
    public GameObject pausedMenu;
    public GameObject startMenu;
    public GameObject player;

    public bool gameStarted;
    public bool gameStopped;
    public bool isSpawning;
    public bool pullSpawn;
    public bool reStarted;
    public bool gamePaused;



    private void Awake()
    {
        Instance = this;
        gameStarted = false;
        isSpawning = false;
        gameStopped = false;
        pullSpawn = false;
        reStarted = false;
        gamePaused = false;
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
            ShowUI();
            isSpawning = false;
        }

        if (reStarted == true)
        {
            gameOver.SetActive(false);
            gameBar.SetActive(true);
            gameStopped = false;
            isSpawning = false;
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
        scoreText.text = score.ToString();
    }

    public void ShowUI()
    {
        gameOver.SetActive(true);
        gameBar.SetActive(false);
        player.SetActive(false);
    }

    public void StartGame()
    {
        gameStarted = true;
        player.SetActive(true);
        SpawnManager.Instance.SpawnObs();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        reStarted = true;
        player.SetActive(true);
        SpawnManager.Instance.Respawn();
    }

    public void Resume()
    {
        SpawnManager.Instance.EnableOnResume();
        gameStarted = true;
    }
     public void PauseGame()
    {
        gameStarted = false;
        gamePaused = true;
        SpawnManager.Instance.DisableOnPause();
    }

}
