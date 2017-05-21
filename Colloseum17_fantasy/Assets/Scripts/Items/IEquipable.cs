using UnityEngine;
using System.Collections;

public enum EquipableType
{
    Jetpack,
    LaserGun,
}

public abstract class IEquipable : MonoBehaviour
{
    public string equipName = string.Empty;
    public GameObject owner = null;
    public EquipableType type;

    public abstract IEquipable AddToInventory(PlayerData player);
    public abstract void RemoveFromInventory();
}
