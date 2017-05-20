using UnityEngine;
using System.Collections;
using System;

public class Jetpack : IEquipable
{
    public bool isEmpty = false;
    private int fuel = 100;
    public int Fuel
    {
        set
        {
            fuel = Mathf.Clamp(value, 0, 100);
            isEmpty = fuel > 0 ? false : true;
        }
        get { return fuel; }
    }

    public override IEquipable AddToInventory(PlayerData player)
    {
        type = EquipableType.Jetpack;
        Debug.Log("Picked up jetpack");
        fuel = 100;
        equipName = "Simple Jetpack";
        owner = player.gameObject;
        player.equipables.Add(this);
        return this;
    }

    public override void RemoveFromInventory()
    {
        PlayerData player = owner.GetComponent<PlayerData>();
        player.equipables.Remove(this);
    }

    public void UseFuel()
    {
        if (!isEmpty)
            fuel -= 1;
    }
}
