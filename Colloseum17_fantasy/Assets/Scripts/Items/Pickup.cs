using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    public EquipableType type;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.up);
    }

    private void OnTriggerEnter(Collider player)
    {
        if(player.CompareTag("Player"))
        {
            GameObject playerObj = player.gameObject;
            if(type == EquipableType.Jetpack)
            {
                Jetpack pack = playerObj.GetComponent<Jetpack>();
                if (pack == null)
                {
                    pack = playerObj.AddComponent<Jetpack>();
                    pack.AddToInventory(player.GetComponent<PlayerData>());
                }
                else
                {
                    if (pack.Fuel < 100)
                        pack.Fuel += Random.Range(20, 100);
                    else
                    {
                        // Points??
                        return;
                    }
                }

                Destroy(this.gameObject);
            }
        }
    }
}
