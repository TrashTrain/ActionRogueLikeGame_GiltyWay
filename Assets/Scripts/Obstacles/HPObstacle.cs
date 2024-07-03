using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPObstacle : Obstacle
{
    public int dmg;
    
    protected override void faceObstacle()
    {
        player.GetComponent<PlayerController>().hp -= dmg;
    }
}
