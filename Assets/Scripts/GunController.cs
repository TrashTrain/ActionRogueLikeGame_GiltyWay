using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunController : MonoBehaviour
{
    public float dmg;

    protected Transform muzzle;

    protected float angle;

    protected Vector2 mousePos;
    
    protected Vector2 target;
    private float shootingRate = 0f;
    public float maxRate = 0.4f;

    private void Start()
    {
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = mousePos - (Vector2)transform.position;
        shootingRate += Time.deltaTime;

        transform.right = (Vector3)target.normalized;
        if (target.x < 0)
        {
            transform.Rotate(0f, 0f, 180f);
        }
        else
        {
            transform.Rotate(0f, 0f, 0f);
        }
        
        //마우스 입력 총알 발사
        if (Input.GetMouseButtonDown(0) && shootingRate > maxRate)
        {
            Fire();
            shootingRate = 0f;
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
