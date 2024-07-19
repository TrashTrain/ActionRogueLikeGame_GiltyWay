using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private enum State { inactive, active, disabled }

    private State currentState;
    
    public float activeTime = 3f;
    public float inactiveTime = 3f;
    public float disabledTime = 3f;

    public float laserLength = 6f;
    
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        // 레이저의 시작점과 끝점을 설정
        lineRenderer.positionCount = 2;

        // 레이저의 너비를 설정
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        // 레이저의 Z축 위치를 고정
        lineRenderer.sortingOrder = 3;

        currentState = State.inactive;
        StartCoroutine(LaserInit());
    }

    void Update()
    {
        if (lineRenderer != null && currentState != State.disabled)
        {
            // 레이저의 시작점과 끝점을 설정
            Vector2 startPoint = transform.position;
            
            // 레이저의 위치를 업데이트
            lineRenderer.SetPosition(0, startPoint);

            RaycastHit2D hit = Physics2D.Raycast(startPoint, Vector2.down, laserLength, LayerMask.GetMask("Player"));
            
            if (currentState == State.active && hit.collider != null)
            {
                lineRenderer.SetPosition(1, hit.point);
                hit.collider.GetComponent<PlayerController>().GetDamaged(1f,gameObject, new Vector2(0f,0f));
            }
            else
            {
                lineRenderer.SetPosition(1, startPoint + Vector2.down * laserLength);
            }
        }
    }

    IEnumerator LaserInit()
    {
        while (true)
        {
            if (currentState == State.disabled)        // 레이저 X
            {
                lineRenderer.enabled = false;
                yield return new WaitForSeconds(disabledTime);
                currentState = State.inactive;
            }
            else if (currentState == State.inactive)    // 레이저 비활성화 (빨간색, 경고)
            {
                lineRenderer.material = lineRenderer.materials[0];  // 고치기
                
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
                
                lineRenderer.startColor = new Color(255f, 0f, 0f, 0.5f);
                lineRenderer.endColor = new Color(255f, 0f, 0f, 0.5f);
                lineRenderer.enabled = true;
                yield return new WaitForSeconds(inactiveTime);
                currentState = State.active;
            }
            else if (currentState == State.active)      // 레이저 활성화 (파란색)
            {
                lineRenderer.startWidth = 0.5f;
                lineRenderer.endWidth = 0.5f;

                lineRenderer.material = lineRenderer.materials[1];  // 고치기
                
                lineRenderer.startColor = Color.blue;
                lineRenderer.endColor = Color.blue;
                lineRenderer.enabled = true;
                yield return new WaitForSeconds(activeTime);

                currentState = State.disabled;
            }
        }
    }
    
    
}

