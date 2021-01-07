using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float lookSpeed = 3.0f;
    public Transform body = null;
    public Camera lookCamera = null;

    private Vector2 rotation = Vector2.zero;

    private void Update()
    {
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x -= Input.GetAxis("Mouse Y");
        Vector2 rotateStep = rotation * lookSpeed;
        body.eulerAngles = new Vector2(0, rotateStep.y);
        lookCamera.transform.localRotation = Quaternion.Euler(rotateStep.x, 0, 0);
    }
}
