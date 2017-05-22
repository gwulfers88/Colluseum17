using UnityEngine;
using System.Collections;

public class Gargoyle : MonoBehaviour
{
    FlyingSM flyingSM = null;

	// Use this for initialization
	void Awake ()
    {
        flyingSM = new FlyingSM(transform, 3);
	}
    
    private void OnEnable()
    {
        //transform.position = Vector3.zero;
        flyingSM.transform = transform;
        flyingSM.Lives = 3;
        flyingSM.ChangeState("Move");
    }
    
    // Update is called once per frame
    void Update ()
    {
        if(transform.position.x < -5.0f)
            flyingSM.ChangeState("Death");

        if (flyingSM.Lives < 1)
            flyingSM.ChangeState("Death");

        flyingSM.UpdateActiveState();
	}

    void FixedUpdate()
    {
        flyingSM.FixedUpdateActiveState();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.name.Contains("laser"))
        {
            Debug.Log("Damage");
            flyingSM.Lives--;
            return;
        }
    }
}
