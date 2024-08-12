using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMapLaser : MonoBehaviour
{
    private State currentState;
    
    public float range = 30f; // 레이저의 최대 탐지 거리

    private Transform player;

    private LineRenderer lineRenderer;

    public float laserLength = 20f;
    
    // public Material activeMaterial;

    public int dmg;

    private Vector2 direction;
    private Vector2 targetPosition;
    
    private bool isCouroutineRunning = false;

    public float laserSpeed = 2f;
    
    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        
        lineRenderer.positionCount = 2;
        
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        lineRenderer.material = lineRenderer.materials[0];
        
        lineRenderer.enabled = false;
    }

    // void Update()
    // {
    //     DetectPlayer();
    //     
    //     if (player!=null && !isCouroutineRunning)
    //     { 
    //         StartCoroutine(ShootLaser());
    //     }
    //     // else
    //     // {
    //     //     lineRenderer.enabled = false;
    //     // }
    // }
    
    void Update()
    {
        if (!isCouroutineRunning)
        {
            StartCoroutine(DetectAndShootLaser());
        }
    }

    // void DetectPlayer()
    // {
    //     Collider2D hit = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player"));
    //
    //     if (hit != null)
    //     {
    //         player = hit.transform;
    //         direction = (player.position - transform.position).normalized;
    //     }
    //     else
    //     {
    //         player = null;
    //         lineRenderer.enabled = false;
    //     }
    // }
    
    IEnumerator DetectAndShootLaser()
    {
        isCouroutineRunning = true;

        while (true)
        {
            // 플레이어의 현재 위치를 감지하고 그 방향을 설정
            DetectAndStorePlayerPosition();

            if (direction != Vector2.zero)
            {
                yield return StartCoroutine(ShootLaser());
            }
            else
            {
                // 플레이어가 탐지되지 않으면 레이저 비활성화
                lineRenderer.enabled = false;
                yield return new WaitForSeconds(1f); // 쿨다운
            }
        }
    }

    void DetectAndStorePlayerPosition()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player"));

        if (hit != null)
        {
            targetPosition = hit.transform.position;
            direction = (targetPosition - (Vector2)transform.position).normalized;
        }
        else
        {
            direction = Vector2.zero;
            lineRenderer.enabled = false;
        }
    }
    
    // IEnumerator ShootLaser()
    // {
    //     
    //     isCouroutineRunning = true;
    //     
    //     Vector2 startPoint = transform.position;
    //     Vector2 currentEndPoint = startPoint;
    //     
    //     lineRenderer.SetPosition(0, startPoint);
    //     lineRenderer.enabled = true;
    //     lineRenderer.material = activeMaterial;
    //     
    //     float currentLength = 0f;
    //     
    //     while (currentLength < laserLength)
    //     {
    //         currentLength += Time.deltaTime * (laserLength/3f);
    //         currentEndPoint = startPoint + direction * Mathf.Min(currentLength, laserLength);
    //
    //         lineRenderer.SetPosition(1, currentEndPoint);
    //
    //         RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, currentLength, LayerMask.GetMask("Player"));
    //         if (hit.collider != null)
    //         {
    //             currentEndPoint = hit.point;
    //             lineRenderer.SetPosition(1, currentEndPoint);
    //             
    //             hit.collider.GetComponent<PlayerController>().GetDamaged(dmg, gameObject, new Vector2(0f, 0f));
    //             
    //             break;
    //         }
    //
    //         yield return null;
    //     }
    //
    //     isCouroutineRunning = false;
    // }
    
    IEnumerator ShootLaser()
    {
        Vector2 startPoint = transform.position;
        Vector2 currentEndPoint = startPoint;

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.enabled = true;

        float currentLength = 0f;

        while (currentLength < laserLength)
        {
            currentLength += Time.deltaTime * (laserLength / laserSpeed); // 레이저가 뻗어지는 속도 조절
            currentEndPoint = startPoint + direction * Mathf.Min(currentLength, laserLength);

            lineRenderer.SetPosition(1, currentEndPoint);

            RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, currentLength, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                currentEndPoint = hit.point;
                lineRenderer.SetPosition(1, currentEndPoint);

                hit.collider.GetComponent<PlayerController>().GetDamaged(dmg, gameObject, Vector2.zero);

                break;
            }

            yield return null;
        }

        yield return new WaitForSeconds(0.3f); // 레이저가 최대 길이까지 도달한 후 잠시 대기

        lineRenderer.enabled = false; // 레이저 비활성화 후 다시 탐지 시작
    }
}
