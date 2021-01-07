using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    private void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 translation = new Vector3(horiz, 0, vert);
        translation *= speed * Time.deltaTime;
        transform.Translate(translation);
    }
}
