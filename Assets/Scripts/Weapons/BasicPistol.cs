using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPistol : GunController
{
    public GameObject bullet;
    public float bulletSpeed = 0f;

    //마우스 입력 총알 발사
    protected override void Fire()
    {
        //muzzleFlash.Play();
        //bullet 생성

        var tempBullet = Instantiate(bullet, transform.position, transform.rotation);
        if (target.x < 0) 
        {
            tempBullet.transform.Rotate(0f, 0f, -180f);
        }
        
        tempBullet.GetComponent<BulletController>().Init(bulletSpeed, dmg);
    }
    protected override void OnRelease()
    {

    }
}
