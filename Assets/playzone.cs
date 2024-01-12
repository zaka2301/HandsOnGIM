using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playzone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D target)
    {

        {
           ObjectPoolManager.ReturnObjectToPool(target.gameObject);
        }
    }
}
