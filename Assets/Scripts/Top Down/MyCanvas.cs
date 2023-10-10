using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyCanvas : MonoBehaviour
{
    public static MyCanvas Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public TextMeshProUGUI scoreText;

    public void Start()
    {
        scoreText.text = "Scorw: 0";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }
}
