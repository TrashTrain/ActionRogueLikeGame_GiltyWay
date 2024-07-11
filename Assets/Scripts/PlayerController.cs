using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float maxhp = 50;
    //player Status
    [Header("Player Status")]
    public float hp = 50;
    public float atk = 10;
    public float def = 10;
    public float speed = 5f;
    public float jumpPower = 1f;

    private int maxJump = 1;
    public int jumpCount = 0;

    bool _isTurn = true;

    private SpriteRenderer spriteRenderer;

    Transform tf;
    [Header("Animation")]
    public Animator ani;

    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;
    bool isUnBeatTime = false;

    public GameObject[] guns;

    //---------------------------------------------------[Override Function]
    //Initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        tf = transform;
        
        UIManager.instance.playerInfo.InitPlayerUI(this);
    }

    //Graphic & Input Updates	
    void Update()
    {
        //Debug.Log("playertest");
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

        if (target.x < tf.position.x && _isTurn)
        {
            _isTurn = false;
            tf.Rotate(0f, 180f, 0f);
            
        }
        if (target.x > tf.position.x && !_isTurn)
        {
            _isTurn = true;
            tf.Rotate(0f, 180f, 0f);
            
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

    public void GetDamaged(float dmg, GameObject enemy, Vector2 attackPower)
    {
        if (!isUnBeatTime && attackPower != null)
        {
            rigid.AddForce(attackPower, ForceMode2D.Impulse);
        }
        if (!isUnBeatTime)
        {
            hp -= dmg;
            UIManager.instance.playerInfo.SetHp(hp);
            isUnBeatTime = true;
            StartCoroutine("UnBeatTime");

            if (hp <= 0)
            {
                Debug.Log("GameOver");
                Destroy(gameObject);
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
        
    }
    
    IEnumerator UnBeatTime()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.2f);

            countTime++;
        }

        spriteRenderer.color = new Color32(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
    }
}
