using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    
    private enum State { inactive, active, disabled }

    private State currentState;
    
    private Animator chargeAnimator;
    
    public float activeTime = 3f;
    public float inactiveTime = 3f;
    public float disabledTime = 3f;

    public float laserLength = 6f;

    public Material defaultMaterial;
    public Material activeMaterial;
    
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        chargeAnimator = transform.parent.GetComponent<Animator>();
        
        // 레이저의 시작점과 끝점을 설정
        lineRenderer.positionCount = 2;

        // 레이저의 너비를 설정
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        
        lineRenderer.material = defaultMaterial;
        // lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        // lineRenderer.material = new Material(Shader.Find("Unlit/Texture"));
        // lineRenderer.textureMode = LineTextureMode.Tile;
        
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
            RaycastHit2D hitGround = Physics2D.Raycast(startPoint, Vector2.down, laserLength, LayerMask.GetMask("Ground"));
            
            if (currentState == State.active)      // 레이저가 active 상태
            {
                lineRenderer.material = lineRenderer.materials[1];
                if (hit.collider != null)       // 레이저에 플레이어가 부딪혔을 때
                {
                    lineRenderer.SetPosition(1, hit.point);
                    hit.collider.GetComponent<PlayerController>().GetDamaged(1f,gameObject, new Vector2(0f,0f));
                }
                else if (hitGround.collider != null)    // 레이저가 바닥에 부딪혔을 때 
                {
                    lineRenderer.SetPosition(1, hitGround.point);
                }
                else
                {
                    lineRenderer.SetPosition(1, startPoint + Vector2.down * laserLength);
                }
            }
            else
            {
                lineRenderer.material = lineRenderer.materials[0];
                
                if(hitGround.collider != null) lineRenderer.SetPosition(1, hitGround.point);
                // lineRenderer.SetPosition(1, startPoint + Vector2.down * laserLength);
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
                lineRenderer.material = defaultMaterial;
                
                chargeAnimator.SetBool("isCharge", false);
                
                yield return new WaitForSeconds(disabledTime);
                currentState = State.inactive;
            }
            else if (currentState == State.inactive)    // 레이저 비활성화 (빨간색, 경고)
            {
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
                
                lineRenderer.startColor = new Color(255f, 0f, 0f, 0.4f);
                lineRenderer.endColor = new Color(255f, 0f, 0f, 0.4f);

                lineRenderer.material = defaultMaterial;
                
                lineRenderer.enabled = true;
                
                chargeAnimator.SetBool("isCharge", true);
                
                yield return new WaitForSeconds(inactiveTime);
                currentState = State.active;
            }
            else if (currentState == State.active)      // 레이저 활성화 (파란색)
            {
                lineRenderer.startWidth = 0.5f;
                lineRenderer.endWidth = 0.5f;

                lineRenderer.material = lineRenderer.materials[1];  // 고치기

                lineRenderer.startColor = new Color(1f, 1f, 1f, 0.7f);
                lineRenderer.endColor = new Color(1f, 1f, 1f, 0.7f);

                lineRenderer.material = activeMaterial;
                lineRenderer.enabled = true;
                
                chargeAnimator.SetBool("isCharge", false);
                yield return new WaitForSeconds(activeTime);

                currentState = State.disabled;
            }
        }
    }
    
    
}

