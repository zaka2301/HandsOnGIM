using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    int score = 0;
    int highscore = 0;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.instancePlayer.PlayerIsAlive == true){
            // aliveScore(1);
        }
    }

    public void addScore(int pointvalue){
        score += pointvalue;
        scoreText.text = score.ToString();
        if (highscore < score){
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public void killScore(int pointvalue){
        score += pointvalue;
        scoreText.text = score.ToString();
        if (highscore < score){
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public void DmgScore(int pointvalue){
        score += pointvalue;
        scoreText.text = score.ToString();
        if (highscore < score){
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    // public void aliveScore(int pointvalue){
    //     score += pointvalue;
    //     scoreText.text = score.ToString();
    //     if (highscore < score){
    //         PlayerPrefs.SetInt("Highscore", score);
    //     }  
    // }



}