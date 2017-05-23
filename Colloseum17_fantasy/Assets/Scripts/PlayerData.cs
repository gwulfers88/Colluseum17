using UnityEngine;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public int lives = 0;
    public int speed = 0;
    public bool isAlive = true;
    public bool isGrounded = false;
    public bool isFlying = false;
    public Vector3 groundOffset = Vector3.down;
    public List<IEquipable> equipables = new List<IEquipable>();
    public Jetpack currentEquipableSlot1 = null;
    public Gun currentEquipableSlot2 = null;
}
