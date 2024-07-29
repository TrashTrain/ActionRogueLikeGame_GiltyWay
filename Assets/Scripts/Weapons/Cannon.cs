using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : GunController
{
    public GameObject bullet;
    
    
    protected override void Fire()
    {
        
        if (Input.GetMouseButtonDown(0) && shootingRate > gunData.maxRate)
        {
            var tempBullet = Instantiate(bullet, transform.position, transform.rotation);
            tempBullet.GetComponent<BulletController>().Init(gunData.bulletSpeed, gunData.bulletDamage);
            tempBullet.transform.localScale = PassiveSkillData.instance.BulletSize * Vector3.one;
            
            shootingRate = 0f;
            
            //for .NET Gabage Collector
            tempBullet = null;
        }
    }
}
