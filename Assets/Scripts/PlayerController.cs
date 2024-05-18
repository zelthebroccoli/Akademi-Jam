using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float jumpPower = 20f; // Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        private int direction = 1;
        bool isJumping = false;
        private bool alive = true;
        public int maxHealth = 100;
        public int currentHealth = 0;
        

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            currentHealth = maxHealth;
        }

        public void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                anim.SetTrigger("hurt");
                if(direction == 1)
                {
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector2(5f,1f), ForceMode2D.Impulse);
                }
            }
            void Hurt()
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            
            }

            void Die()
            {

            anim.SetTrigger("die");
            alive = false;

            }

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

        private void OnTriggerEnter2D(Collider2D other)
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




