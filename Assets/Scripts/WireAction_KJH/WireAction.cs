using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAction : MonoBehaviour
{
    public HookAction hookAction;
    public Transform playerPos;
    public Transform hook;
    public LineRenderer wire;
    public Vector2 mouseDir;
    
    public float launchSpeed = 10f;
    public float wireMaxLength = 8f;
    public float shrinkSpeed = 5f;
    
    private bool isHookLaunched = false;
    public bool isWireMax = false;
    public bool isAttached = false;
    
    private void Start()
    {
        if (wire == null) 
        {
            Debug.LogError("LineRenderer가 할당되지 않았습니다.");
            return;
        }
        
        wire.positionCount = 2;
        wire.endWidth = wire.startWidth = 0.05f;
        wire.SetPosition(0, transform.position);
        wire.SetPosition(1, hook.position);
        wire.useWorldSpace = true;
        wire.enabled = false;
        
        ResetHook();
    }

    private void FixedUpdate()
    {
        if (playerPos == null)
        {
            Debug.LogError("playerPos is null");
            Destroy(this.gameObject);
        }
        
        transform.position = playerPos.position;
        
        if (isHookLaunched && !isAttached)
        {
            if (!isWireMax)
            {
                ExtendWire();
            }

            else
            {
                ShortenWire();
            }
        }
        else if (isAttached)
        {
            
        }
        
        wire.SetPosition(0, transform.position);
        wire.SetPosition(1, hook.position);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isAttached)
            {
                isAttached = false;
                hookAction.DisableJoint2D();
                return;
            }
            
            LaunchHook();
        }

        if (isAttached)
        {
            if (Input.GetKey(KeyCode.E))
            {
                hookAction.ShortenJoint2D(shrinkSpeed);
            }

            // if (Input.GetKeyUp(KeyCode.E))
            // {
            //     isAttached = false;
            //     hookAction.DisableJoint2D();
            // }
        }
    }

    public void LaunchHook()
    {
        if (isHookLaunched) return;
        
        hook.gameObject.SetActive(true);
        hook.position = transform.position;
        mouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        isHookLaunched = true;
        wire.enabled = true;
    }

    public void ExtendWire()
    {
        if (!isHookLaunched || isWireMax || isAttached) return;
        
        hook.Translate(launchSpeed * Time.deltaTime * mouseDir.normalized);

        if (Vector2.Distance(transform.position, hook.position) >= wireMaxLength)
        {
            isWireMax = true;
        }
    }

    public void ShortenWire()
    {
        if (!isHookLaunched || !isWireMax || isAttached) return;

        hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * launchSpeed);

        if (Vector2.Distance(transform.position, hook.position) < 0.1f)
        {
            ResetHook();
            wire.enabled = false;
        }
    }

    public void ResetHook()
    {
        isHookLaunched = false;
        isWireMax = false;
        hook.gameObject.SetActive(false);
    }
}
