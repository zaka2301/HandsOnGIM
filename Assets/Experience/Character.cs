using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    public int currentHealth, maxHealth, currentExperience, maxExperience, currentLevel, maxLevel;
    public static Character instanceCharacter;
    public ItemSelector itemSelectorScreen;

    private void Awake()
    {
        instanceCharacter = this;
    }

    void Start()
    {
        itemSelectorScreen = GameObject.FindGameObjectWithTag("ItemSelector").GetComponent<ItemSelector>();
    }


    public void HandleExperienceChange(int newExperience){
        if(currentLevel == maxLevel){
            currentExperience = 0;
        }
        else{
            currentExperience +=newExperience;
        }
        
        if(currentExperience >= maxExperience && currentLevel < maxLevel){
            LevelUp();
        }
    }

    private void LevelUp(){
        if(currentLevel < maxLevel){
            itemSelectorScreen.SelectItem();
            if(maxHealth < 5 ){
                maxHealth += 1;
                Player.health = maxHealth;
                currentHealth = maxHealth;
                Debug.Log(("Increased max health to: " + Player.health.ToString()));
            }
            currentLevel++;

            currentExperience = 0;
            maxExperience += 100;
            Debug.Log("You have level up to " + currentLevel.ToString() + "!");
        }
        else{
            currentExperience = 0;
            currentLevel = maxLevel;
        }
    }
    
    
}
