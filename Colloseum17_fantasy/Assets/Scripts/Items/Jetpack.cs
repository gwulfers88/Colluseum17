using UnityEngine;
using System.Collections;
using System;

public class Jetpack : IEquipable
{
    public bool isEmpty = false;
    private int maxFuel = 100;
    [SerializeField]
    private float burnRate = 0;
    [SerializeField]
    private float fuel = 0;
    public float Fuel
    {
        set
        {
            fuel = Mathf.Clamp(value, 0.0f, maxFuel);
            isEmpty = (fuel > 0) ? false : true;
        }
        get
        {
            isEmpty = (fuel > 0) ? false : true;
            return fuel;
        }
    }

    public bool CanFly()
    {
        return !isEmpty;
    }

    public override IEquipable AddToInventory(PlayerData player)
    {
        type = EquipableType.Jetpack;
        Debug.Log("Picked up jetpack");
        fuel = maxFuel;
        burnRate = 0.05f;
        equipName = "Simple Jetpack";
        owner = player.gameObject;
        player.equipables.Add(this);
        
        if (player.currentEquipableSlot1 == null)
            player.currentEquipableSlot1 = this;

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
            fuel -= maxFuel * burnRate;
        fuel = Mathf.Clamp(fuel, 0.0f, maxFuel);
    }

    //void OnGUI()
    //{
    //    GUILayout.TextArea("JetFuel: " + Fuel);
    //}
}
