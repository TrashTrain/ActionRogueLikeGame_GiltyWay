using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ChargeShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootTrans;
    private float chargeTime = 2f;
    
    private float bulletDmg = 1f;
    private float bulletSpeed = 10f;
    private int maxBulletCount = 5;
    private float fireRate = 0.1f;

    private float startTime;
    
    private void Update()
    {
        //차징 초기시간 초기화
        if (Input.GetKeyDown(KeyCode.E))
        {
            startTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            //차징 시간보다 오랫동안 누르고 있을 경우
            if (Time.time - startTime >= chargeTime)
            {
                //스킬 발사
                StartCoroutine(ChargeShoot());
            }
        }
    }
    
    
    
    // Bullet을 생성하는 코루틴
    IEnumerator ChargeShoot()
    {
        int bulletCount = 0;

        while (bulletCount < maxBulletCount)
        {
            var tempBullet = Instantiate(bullet, shootTrans.position, shootTrans.rotation);
            tempBullet.GetComponent<BulletController>().Init(bulletSpeed, bulletDmg);
            bulletCount++;

            // 0.1초 대기
            yield return new WaitForSeconds(fireRate);
        }
    }
}
