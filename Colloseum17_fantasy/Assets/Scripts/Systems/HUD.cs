using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    private PlayerData player = null;
    string slot1 = "[1] ";
    string slot1Name = "Empty ";
    string slot1Data = "";

    string slot2 = "[2] ";
    string slot2Name = "Empty ";
    string slot2Data = "";
    
    void Start()
    {
        player = FindObjectOfType<PlayerData>();
    }

    private void OnGUI()
    {
        if(player)
        {
            if(player.currentEquipableSlot1)
            {
                slot1Name = player.currentEquipableSlot1.equipName;
                slot1Data = " Fuel: " + player.currentEquipableSlot1.Fuel.ToString();
            }
            else
            {
                slot1Name = "Empty ";
                slot1Data = "";
            }

            if (player.currentEquipableSlot2)
            {
                slot2Name = player.currentEquipableSlot2.equipName;
            }
            else
            {
                slot1Name = "Empty ";
            }

            Rect pos = new Rect(20, 20, 200, 20);
            GUI.TextArea(pos, slot1 + slot1Name + slot1Data);
            
            pos.y += pos.height;
            GUI.TextArea(pos, slot2 + slot2Name + slot2Data);

            if(player.isAlive == false)
            {
                GUI.TextArea(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "GAME OVER!");
                if(GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10 + 20, 100, 20), "Go To Main Menu"))
                {
                    PoolManager.Instance.UnregisterAllPools();
                    DestroyImmediate(PoolManager.Instance.gameObject);
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
