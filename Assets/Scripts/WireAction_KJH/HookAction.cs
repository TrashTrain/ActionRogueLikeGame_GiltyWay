using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAction : MonoBehaviour
{
    public WireAction wireAction;
    private DistanceJoint2D joint2D;

    private void Awake()
    {
        joint2D = GetComponent<DistanceJoint2D>();
        if (joint2D == null)
        {
            Debug.LogError("joint2D is null");
        }

        joint2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 7)
        {
            wireAction.isAttached = true;
            wireAction.isWireMax = true;
            joint2D.enabled = true;
            joint2D.distance = Vector2.Distance(wireAction.playerPos.position, wireAction.hook.position);
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
}
