using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 2, -10);
    public float SmoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
    }
}
