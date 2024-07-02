using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    private float bulletSpeed = 2f;
    private float bullletDamage;

    private bool isInit = false;

    private float timeCounter = 0f;

    private const float maxTime = 3f;

    public void Init(float speed, float dmg)
    {
        bulletSpeed = speed;
        bullletDamage = dmg;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �浹�� �浹����
    }

    private IEnumerator EffectDelayedDestroy(ParticleSystem vfx)
    {
        yield return null;
        // �Ѿ� Ÿ�ݽ� ����Ʈ
    }
}

