using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playzone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D target)
    {

        if(target.gameObject.CompareTag("EnemyBullet")) {
           ObjectPoolManager.ReturnObjectToPool(target.gameObject);
        }
        if(target.gameObject.CompareTag("Enemy")) {
           Destroy(target.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.CompareTag("Enemy"))
        {
           enemy_behaviour enemy = target.gameObject.GetComponent(typeof(enemy_behaviour)) as enemy_behaviour;
           enemy.in_zone = true;
        }
    }
}
