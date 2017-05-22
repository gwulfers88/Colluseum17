using UnityEngine;

public class DeathFlying : State
{
    FlyingSM flyingSM;
    float time4Death = 2;
    float timer = 0;

    public DeathFlying(string name, FlyingSM stateMachine) : base(name, stateMachine)
    {
        flyingSM = stateMachine;
        timer = 0;
    }

    public override void OnEnter()
    {
        timer = 0;
    }

    public override void OnExit()
    {
        timer = 0;
    }

    public override void OnFixedUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        flyingSM.transform.position += (Vector3.down) * 4 * Time.deltaTime;

        if(flyingSM.transform.position.y <= -5.0f)
            PoolManager.Instance.DestroyObjectFrom(PoolType.Enemy);
    }
}
