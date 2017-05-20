using UnityEngine;
using System.Collections;
using System;

public class BulletPool : Pool
{
    public BulletPool(PoolType type, string prefab, int initSize, bool Growable) :
        base(type, prefab, initSize, Growable) { }
    
    public GameObject RequestObject(Vector3 pos, Vector3 direction)
    {
        GameObject obj = null;
        obj = RequestObject();
        obj.transform.position = pos;
        return obj;
    }
}
