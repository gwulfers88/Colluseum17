using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class Pool : IPool
{
    #region Variables???
    public string prefabName;
    public int defaultSize;
    public bool canGrow;
    public PoolType type;

    public Queue<GameObject> inactive;
    public Queue<GameObject> active;
    #endregion

    #region Methods
    public Pool(PoolType type, string prefab, int initSize, bool Growable)
    {
        inactive = new Queue<GameObject>();
        active = new Queue<GameObject>();
        prefabName = prefab;
        defaultSize = initSize;
        canGrow = Growable;
        this.type = type;
    }

    public void InitPool()
    {
        for(uint index = 0; index < defaultSize; index++)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load(prefabName)) as GameObject;
            obj.SetActive(false);
            inactive.Enqueue(obj);
        }
    }

    public GameObject RequestObject()
    {
        GameObject obj = null;

        if(inactive.Count > 0)
        {
            obj = inactive.Dequeue();
            active.Enqueue(obj);
            obj.SetActive(true);
        }
        else
        {
            if (canGrow)
            {
                obj = GameObject.Instantiate(Resources.Load(prefabName)) as GameObject;
                active.Enqueue(obj);
                obj.SetActive(true);
            }
        }
        
        return obj;
    }
    
    public void DestroyObject()
    {
        if(active.Count > 0)
        {
            GameObject obj = active.Dequeue();
            obj.SetActive(false);
            inactive.Enqueue(obj);
        }
    }
    #endregion
}
