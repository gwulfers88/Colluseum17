using UnityEngine;
using System.Collections;

public enum EnemyType
{
    Flying,
    Ground,
}

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 3;
    private float timer = 0;
    public string prefabName = string.Empty;
    public int poolSize = 0;
    
    private void Start()
    {
        PoolManager.Instance.RegisterPool(PoolType.Enemy, prefabName, poolSize);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnRate)
        {
            timer = 0;
            PoolManager.Instance.RequestObjectFrom(PoolType.Enemy, transform.position);
        }
    }
}
