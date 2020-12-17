using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float maxSpeed = 10f;

    void Update()
    {
        transform.position += transform.forward * maxSpeed * Time.deltaTime;    
    }
}
