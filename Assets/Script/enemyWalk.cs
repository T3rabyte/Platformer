using UnityEngine;

public class enemyWalk : MonoBehaviour
{

    public float maxSpeed = 1f;
    public float stoppingDistance = 2f;

    public bool attacking = false;
    private float attackCd = 0.5f;
    private float attackTimer = 0;

    public Transform target;

    public bool inRange;
    public Collider2D attackTrigger;

    void Start()
    {

    }

    void Update()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();

        if (GetComponent<enemy_hp>().walkingEnabled == true)
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                if (GetComponent<enemy_hp>().health >= 1)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.position, maxSpeed * Time.deltaTime);
                }
            }
        }

        if (GetComponent<enemy_hp>().health >= 1)
        {
            inRange = attackTrigger.IsTouchingLayers(LayerMask.GetMask("player"));
        }

        if (inRange)
        {
            if (!attacking)
            {
                attacking = true;
                attackTimer = attackCd;
                GameObject.Find("GM").GetComponent<GM>().healthPlayer -= 1;
            }

            if (attacking)
            {
                if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;
                }
                else
                {
                    attacking = false;
                }
            }
        }
    }
}
