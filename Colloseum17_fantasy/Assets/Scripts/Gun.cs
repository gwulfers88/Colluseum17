using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    GameObject projectile;
    public float speed = 2;
    
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projCopy = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
            Rigidbody r = projCopy.GetComponent<Rigidbody>();
            const float one = 1;
            Vector3 dist = transform.TransformDirection(new Vector3(one, 0, 0));
            Vector3 velocity = dist * speed;

            r.velocity = velocity;

            Collider a = projCopy.GetComponent<Collider>();
            Collider b = transform.root.GetComponent<Collider>();

            Physics.IgnoreCollision(a, b);

        }
	
	}
}
