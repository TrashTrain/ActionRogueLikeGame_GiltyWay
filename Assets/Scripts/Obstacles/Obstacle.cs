using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public GameObject player;
    protected abstract void faceObstacle();
    
    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            faceObstacle();
        }
    }
}
