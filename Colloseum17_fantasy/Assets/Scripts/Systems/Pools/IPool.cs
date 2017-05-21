using UnityEngine;

public enum PoolType
{
    Enemy,
    Bullet,
    Pickup,
}

public interface IPool
{
    void InitPool();
    GameObject RequestObject();
    void DestroyObject();
}
