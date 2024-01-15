using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playzone : MonoBehaviour
{


    private void OnTriggerExit2D(Collider2D target)
    {
        GameObject go = target.gameObject;

        if(go.CompareTag("EnemyBullet")) {
            ObjectPoolManager.ReturnObjectToPool(go);
        }

        if(go.CompareTag("Enemy") || go.CompareTag("PlayerBullet")) {
            Destroy(go);
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
