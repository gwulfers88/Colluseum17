using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<string> prefabs = new List<string>();
    public List<PoolType> types = new List<PoolType>();
    public PoolManager poolManager = null;

    public float timer = 0;
    public float rate = 3;

    // Use this for initialization
    void Start ()
    {
        if (prefabs.Count != types.Count)
            Debug.LogError("Prefabs and Types count dont match!"); Debug.Break();

        for(int i = 0; i < prefabs.Count; i++)
        {
            string prefab = prefabs[i];
            PoolType type = types[i];
            poolManager.RegisterPool(type, prefab, 5);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer >= rate)
        {
            poolManager.RequestObjectFrom(PoolType.Bullet);
            timer = 0;
        }
	}
}