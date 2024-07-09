using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAction : MonoBehaviour
{
    public WireAction wireAction;
    private DistanceJoint2D joint2D;
    //private SpringJoint2D joint2D;
    
    
    public Transform enemyTrans;
    public bool isBindToEnemy = false;
    
    private void Awake()
    {
        joint2D = GetComponent<DistanceJoint2D>();
        //joint2D = GetComponent<SpringJoint2D>();
        
        if (joint2D == null)
        {
            Debug.LogError("joint2D is null");
        }

        joint2D.enabled = false;
    }

    private void FixedUpdate()
    {
        if (isBindToEnemy)
        {
            transform.position = enemyTrans.position;
            //Debug.Log("stuck!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            isBindToEnemy = false;
            wireAction.isAttached = true;
            wireAction.isWireMax = true;
            joint2D.enabled = true;
            joint2D.distance = Vector2.Distance(transform.position, wireAction.playerPos.position);
            //Debug.Log(joint2D.distance);
        }
        
        else if (other.gameObject.layer == 9)
        {
            isBindToEnemy = true;
            enemyTrans = other.transform;

            wireAction.isAttached = true;
            wireAction.isWireMax = true;
            joint2D.enabled = true;
            joint2D.distance = Vector2.Distance(  wireAction.playerPos.position, transform.position);
        }
    }

    public void DisableJoint2D()
    {
        joint2D.enabled = false;
    }

    public void ShortenJoint2D(float speed)
    {
        joint2D.distance -= speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        var playerRb = wireAction.playerPos.gameObject.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            playerRb.AddForce(Vector2.up * wireAction.lastJumpSpeed, ForceMode2D.Impulse);
        }
            
        transform.position = Vector2.zero;
        enemyTrans = null;
        isBindToEnemy = false;
    }
}
