using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class large_shot : MonoBehaviour
{
    public bullet_behaviour bullet_behaviour;
    [SerializeField] float x_scale;
    [SerializeField] float y_scale;
    [SerializeField] float z_scale;
    public int dmg_mod;
    public int pen_mod;
    void Start()
    {
        bullet_behaviour.damage *= dmg_mod;
        bullet_behaviour.penetration += pen_mod;
        transform.localScale = new Vector3(x_scale, y_scale,z_scale);
    }

}
