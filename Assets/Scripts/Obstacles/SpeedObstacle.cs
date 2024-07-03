using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedObstacle : Obstacle
{
    public float speed;
    
    protected override void faceObstacle()
    {
        player.GetComponent<PlayerController>().speed -= speed;
    }
}
