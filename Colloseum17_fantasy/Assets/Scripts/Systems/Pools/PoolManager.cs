using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoSingleton<PoolManager>, IPoolManager
{
    private Dictionary<PoolType, Pool> pools = new Dictionary<PoolType, Pool>();
    
    private void Start()
    {
        gameObject.name = "PoolManager";
    }

    public void RegisterPool(PoolType type, string prefab, int size, bool sizeable = false)
    {
        if(!pools.ContainsKey(type))
        {
            Pool pool = null;

            if(type == PoolType.Bullet)
                pool = new BulletPool(type, prefab, size, sizeable);
            if (type == PoolType.Enemy)
                pool = new EnemyPool(type, prefab, size, sizeable);

            if (pool != null)
            {
                pools.Add(type, pool);
                pool.InitPool();
            }
        }
    }

    public void UnregisterAllPools()
    {
        foreach(KeyValuePair<PoolType, Pool> pair in pools)
        {
            pair.Value.Clear();
        }
    }

    public GameObject RequestObjectFrom(PoolType type)
    {
        GameObject obj = null;
        if (pools.ContainsKey(type))
        {
            obj = pools[type].RequestObject();
        }
        return obj;
    }

    public GameObject RequestObjectFrom(PoolType type, Vector3 pos, Vector3 dir = new Vector3())
    {
        GameObject obj = null;
        
        if(pools.ContainsKey(type))
        {
            if(type == PoolType.Bullet)
                obj = ((BulletPool)pools[type]).RequestObject(pos, dir);
            if(type == PoolType.Enemy)
                obj = ((EnemyPool)pools[type]).RequestObject(pos);
            if(type == PoolType.Pickup)
                obj = pools[type].RequestObject();
        }

        return obj;
    }

    public void DestroyObjectFrom(PoolType type)
    {
        if(pools.ContainsKey(type))
        {
            pools[type].DestroyObject();
        }
    }
}
