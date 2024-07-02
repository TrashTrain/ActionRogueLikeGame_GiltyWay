using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPistol : GunController
{
    public GameObject bullet;
    public float bulletSpeed = 0f;

    //���콺 �Է� �Ѿ� �߻�
    protected override void Fire()
    {
        //muzzleFlash.Play();
        //bullet ����

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
