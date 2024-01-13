using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_zone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D target)
    {
        Debug.Log(target.name);
        if (target.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("daoi");
           //enemy_behaviour enemy = target.gameObject.GetComponent(typeof(enemy_behaviour)) as enemy_behaviour;
           //enemy.Damage(damage);
        }
    }
}
