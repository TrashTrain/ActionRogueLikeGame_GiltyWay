using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPistol : GunController
{
    public GameObject bullet;
    
    protected override void Fire()
    {
        //muzzleFlash.Play();
        //bullet ����
        
        if (Input.GetMouseButtonDown(0) && shootingRate > gunData.maxRate)
        {

            StartCoroutine(ShowCreateBullet());

        }
    }

    private IEnumerator ShowCreateBullet()
    {
        CreateBullet();
        for (int i = 0; i < PassiveSkillData.instance.AutomaticBulletCnt; i++)
        {
            yield return new WaitForSeconds(0.05f);
            CreateBullet();
        }

    }

    private void CreateBullet()
    {
        var tempBullet = Instantiate(bullet, transform.position, transform.rotation);
        tempBullet.GetComponent<BulletController>().Init(gunData.bulletSpeed, gunData.bulletDamage);

        shootingRate = 0f;

        //for .NET Gabage Collector
        tempBullet = null;
    }
}
