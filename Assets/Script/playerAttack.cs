using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public bool attacking = false;

    private float attackTimer = 0;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;

    private Animator anim;

    public bool inRange;
	
	void Awake ()
    {
        anim = gameObject.GetComponent<Animator>();
	}

    
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !attacking) 
        {
            attacking = true;
            attackTimer = attackCd;
            anim.SetBool("attack", attacking);

            inRange = attackTrigger.IsTouchingLayers(LayerMask.GetMask("enemy"));

            if (inRange)
            {
                GameObject.Find("Audio").GetComponentInChildren<audioScript>().audioSource.clip = GameObject.Find("Audio").GetComponentInChildren<audioScript>().attackHit1;
                GameObject.Find("Audio").GetComponentInChildren<audioScript>().audioSource.Play();
                GameObject.Find("skeleton(Clone)").GetComponent<enemy_hp>().health -= 1;
            }
            if (!inRange)
            {
                GameObject.Find("Audio").GetComponentInChildren<audioScript>().audioSource.clip = GameObject.Find("Audio").GetComponentInChildren<audioScript>().attackMiss;
                GameObject.Find("Audio").GetComponentInChildren<audioScript>().audioSource.Play();
            }
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
                anim.SetBool("attack", attacking);
            }
        }
	}
}
