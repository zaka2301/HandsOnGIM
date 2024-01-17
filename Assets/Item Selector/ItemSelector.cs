using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ItemSelector : MonoBehaviour
{
    public static ItemSelector instanceItemSelector;
    public GameObject ItemSelectorScreen;

    void Awake()
    {
        instanceItemSelector = this;
    }

    public void SelectItem(){
        ItemSelectorScreen.SetActive(true);
        Time.timeScale = 0f;

    }
    public void AugmentBomb(){
        Player.instancePlayer.BombEquipped.Type = "Shot Augment";
        Player.instancePlayer.BombEquipped.Stock = 3;
        Time.timeScale = 1f;
        ItemSelectorScreen.SetActive(false);
    }

    public void StopwatchBomb(){
        Player.instancePlayer.BombEquipped.Type = "Stopwatch";
        Player.instancePlayer.BombEquipped.Stock = 3;
        Time.timeScale = 1f;
        ItemSelectorScreen.SetActive(false);
    }

    public void DefaultBomb(){
        Player.instancePlayer.BombEquipped.Type = "Default";
        Player.instancePlayer.BombEquipped.Stock = 3;
        Time.timeScale = 1f;
        ItemSelectorScreen.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
