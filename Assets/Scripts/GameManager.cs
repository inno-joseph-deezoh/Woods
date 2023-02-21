using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public TextMeshProUGUI scoreText;
    public int score;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        Debug.Log(score);
    }
}
