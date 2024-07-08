using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPistol : GunController
{
    public GameObject bullet;
    public float bulletSpeed = 0f;
    public float bulletDmg = 2f;
    

    //���콺 �Է� �Ѿ� �߻�
    protected override void Fire()
    {
        //muzzleFlash.Play();
        //bullet ����

        var tempBullet = Instantiate(bullet, transform.position, transform.rotation);

        tempBullet.GetComponent<BulletController>().Init(bulletSpeed, bulletDmg);
    }
    protected override void OnRelease()
    {

    }
}
