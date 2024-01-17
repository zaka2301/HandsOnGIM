using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    public static ExperienceManager instanceExperienceManager;
    // public delegate void ExperienceChangeHandler(int amount);
    // public event ExperienceChangeHandler OnExperienceChange;

    private void Awake()
    {   
        //Singleton check
        if(instanceExperienceManager != null && instanceExperienceManager != this){
            Destroy(this);
        }
        else{
            instanceExperienceManager = this;
        }
    }

    public void AddExperience(int amount){
        // Player.instancePlayer.HandleExperienceChange(amount);
        Character.instanceCharacter.HandleExperienceChange(amount);

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
