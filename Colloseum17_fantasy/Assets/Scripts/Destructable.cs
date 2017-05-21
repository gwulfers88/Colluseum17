using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour
{
    public float healthPoints = 1;
    public GameObject replacement;

    public void DamageTakenDestroyEnemy(float damage)
    {
        // health will be assigned after damage
        healthPoints = healthPoints - damage;
        //if health is less than 0
        if (healthPoints <= 0)
        {
            // create an obj at the pos// note obj should be blank
            Instantiate(replacement, transform.position, transform.rotation);
            //hence destory gameobj
            Destroy(gameObject);
        }
    }
}
