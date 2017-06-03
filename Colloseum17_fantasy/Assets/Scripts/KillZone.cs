using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            PlayerData player = col.gameObject.GetComponent<PlayerData>();
            if(player)
            {
                player.lives = 0;
                player.isAlive = false;
            }
        }
    }
}
