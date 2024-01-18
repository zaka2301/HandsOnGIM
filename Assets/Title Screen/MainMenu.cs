using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void playGame(){
        Debug.Log("Loading game...");
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1.0f;
    }

    public void QuitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    //PlayerPrefs example method 
    public void SaveData(){
        // Can save 3 types
        // PlayerPrefs.SetFloat("PlayerMaxHealth", 100f );
        // PlayerPrefs.SetString("Input", inputField.text);
        // PlayerPrefs.SetInt();
    }

    public void LoadData(){
        // InputField.txt = PlayerPrefs.GetString("Input");
    }

    public void DeleteData(){
        // PlayerPrefs.DeleteKey("Input"); // Delete specific keys
        PlayerPrefs.DeleteAll();  //Delete all keys
    }
    //Reset Highscore
    public void resetPref(){
        PlayerPrefs.DeleteKey("Highscore");
        Debug.Log("PlayerPref Resetted!");

    }
}
