using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    float timer = 0;
    float lifetime = 2;
    float damage = 1;
    
    private void OnEnable()
    {
        Reset();
    }

    public void Reset()
    {
        timer = 0;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifetime)
        {
            Reset();
            PoolManager.Instance.DestroyObjectFrom(PoolType.Bullet);
        }
    }

    void OnCollisonEnter(Collision coll)
    {
        Destructable other = coll.gameObject.GetComponent<Destructable>();
        Debug.Log("hit other ");
        if (other != null)
        {
            other.DamageTakenDestroyEnemy(damage);
        }

        Reset();
        PoolManager.Instance.DestroyObjectFrom(PoolType.Bullet);
    }
}
