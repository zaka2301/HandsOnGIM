using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    private GameObject objPoolEmptyHolder;
    private static GameObject gameObjectsEmpty;
    public enum PoolType
    {
        Gameobject,
        None
    }
    public static PoolType PoolingType;

    private void Awake()
    {
        SetupEmpties();
    }

    private void SetupEmpties()
    {
        objPoolEmptyHolder = new GameObject("Pooled Objects");

        gameObjectsEmpty = new GameObject("GameObjects");
        gameObjectsEmpty.transform.SetParent(objPoolEmptyHolder.transform);
    }

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
    {
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpawn.name);

        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name};
            ObjectPools.Add(pool);
        }
    

    GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

    if (spawnableObj == null)
    {
        GameObject parentObject = SetParentObject(poolType);
        spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

        if (parentObject != null)
        {
            spawnableObj.transform.SetParent(parentObject.transform);
        }
    }
    else
    {
        spawnableObj.transform.position = spawnPosition;
        spawnableObj.transform.rotation = spawnRotation;
        pool.InactiveObjects.Remove(spawnableObj);
        spawnableObj.SetActive(true);
    }
    return spawnableObj;

    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);
        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);
        if(pool==null)
        {
            Debug.LogWarning("Obj not pooled: " + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }

    private static GameObject SetParentObject(PoolType poolType)
    {
        switch(poolType)
        {
            case PoolType.Gameobject:
                return gameObjectsEmpty;
            case PoolType.None:
            default:
                return null;
        }
    }
}

public class PooledObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
