using UnityEngine;

public class MovementFlying : State
{
    private FlyingSM flyingSM;
    private PlayerData player;
    private float speed = 0;

    public MovementFlying(string name, FlyingSM stateMachine) : base(name, stateMachine)
    {
        speed = Random.Range(5, 10);
        flyingSM = stateMachine;
    }

    public override void OnEnter()
    {
        player = GameObject.FindObjectOfType<PlayerData>();
    }

    public override void OnExit()
    {
        t = 0;
        player = null;
    }

    public override void OnFixedUpdate()
    {
        
    }

    float t = 0;
    public override void OnUpdate()
    {
        flyingSM.transform.position += Vector3.left * 5 * Time.deltaTime;
        flyingSM.transform.position += new Vector3(0.0f, Mathf.Cos(++t * 0.1f) * 2f * Time.deltaTime, 0.0f);
        
        float distance = (player.gameObject.transform.position - flyingSM.transform.position).magnitude;
        
        if (distance <= 3.0f)
        {
            flyingSM.ChangeState("Attack");
        }
    }
}
