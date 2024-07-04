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
        // 적과 충돌시 충돌판정
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator EffectDelayedDestroy(ParticleSystem vfx)
    {
        yield return null;
        // 총알 타격시 이펙트
    }
}

