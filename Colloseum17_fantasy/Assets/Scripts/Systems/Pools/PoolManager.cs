using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public Dictionary<PoolType, Pool> pools = new Dictionary<PoolType, Pool>();
    
    public void RegisterPool(PoolType type, string prefab, int size, bool sizeable = false)
    {
        if(!pools.ContainsKey(type))
        {
            Pool pool = null;

            if(type == PoolType.Bullet)
                pool = new BulletPool(type, prefab, size, sizeable);

            if (pool != null)
            {
                pools.Add(type, pool);
                pool.InitPool();
            }
            else
            {
                Debug.LogError("Not able to Add pool");
                Debug.Break();
            }
        }
    }

    public GameObject RequestObjectFrom(PoolType type)
    {
        GameObject obj = null;
        
        if(pools.ContainsKey(type))
        {
            obj = pools[type].RequestObject();
        }

        return obj;
    }
}
