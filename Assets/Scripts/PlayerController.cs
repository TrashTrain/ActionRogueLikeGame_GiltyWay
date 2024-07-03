using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int maxhp = 50;
    //player Status
    public int hp = 50;
    public int atk = 10;
    public int def = 10;
    public float speed = 5f;

    public float jumpPower = 1f;

    private int maxJump = 1;
    public int jumpCount = 0;

    Transform tf;

    public Animator ani;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;

    //---------------------------------------------------[Override Function]
    //Initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        tf = transform;
    }

    //Graphic & Input Updates	
    void Update()
    {
        Jump();
        // fall Charactor
        if(transform.position.y <= -7)
        {
            Destroy(gameObject);
            Debug.Log("GameOver");
        }
    }

    //Physics engine Updates
    void FixedUpdate()
    {
        Move();
        
    }


    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        Vector2 mousePos = Input.mousePosition;

        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            ani.SetBool("IsRunning", true);
            moveVelocity = Vector3.left;

        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            ani.SetBool("IsRunning", true);
            moveVelocity = Vector3.right;
        }
        else
        {
            ani.SetBool("IsRunning", false);
        }

        if (target.x < tf.position.x)
        {
            tf.localScale = new Vector3(-0.6f, 0.6f, 0.6f);
        }
        else
        {
            tf.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }

        transform.position += moveVelocity * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")&&isJumping)
        {
            //Prevent Velocity amplification.
            rigid.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);

            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            if (++jumpCount >= maxJump)
            {
                isJumping = false;
            }
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            jumpCount = 0;
            isJumping = true;
        }
        if(collision.gameObject.layer == 9)
        {
            Vector2 attackedVelocity = Vector2.zero;
            if (collision.gameObject.transform.position.x > transform.position.x)
                attackedVelocity = new Vector2(-15f, 20f);
            else
                attackedVelocity = new Vector2(15f, 20f);
            
            rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);
            if(hp >=0)
                hp -= 2;
            else
            {
                Debug.Log("GameOver");
                Destroy(gameObject);
            }
            //var atkmove = new Vector2((-(collision.transform.position.x - transform.position.x) * 15f), 10f);
            //rigid.AddForce(atkmove, ForceMode2D.Impulse);
        }
    }
    
}
