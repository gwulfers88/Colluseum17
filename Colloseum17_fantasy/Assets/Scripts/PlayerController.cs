using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerData))]
public class PlayerController : MonoBehaviour
{
    private PlayerData playerData = null;
    public LayerMask groundLayer;
    public Vector3 groundPoint;
    public Rigidbody rb;

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
        /*Jetpack jetpack = gameObject.AddComponent<Jetpack>();
        jetpack.AddToInventory(playerData);
        */
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    private void Update ()
    {
        playerData.isFlying = false;
        groundPoint = transform.position + playerData.groundOffset;
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W) && playerData.isGrounded && !playerData.isFlying)
            velocity += (playerData.speed * 10 ) * Vector3.up;
        if (Input.GetKey(KeyCode.A))
            velocity += playerData.speed * Vector3.left;
        if (Input.GetKey(KeyCode.S))
            velocity += playerData.speed * Vector3.down;
        if (Input.GetKey(KeyCode.D))
            velocity += playerData.speed * Vector3.right;

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeEquipment("Simple Jetpack");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Jetpack
            if(playerData.currentEquipable)
            {
                if(playerData.currentEquipable.type == EquipableType.Jetpack)
                {
                    Jetpack jetpack = (Jetpack)playerData.currentEquipable;
                    if (!jetpack.isEmpty)
                    {
                        jetpack.UseFuel();
                        playerData.isFlying = true;
                    }
                }
            }
        }
        
        if (!playerData.isGrounded && !playerData.isFlying)
            velocity += Vector3.down * 5.0f;

        if(playerData.isFlying)
        {
            velocity += Vector3.up * 5.0f;
        }

        transform.position += velocity * Time.deltaTime;
        //rb.velocity = velocity;
    }

    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundPoint, .01f, groundLayer).Length > 0)
        {
            Debug.Log("Found Floor");
            playerData.isGrounded = true;
            playerData.isFlying = false;
        }
        else
            playerData.isGrounded = false;
    }

    void ChangeEquipment(string name)
    {
        for(uint i = 0; i < playerData.equipables.Count; i++)
        {
            IEquipable equipment = playerData.equipables[(int)i];
            if(equipment.equipName == name)
            {
                playerData.currentEquipable = equipment;
                break;
            }
        }
    }

    void OnDrawGizmo()
    {
        Gizmos.DrawWireSphere(transform.position, .01f);
    }

    void OnGUI()
    {
        
    }
}
