using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    float lifetime = 2;
    float damage = 1;
    GameObject projectile;

	// Use this for initialization
	void Start ()
    {
        Destroy(projectile, lifetime);
	}

    void OnCollEnter(Collision coll)
    {
        Destructable other = coll.gameObject.GetComponent<Destructable>();

        if (other != null)
        {
            other.DamageTakenDestroyEnemy(damage);
        }

        GameObject tempReplace;
        tempReplace = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        const float one = 1;
        Destroy(tempReplace, one);
        Destroy(tempReplace);
    }
}
