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
        if (Input.GetMouseButtonDown(0) && shootingRate > maxRate)
        {
            Fire();
            shootingRate = 0f;
        }
    }


    //�߻�ȭ �� �� �ڽ� ��ü���� ����� �����ض�.
    protected abstract void Fire();
}
