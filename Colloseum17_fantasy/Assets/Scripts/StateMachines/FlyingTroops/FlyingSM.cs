using UnityEngine;

public class FlyingSM : StateMachine
{
    // Variables / properties
    private MovementFlying moveState;
    private AttackFlying attackState;
    private DeathFlying deathState;

    Transform transform;

    // Constructor
    public FlyingSM(Transform trans) : base()
    {
        transform = trans;

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
