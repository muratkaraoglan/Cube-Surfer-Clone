using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //transform.position = player.position + offset;
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
    }
}
