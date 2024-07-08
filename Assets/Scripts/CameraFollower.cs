using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform player;

    private void FixedUpdate()
    {
        if (player == null) return;

        Vector3 camPos = new Vector3(player.position.x + 3f, 0f, -10f);

        if (player.position.x + 3f < 0f)
        {
            transform.position = new Vector3(0, 0, -10f);
        }

        if (player.position.x > 295f || transform.position.x > 295f)
        {
            transform.position = new Vector3(295f, 0, -10f);
        }
        transform.position = Vector3.Slerp(transform.position, camPos, followSpeed * Time.deltaTime);
    }
}