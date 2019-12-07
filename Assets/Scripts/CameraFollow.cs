using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    void LateUpdate()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, dir, ref velocity, smoothTime);
    }
}
