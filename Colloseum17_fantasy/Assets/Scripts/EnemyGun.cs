using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 2;

    public void Shoot()
    {
        // so the enemy can shoot more than once
        GameObject projCopy = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        
        //allows me to control the rigidbody
        Rigidbody r = projCopy.GetComponent<Rigidbody>();
        
        // creating dir in neg x dir//velocity will = direction by the speed(2)
        const float one = 1;
        Vector3 dir = transform.TransformDirection(new Vector3(-one,0,0));
        Vector3 velocity = dir * speed;
        
        //this will be the dir and speed the rigidbody is travelling
        r.velocity = velocity;
        
        //please ignore that you are hitting yourself//enemy cant kill itself
        Collider a = projCopy.transform.GetComponent<Collider>();
        Collider b = transform.root.GetComponent<Collider>();
        Physics.IgnoreCollision(a, b);

    }
}
