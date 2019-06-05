using UnityEngine;
using System.Collections;

public class enemy_hp : MonoBehaviour
{
    public int health = 5;

    public Transform playerX;

    public float spawnRatio;

    private Animator anim;

    public Collider2D boxCollider;
    public Collider2D circleCollider;
    public Rigidbody2D rbEnemy;
    public Collider2D cameraDeathCollider;

    public bool outOfCamera;
    public bool walkingEnabled = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        playerX = GameObject.Find("Player").GetComponent<Transform>();
        spawnRatio = playerX.transform.position.x;
        spawnRatio += 15.48548f;

        cameraDeathCollider = GameObject.Find("MainCamera").GetComponent<CapsuleCollider2D>();
        outOfCamera = cameraDeathCollider.IsTouchingLayers(LayerMask.GetMask("enemy"));

        if (outOfCamera)
        {
            Destroy(this.gameObject);
        }

        if (spawnRatio >= transform.position.x)
        {
            StartCoroutine(spawn());
        } 
        if (health <= 0)
        {
            StartCoroutine(death());
        }
	}

    IEnumerator spawn()
    {
        anim.SetBool("spawn", true);
        yield return new WaitForSeconds(0.95f);
        anim.SetBool("walk", true);
        walkingEnabled = true;
        StopCoroutine(spawn());
    }

    IEnumerator death()
    {
        Destroy(boxCollider);
        Destroy(circleCollider);
        Destroy(rbEnemy);
        anim.SetBool("death", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
