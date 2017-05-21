using UnityEngine;

public interface IPoolManager
{
    void RegisterPool(PoolType type, string prefab, int size, bool sizeable = false);
    GameObject RequestObjectFrom(PoolType type);
}