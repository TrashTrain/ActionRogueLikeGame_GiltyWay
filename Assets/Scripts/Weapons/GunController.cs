using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunController : MonoBehaviour
{
    #region GunData
    
    protected GunDataStruct gunData;
    public GunDataStruct GunData => gunData;
    [Header("Ref")] 
    [SerializeField] protected GunData refData;
    
    #endregion
    
    protected Transform muzzle;
    protected float angle;

    protected Vector2 mousePos;
    
    protected Vector2 target;
    private SpriteRenderer sr;
    
    private float shootingRate = 0f;
    
    //public float maxRate = 0.4f;
    //public float bulletSpeed = 0f;
    //public float bulletDmg = 2f;


    private void Awake()
    {
        if (refData == null)
        {
            Debug.LogError($"{this.gameObject} : refData is null");
        }
        else
        {
            refData.SyncData();
            gunData = refData.data;
        }
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!PlayerController.IsControllable) return;
        //if (!Pause.isPause) return;
        if(Time.timeScale == 0) return;

        //Debug.Log("test");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = mousePos - (Vector2)transform.position;
        shootingRate += Time.deltaTime;

        transform.right = (Vector2)target.normalized;
        if (target.x < 0)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY= false;
        }
        
        //���콺 �Է� �Ѿ� �߻�
        if (Input.GetMouseButtonDown(0) && shootingRate > gunData.maxRate)
        {
            Fire();
            shootingRate = 0f;
        }
    }


    //�߻�ȭ �� �� �ڽ� ��ü���� ����� �����ض�.
    protected abstract void Fire();
    
    
    
    //For Changing GunData Temporary 
    public void SetBulletDamage(float damage)
    {
        gunData.bulletDamage = damage;
    }
    
    public void SetBulletSpeed(float speed)
    {
        gunData.bulletSpeed = speed;
    }
    
    public void SetBulletMaxRate(float maxRate)
    {
        gunData.maxRate = maxRate;
    }
    
    public void SetBulletReloadTime(float reloadTime)
    {
        gunData.reloadTime = reloadTime;
    }
    
    public void SetMaxAmmo(int maxAmmo)
    {
        gunData.maxAmmo = maxAmmo;
    }
}
