using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movePower = 10f;
    public float jumpPower = 25f;

    private Rigidbody2D rb;
    private Animator anim;
    private int direction = 1;
    bool isJumping = false;
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (alive)
        {
            Run();
            Jump();
            Attack();

            if (!isJumping && rb.velocity.y == 0)
            {
                anim.SetBool("isJump", false);
            }
        }
        else
        {
            Restart();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            anim.SetBool("isJump", false);
            isJumping = false;
        }
    }

    void Run()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveVelocity = Vector3.zero;
        anim.SetBool("isRun", false);

        if (horizontalInput < 0)
        {
            direction = -1;
            moveVelocity = Vector3.left;
        }
        else if (horizontalInput > 0)
        {
            direction = 1;
            moveVelocity = Vector3.right;
        }

        transform.localScale = new Vector3(direction, 1, 1);
        if (!anim.GetBool("isJump") && moveVelocity != Vector3.zero)
            anim.SetBool("isRun", true);

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void Jump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0) && !anim.GetBool("isJump"))
        {
            isJumping = true;
            anim.SetBool("isJump", true);
            rb.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
        else if (rb.velocity.y == 0 && isJumping)
        {
            isJumping = false;
            anim.SetBool("isJump", false);
        }
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("attack");
        }
    }

    void Restart()
    {
        anim.SetTrigger("idle");
        anim.SetBool("isJump", false);
        alive = true;
    }

}





