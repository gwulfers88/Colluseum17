using UnityEngine;

public class FlyingSM : StateMachine
{
    // Variables / properties
    private MovementFlying moveState;
    private AttackFlying attackState;
    private DeathFlying deathState;
    public EnemyGun gun;

    public Transform transform;
    private float lives = 0;
    public float Lives
    {
        set { lives = value; }
        get { return lives; }
    }

    // Constructor
    public FlyingSM(Transform trans, int lives) : base()
    {
        transform = trans;
        Lives = lives;

        gun = transform.gameObject.AddComponent<EnemyGun>();

        moveState = new MovementFlying("Move", this);
        attackState = new AttackFlying("Attack", this);
        deathState = new DeathFlying("Death", this);

        AddState(moveState);
        AddState(attackState);
        AddState(deathState);

        ChangeState(moveState);
    }

    // Methods (update)

    //Needs a monobehaviour so that it can update() Gargoyle.cs ---> (in start method of monobehaviour) FlyingSM sm = new FlyingSM();
}
