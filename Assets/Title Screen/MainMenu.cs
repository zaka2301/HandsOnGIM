using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame(){
        Debug.Log("Loading game...");
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
