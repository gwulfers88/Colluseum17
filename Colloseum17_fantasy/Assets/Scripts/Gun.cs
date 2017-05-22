using UnityEngine;
using System.Collections;

public class Gun : IEquipable
{
    private string bulletPrefabName = string.Empty;
    public float speed = 20;
    private PlayerData player = null;

    public override IEquipable AddToInventory(PlayerData player)
    {
        this.player = player;
        type = EquipableType.LaserGun;
        Debug.Log("Picked up Gun");
        equipName = "Simple Laser Gun";
        bulletPrefabName = "laser";
        owner = player.gameObject;
        player.equipables.Add(this);

        if (player.currentEquipableSlot2 == null)
            player.currentEquipableSlot2 = this;

        PoolManager.Instance.RegisterPool(PoolType.Bullet, bulletPrefabName, 5);

        return this;
    }

    public override void RemoveFromInventory()
    {
        PlayerData player = owner.GetComponent<PlayerData>();
        player.equipables.Remove(this);
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && player.currentEquipableSlot2)
        {
            GameObject projCopy = PoolManager.Instance.RequestObjectFrom(PoolType.Bullet, transform.position);
            if (projCopy)
            {
                Rigidbody r = projCopy.GetComponent<Rigidbody>();
                r.AddForce(new Vector3(speed, 0, 0), ForceMode.Impulse);

                Collider a = projCopy.GetComponent<Collider>();
                Collider b = transform.root.GetComponent<Collider>();

                Physics.IgnoreCollision(a, b);
            }
        }
	}

    
}
