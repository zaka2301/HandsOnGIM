using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModToggle : MonoBehaviour
{
    public static bool LargeToggle = false;
    public static bool TrackingToggle = false;
    public static bool ChargeToggle = false;
    public static bool WideToggle = false;
    public static bool ShooterTimerReset = false;
    public GameObject[] wideshooter;
    public GameObject ItemSelectorScreen;

    private void Start()
    {
        //wideshooter = GameObject.FindGameObjectsWithTag("WideShooter");
    }
    public void _LargeToggle()
    {
        LargeToggle = true;
        Time.timeScale = 1f;
        ItemSelectorScreen.SetActive(false);
    }
    public void _TrackingToggle()
    {
        TrackingToggle = true;
        Time.timeScale = 1f;
        ItemSelectorScreen.SetActive(false);
    }
    public void _ChargeToggle()
    {
        ChargeToggle = true;
        Time.timeScale = 1f;
        ItemSelectorScreen.SetActive(false);
    }
    public void _WideToggle()
    {
        WideToggle = true;
        ShooterTimerReset = true;
        foreach (GameObject shooter in wideshooter)
        {
            shooter.SetActive(WideToggle);
        }
        Time.timeScale = 1f;
        ItemSelectorScreen.SetActive(false);
    }
}
