using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyState
    {
        Move,
        Attack
    };

    public EnemyState state = EnemyState.Move;
    public GameObject targetPlayer;

    public int speed = 1;

    //SEARCH VARIABLES
    //================================
    
    //depth enemy can look at
    int viewField = 10;
    // radius of enemys view parameters(enemy bubble)
    public int radiusOfView = 10;

    //ATTACK VARIABLES
    //================================
    public int attackRange = 3;
    float lastShot = 0;
    float shootSpeed = 1;

    int strafeStart = 0;
    float strafeTime = 2;
    private int strafeDir = 0;

    // Use this for initialization
    void Start ()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        if (state == EnemyState.Move)
        {
            Debug.Log("MoveToTarg() + update");
            MovementToTarget();
        }
        else if (state == EnemyState.Attack)
        {
            Debug.Log("Attack() + update");
            Attack();
        }
	
	}

    

    void MovementToTarget()
    {
        // here the move to function is going toward the target dir
        MoveToTarget(targetPlayer.transform.position);
        // if he can see the target
        if (EnemyCanDetectTarget())
        {
            // player & enemy pos defined
            Vector3 playerTargPos = targetPlayer.transform.position;
            Vector3 enemyPos = transform.position;
            //enemy will check to see if the dist(a-b) is less than attack range = 3
            if (Vector3.Distance(playerTargPos, enemyPos) < attackRange)
            {
                state = EnemyState.Attack;
                Debug.Log("AttackRange= " + attackRange + " ->AttackState Entered in MoveToTargFunct");
            }
        }
        else
        {
            state = EnemyState.Move;
            
        }
    }

    void MoveToTarget(Vector3 targetPos)
    {
        // speed to set tempo of enemy movement
        float speed = 10.0f;
        float distance = 5.0f;

        // this will create a direction that will measure the dist between the player(target) and the enemy
        Vector3 direction = targetPlayer.transform.position - transform.position;
        // distance between 2 pts = mag
        distance = direction.magnitude;
        //sets to normalized value (= 1);
        direction = direction.normalized;
        Vector3 velocity = direction * speed * Time.fixedDeltaTime;
        transform.position += velocity;

        // will check to see if we need this functionality later
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    bool EnemyCanDetectTarget()
    {
        float negOne = -1.0f;
        // enemies forward direction// which is on x// going neg. from right screen to left screen
        Vector3 forward = transform.TransformDirection(negOne, 0, 0);
        Vector3 targetPlayerPos = targetPlayer.transform.position;
        Vector3 enemyPos = transform.position;

        Vector3 targetDirection = (targetPlayerPos - enemyPos).normalized;
        float angle = Vector3.Angle(forward, targetDirection);
        //if angle is less than view field = 10 units
        if (angle < viewField)
        {
            RaycastHit hit;
            // raycasting to see if enemy is in the radiusOfView(cone) = 10units
            if (Physics.Raycast(enemyPos, forward, out hit, radiusOfView))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    //if you hit something return true//else you have nothing in view
                    return true;
                }
            }

        }

        return false;
    }

    float something = 0;
    void Attack()
    {
        // enemy sees the target
        if (EnemyCanDetectTarget())
        {
            //move to attack range
            Vector3 playerTargetPos = targetPlayer.transform.position;
            Vector3 enemyPos = transform.position;
            // if dist(a-b) is greater than the attack range// enemy move toward player
            if (Vector3.Distance(playerTargetPos, enemyPos) > attackRange)
            {
                state = EnemyState.Move;
            }

            //shoot if the time of your lastShot(0) + shootSpeed(1) is greater than time// meaning shot every second//
            if (Time.time > lastShot + shootSpeed)
            {
                Shoot();
                lastShot = Time.time;
            }
            something = something + Time.fixedDeltaTime;
            
            //strafe
            enemyPos.y = Mathf.Cos(something * 2);
            transform.position = enemyPos;
        }
        else
        {
            state = EnemyState.Move;
        }
    }

    void Shoot()
    {
        Debug.Log("Bang Bang! You are dead");
    }
}
