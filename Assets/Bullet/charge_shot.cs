using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charge_shot : MonoBehaviour
{
    public bullet_behaviour bullet_behaviour;
    private GameObject player;
    private shooter[] shooters;
    public int dmg_mod;
    public int pen_mod;
    public float rof_mod;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shooters = player.GetComponentsInChildren<shooter>();

        if (Input.GetKey(KeyCode.Space))
        {
            bullet_behaviour.damage *= dmg_mod;
            bullet_behaviour.penetration += pen_mod;
            GetComponent<Renderer>().material.color = new Color32(247, 156, 64, 255);

        }
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            foreach (shooter _shooter in shooters)
            {
                _shooter.ROF = _shooter.def_rof * rof_mod;
            }
        }
        else
        {
            foreach (shooter _shooter in shooters)
            {
                _shooter.ROF = _shooter.def_rof;
            }
        }
    }
}
