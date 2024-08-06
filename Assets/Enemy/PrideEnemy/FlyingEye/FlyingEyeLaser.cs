using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FlyingEyeLaser : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public float laserLength = 6f;

    public Material defaultMaterial;
    public Material activeMaterial;

    public int dmg;

    public float directionX = 0f;
    public float directionY = -1f;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        

        // 레이저의 시작점과 끝점을 설정
        lineRenderer.positionCount = 2;

        // 레이저의 너비를 설정
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.material = defaultMaterial;
    
        // 시작할 때는 레이저 안 나오게
        lineRenderer.enabled = false;
        // 레이저의 Z축 위치를 고정
        lineRenderer.sortingOrder = 3;
    }

    void Update()
    {
        if (lineRenderer != null)
        {
            // 레이저의 시작점과 끝점을 설정
            Vector2 startPoint = transform.position;

            // 레이저의 위치를 업데이트
            lineRenderer.SetPosition(0, startPoint);

            Vector2 direction = new Vector2(directionX, directionY).normalized;

            RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, laserLength, LayerMask.GetMask("Player"));

            RaycastHit2D hitGround = Physics2D.Raycast(startPoint, direction, laserLength, LayerMask.GetMask("Ground"));

            // if (currentState == State.active) // 레이저가 active 상태
            // {
                lineRenderer.material = lineRenderer.materials[1];
                if (hit.collider != null) // 레이저에 플레이어가 부딪혔을 때
                {
                    lineRenderer.SetPosition(1, hit.point);
                    hit.collider.GetComponent<PlayerController>().GetDamaged(dmg, gameObject, new Vector2(0f, 0f));
                }
                else if (hitGround.collider != null) // 레이저가 바닥에 부딪혔을 때 
                {
                    lineRenderer.SetPosition(1, hitGround.point);
                }
                else
                {
                    lineRenderer.SetPosition(1, startPoint + direction * laserLength);
                    // lineRenderer.SetPosition(1, startPoint + Vector2.down * laserLength);
                }
        }
    }

    public void disabledState()
    {
        lineRenderer.enabled = false;
    }

    public void activeState()
    {
        lineRenderer.enabled = true;
    }

}

