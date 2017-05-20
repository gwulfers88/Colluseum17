using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public EquipableType type;

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Player"))
        {
            GameObject player = col.gameObject;
            if(type == EquipableType.Jetpack)
            {
                Jetpack pack = player.AddComponent<Jetpack>();
                pack.AddToInventory(player.GetComponent<PlayerData>());
                Destroy(this.gameObject);
            }
        }
    }
}
