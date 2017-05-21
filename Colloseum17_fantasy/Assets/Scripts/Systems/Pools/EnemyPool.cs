using UnityEngine;
using System.Collections;

public class EnemyPool : Pool
{
    public EnemyPool(PoolType type, string prefab, int initSize, bool Growable) :
        base(type, prefab, initSize, Growable)
    {
    }

    public GameObject RequestObject(Vector3 pos)
    {
        GameObject obj = null;
        obj = RequestObject();
        obj.transform.position = pos;
        return obj;
    }
}
