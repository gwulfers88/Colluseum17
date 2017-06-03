using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public float speed = 10;

    public void Shoot(Vector3 direction)
    {
        GameObject projCopy = PoolManager.Instance.RequestObjectFrom(PoolType.Bullet, transform.position);
        if (projCopy)
        {
            Rigidbody r = projCopy.GetComponent<Rigidbody>();
            r.AddForce(direction * speed, ForceMode.Impulse);

            Collider a = projCopy.GetComponent<Collider>();
            Collider b = transform.root.GetComponent<Collider>();

            Physics.IgnoreCollision(a, b);
        }
    }
}
