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
    public TMP_Text expTEXT;
    public TMP_Text levelTEXT;
    public TMP_Text bombTEXT;
    public TMP_Text equippedText;
    public TMP_Text healthText;
    


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

        expTEXT.text  = Character.instanceCharacter.currentExperience.ToString() +"/" + Character.instanceCharacter.maxExperience.ToString();
        levelTEXT.text = Character.instanceCharacter.currentLevel.ToString();
        bombTEXT.text = Player.instancePlayer.BombEquipped.Stock.ToString();
        healthText.text = Character.instanceCharacter.currentHealth.ToString();

        if(Player.instancePlayer.BombEquipped.Type == "Default"){
            equippedText.text = "Equipped: Bomb";
        }
        else if(Player.instancePlayer.BombEquipped.Type == "Stopwatch"){
            equippedText.text = "Equipped: " + Player.instancePlayer.BombEquipped.Type;
        }
        else if(Player.instancePlayer.BombEquipped.Type == "Shot Augment"){
            equippedText.text = "Equipped: " + Player.instancePlayer.BombEquipped.Type;
        }
        else{
            equippedText.text = "Equipped: ";
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