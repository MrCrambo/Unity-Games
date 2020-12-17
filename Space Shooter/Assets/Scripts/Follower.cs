using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform objToFollow = null;
    public bool isFollowing = false;

    void Awake()
    {
        if (!isFollowing)
        {
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            objToFollow = player.transform;
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (objToFollow == null)
        {
            return;
        }

        Vector3 objDirection = objToFollow.position - transform.position;
        if (objDirection != Vector3.zero)
        {
            transform.localRotation = Quaternion.LookRotation(objDirection.normalized, Vector3.up);
        }
    }
}
