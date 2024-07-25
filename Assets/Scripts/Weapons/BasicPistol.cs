using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPistol : GunController
{
    public GameObject bullet;
    

    //���콺 �Է� �Ѿ� �߻�
    protected override void Fire()
    {
        //muzzleFlash.Play();
        //bullet ����

        var tempBullet = Instantiate(bullet, transform.position, transform.rotation);

        tempBullet.GetComponent<BulletController>().Init(gunData.bulletSpeed, gunData.bulletDamage);
    }
}
