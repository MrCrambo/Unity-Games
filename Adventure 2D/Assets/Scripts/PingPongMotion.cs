using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMotion : MonoBehaviour
{
    public Vector3 moveAxes = Vector2.zero;
    public float distance = 3f;

    private Vector3 origPos = Vector3.zero;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        origPos = transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        transform.position = origPos + moveAxes * Mathf.PingPong(Time.time, distance);
    }
}
