using UnityEngine;

public class AttackFlying : State
{
    PlayerData player;
    FlyingSM flyingSM;

    float shootRate = 1;
    float shootTimer = 0;
    float speed = 0;

    public AttackFlying(string name, FlyingSM stateMachine) : base(name, stateMachine)
    {
        speed = Random.Range(2, 5);
        flyingSM = stateMachine;
    }

    public override void OnEnter()
    {
        shootTimer = 0;
        player = GameObject.FindObjectOfType<PlayerData>();
    }

    public override void OnExit()
    {
        shootTimer = 0;
        player = null;
    }

    public override void OnFixedUpdate()
    {
        
    }

    public override void OnUpdate()
    {
        flyingSM.transform.position += Vector3.left * 2 * Time.deltaTime;

        Vector3 direction = player.gameObject.transform.position - flyingSM.transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        if (distance >= 3.0f)
        {
            flyingSM.ChangeState("Move");
        }

        shootTimer += Time.deltaTime;
        if (shootTimer >= shootRate)
        {
            shootTimer = 0;
            flyingSM.gun.Shoot(direction);
        }
    }
}
