using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float maxhp = 50;
    //player Status
    [Header("Player Status")]
    public float hp = 50;
    public float atk = 0;
    public float def = 10;
    public float speed = 5f;
    public float jumpPower = 1f;

    private int maxJump = 1;
    public int jumpCount = 0;

    bool _isTurn = true;

    private SpriteRenderer spriteRenderer;

    private Transform tf;
    [Header("Animation")]
    public Animator ani;

    private Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;
    bool isUnBeatTime = false;

    public GameObject[] guns;
    private GameObject curGun;
    public static bool IsControllable = true;

    //---------------------------------------------------[Override Function]
    //Initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        tf = transform;
        curGun = guns[0];
        curGun.SetActive(true);

        UIManager.instance.playerInfo.InitPlayerUI(this);
        
        // 플레이어 프로필 업데이트
        UIManager.instance.playerInfo.UpdateProfileUI(this);
    }

    //Graphic & Input Updates	
    void Update()
    {
        //Debug.Log("playertest");
        Jump();


        // // fall Charactor
        // if(transform.position.y <= -7)
        // {
        //     Destroy(gameObject);
        //     Debug.Log("GameOver");
        // }
    }

    //Physics engine Updates
    void FixedUpdate()
    {
        Move();
        

    }
    
    void Move()
    {
        if (!IsControllable) return;
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
        if (!IsControllable) return;
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

    public void SetForce(Vector2 force)
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(force, ForceMode2D.Impulse);
    }
    
    public void AddForce(Vector2 force)
    {
        rigid.AddForce(force, ForceMode2D.Force);
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
            
            //hp minus text
            UIManager.instance.hpInfo.PrintHpDown(transform, dmg);
            
            isUnBeatTime = true;
            StartCoroutine("UnBeatTime");

            if (hp <= 0)
            {
                Debug.Log("GameOver");
                Destroy(gameObject);
                GameOver();
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

    private void GameOver()
    {
        BGM.instance.PlayBGM("GameOver");
        SceneManager.LoadScene("GameOver");
    }
    public void SelectWeapon(int idx)
    {
        if (guns.Length <= GunSlot.selectGunNum) return;
        curGun.SetActive(false);


        guns[idx].gameObject.SetActive(true);

        curGun = guns[idx];
    }
}
