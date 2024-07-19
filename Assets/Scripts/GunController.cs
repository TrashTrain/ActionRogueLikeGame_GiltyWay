using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunController : MonoBehaviour
{
    protected Transform muzzle;
    protected float angle;

    protected Vector2 mousePos;
    
    protected Vector2 target;
    private float shootingRate = 0f;
    public float maxRate = 0.4f;

    private SpriteRenderer sr;

    public float bulletSpeed = 0f;
    public float bulletDmg = 2f;
    private float sumDmg = PlayerController.atk;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (DialogSystem._isAction) return;
        if (!Pause.isPause) return;

        SumDmg();
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
        
        //마우스 입력 총알 발사
        if (Input.GetMouseButtonDown(0) && shootingRate > maxRate)
        {
            Fire();
            shootingRate = 0f;
        }
    }
    private void SumDmg()
    {
        if (sumDmg != PlayerController.atk && bulletDmg >= 2f) 
        {
            sumDmg = PlayerController.atk - sumDmg;
            bulletDmg += sumDmg;
            sumDmg = PlayerController.atk;
        }

    }
    public void Init(Transform pos)
    {
        muzzle = pos;
    }

    //추상화 내 밑 자식 개체들이 기능을 구현해라.
    protected abstract void Fire();
    protected abstract void OnRelease();
}
