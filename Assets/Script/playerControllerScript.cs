using UnityEngine;

public class playerControllerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeed = 10f;
    public bool facingRight = true;

    public Animator anim;

    public float jumpForce = 700f;
    public bool block = false;

    public bool isGrounded;

    public bool inRange;

    public Collider2D groundCheck;
    public Collider2D trapCheck;

    private float trap;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}

    void Update()
    {
        inRange = trapCheck.IsTouchingLayers(LayerMask.GetMask("trap"));

        anim.SetFloat("vSpeed", rb.velocity.y);

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        isGrounded = groundCheck.IsTouchingLayers(LayerMask.GetMask("ground"));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            anim.SetBool("Ground", isGrounded);
        }
        else
        {
            anim.SetBool("Ground", isGrounded);
        }

        if (Input.GetKey(KeyCode.W) && inRange)
        {
            rb.velocity = new Vector2(0, 6);
        }
        if (Input.GetKeyUp(KeyCode.W) && inRange)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
