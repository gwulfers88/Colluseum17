using UnityEngine;

public enum PoolType
{
    Enemy,
    Bullet,
}

public interface IPool
{
    void InitPool();
    GameObject RequestObject();
    void DestroyObject();
}
