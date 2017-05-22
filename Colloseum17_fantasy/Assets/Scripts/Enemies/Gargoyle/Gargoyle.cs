using UnityEngine;
using System.Collections;

public class Gargoyle : MonoBehaviour
{
    FlyingSM flyingSM = null;

	// Use this for initialization
	void Start ()
    {
        flyingSM = new FlyingSM(transform);
	}
	
	// Update is called once per frame
	void Update ()
    {
        flyingSM.UpdateActiveState();
	}

    void FixedUpdate()
    {
        flyingSM.FixedUpdateActiveState();
    }
}
