using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModToggle : MonoBehaviour
{
    public static bool LargeToggle = false;
    public static bool TrackingToggle = false;
    public static bool ChargeToggle = false;
    public static bool WideToggle = false;
    public GameObject[] wideshooter;

    private void Start()
    {
        //wideshooter = GameObject.FindGameObjectsWithTag("WideShooter");
    }
    public void _LargeToggle()
    {
        LargeToggle = !LargeToggle;
    }
    public void _TrackingToggle()
    {
        TrackingToggle = !TrackingToggle;
    }
    public void _ChargeToggle()
    {
        ChargeToggle = !ChargeToggle;
    }
    public void _WideToggle()
    {
        WideToggle = !WideToggle;
        foreach (GameObject shooter in wideshooter)
        {
            shooter.SetActive(WideToggle);
        } 
    }
}
