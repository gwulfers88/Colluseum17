using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerData))]
public class PlayerController : MonoBehaviour
{
    private PlayerData playerData = null;
    public LayerMask groundLayer = 0;
    public Vector3 groundPoint = Vector3.zero;
    public Rigidbody rb = null;

    // Use this for initialization
	private void Start ()
    {
        playerData = GetComponent<PlayerData>();
        if (!playerData)
        {
            Debug.LogError("No Player Data Found!");
            Debug.Break();
        }
        groundPoint = transform.position + playerData.groundOffset;

        Gun gun = gameObject.AddComponent<Gun>();
        gun.AddToInventory(playerData);

        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    private void Update ()
    {
        playerData.isFlying = false;
        groundPoint = transform.position + playerData.groundOffset;
        Vector3 velocity = Vector3.zero;

        // Movement
        if (Input.GetKey(KeyCode.A))
            velocity += playerData.speed * Vector3.left;
        if (Input.GetKey(KeyCode.D))
            velocity += playerData.speed * Vector3.right;
        
        // Jump
        if (Input.GetKey(KeyCode.W) && playerData.isGrounded && !playerData.isFlying)
        {
            rb.AddForce(new Vector3(0, 0.20f * playerData.speed, 0), ForceMode.Impulse);
        }
        
        // Equipment
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeEquipment(1, "Simple Jetpack");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeEquipment(2, "Simple Laser Gun");
        }

        // Jetpack use
        if (Input.GetKey(KeyCode.Space) && CanFly())
        {
            playerData.isFlying = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space) && CanFly())
        {
            playerData.isFlying = false;
        }

        // Ground collision
        if (Physics.OverlapSphere(groundPoint, .15f, groundLayer).Length > 0)
        {
            playerData.isGrounded = true;
        }
        else
            playerData.isGrounded = false;
        
        // Fuel
        if(playerData.isFlying)
        {
            if(!CanFly())
            {
                playerData.isFlying = false;
            }
            else
            {
                Jetpack jetpack = playerData.currentEquipableSlot1;
                jetpack.UseFuel();
                rb.AddForce(new Vector3(0, 5f * playerData.speed, 0));
            }
        }
        
        transform.position += velocity * Time.deltaTime;
    }

    private bool CanFly()
    {
        bool Result = false;

        if (playerData.currentEquipableSlot1 == null)
            return Result;

        if(playerData.currentEquipableSlot1)
        {
            Jetpack jetpack = playerData.currentEquipableSlot1;
            Result = jetpack.CanFly();
        }

        return Result;
    }

    void ChangeEquipment(int slot, string name)
    {
        for(uint i = 0; i < playerData.equipables.Count; i++)
        {
            IEquipable equipment = playerData.equipables[(int)i];
            if(equipment.equipName == name)
            {
                if(slot == 1)
                    playerData.currentEquipableSlot1 = (Jetpack)equipment;
                else if (slot == 2)
                    playerData.currentEquipableSlot2 = (Gun)equipment;
                break;
            }
        }
    }
}
