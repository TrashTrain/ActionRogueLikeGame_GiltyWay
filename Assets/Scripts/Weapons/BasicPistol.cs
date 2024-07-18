using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPistol : GunController
{
    public GameObject bullet;

    

    //마우스 입력 총알 발사
    protected override void Fire()
    {
        //muzzleFlash.Play();
        //bullet 생성

        var tempBullet = Instantiate(bullet, transform.position, transform.rotation);

        tempBullet.GetComponent<BulletController>().Init(bulletSpeed, bulletDmg);
    }
    protected override void OnRelease()
    {

    }
}
