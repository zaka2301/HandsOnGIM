using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public GameObject gameOverScreen;
    public static GameHandler instanceGameHandler;
    private void Awake()
    {
        instanceGameHandler= this;
    }
    public void gameOver(){
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("You Died!");
    }
    public void Restart(){
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void Exit(){
        SceneManager.LoadScene("Title Screen");
    }
    
}
