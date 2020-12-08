using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool mouseLook = true;
    public string horAxis = "Horizontal";
    public string verAxis = "Vertical";
    public string fireAxis = "Fire1";

    public float maxSpeed = 5f;

    public Rigidbody thisObject = null;
    
    void Awake()
    {
        thisObject = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horz = Input.GetAxis(horAxis);
        float vert = Input.GetAxis(verAxis);
        Vector3 moveDirection = new Vector3(horz, 0.0f, vert);

        thisObject.AddForce(moveDirection.normalized * maxSpeed);
        thisObject.velocity = new Vector3(Mathf.Clamp(thisObject.velocity.x, -maxSpeed, maxSpeed),
                                          Mathf.Clamp(thisObject.velocity.y, -maxSpeed, maxSpeed),
                                          Mathf.Clamp(thisObject.velocity.z, -maxSpeed, maxSpeed));
        
        if (mouseLook)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            mousePos = new Vector3(mousePos.x, 0.0f, mousePos.z);

            Vector3 lookDirection = mousePos - transform.position;

            transform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
        }
    }
}
