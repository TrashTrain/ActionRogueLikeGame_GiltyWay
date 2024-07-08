using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private float bulletSpeed = 2f;
    private float bulletDamage;

    private bool isInit = false;

    private float timeCounter = 0f;

    private const float maxTime = 3f;

    public void Init(float speed, float dmg)
    {
        bulletSpeed = speed;
        bulletDamage = dmg;

    }
    private void Start()
    {
        
        transform.Rotate(0, 0, -90);
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(0f, bulletSpeed * Time.deltaTime, 0f, Space.Self);
        timeCounter += Time.deltaTime;
        if(timeCounter > maxTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 7)
        {
            Debug.Log(collision.gameObject.layer);
            if (collision.gameObject.layer == 9)
            {
                IDamageable enemy = collision.gameObject.GetComponent<IDamageable>();
                if (enemy != null)
                {
                    enemy.GetDamaged(bulletDamage);
                }
            }
            Destroy(gameObject);
            
        }
    }

    private IEnumerator EffectDelayedDestroy(ParticleSystem vfx)
    {
        yield return null;
        // �Ѿ� Ÿ�ݽ� ����Ʈ
    }
}

