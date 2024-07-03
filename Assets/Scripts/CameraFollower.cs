using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform player;

    private void FixedUpdate()
    {
        Vector3 camPos = new Vector3(player.position.x + 3f, 0f, -10f);

        if (player.position.x + 3f < 0f)
        {
            transform.position = new Vector3(0, 0, -10f);
        }
        transform.position = Vector3.Slerp(transform.position, camPos, followSpeed * Time.deltaTime);
    }
}