using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMapLaser : MonoBehaviour
{
    private enum State { active, disabled }
    private State currentState;
    
    public float range = 30f; // 레이저의 최대 탐지 거리
    // public LayerMask playerLayer; // "Player" 레이어를 지정

    private Transform player;

    private LineRenderer lineRenderer;

    public float laserLength = 20f;
    
    public Material activeMaterial;

    public int dmg;

    private Vector2 direction;
    
    private void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        
        lineRenderer.positionCount = 2;
        
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;

        lineRenderer.material = activeMaterial;
        
        // lineRenderer.SetPosition(0,transform.position);
        // lineRenderer.SetPosition(1, transform.position);
        lineRenderer.enabled = false;
    }

    void Update()
    {
        DetectPlayer();
        // Vector2 startPoint = transform.position;
        
        if (player!=null && !isCouroutineRunning)
        { 
            StartCoroutine(ShootLaser());
        }
        // else
        // {
        //     lineRenderer.enabled = false;
        // }
    }

    // void DetectPlayer()
    // {
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, range, playerLayer);
    //
    //     if (hit.collider != null)
    //     {
    //         player = hit.collider.transform;
    //         direction = (player.position - transform.position).normalized;
    //         // lineRenderer.enabled = true;
    //     }
    //     else
    //     {
    //         lineRenderer.enabled = false;
    //         direction = transform.position;
    //     }
    // }

    void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player"));

        if (hit != null)
        {
            player = hit.transform;
            direction = (player.position - transform.position).normalized;
        }
        else
        {
            player = null;
            lineRenderer.enabled = false;
        }
    }
    private bool isCouroutineRunning = false;
    
    IEnumerator ShootLaser()
    {
        isCouroutineRunning = true;
        
        Vector2 startPoint = transform.position;
        Vector2 currentEndPoint = startPoint;
        
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.enabled = true;
        lineRenderer.material = activeMaterial;
        
        float currentLength = 0f;
        
        while (currentLength < laserLength)
        {
            currentLength += Time.deltaTime * (laserLength/3f);
            currentEndPoint = startPoint + direction * Mathf.Min(currentLength, laserLength);

            lineRenderer.SetPosition(1, currentEndPoint);

            RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, currentLength, LayerMask.GetMask("Player"));
            if (hit.collider != null)
            {
                currentEndPoint = hit.point;
                lineRenderer.SetPosition(1, currentEndPoint);
                
                hit.collider.GetComponent<PlayerController>().GetDamaged(dmg, gameObject, new Vector2(0f, 0f));
                
                break;
            }

            yield return null;
        }

        isCouroutineRunning = false;
    }
}