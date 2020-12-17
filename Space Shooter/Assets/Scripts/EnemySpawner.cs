using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxRadius = 1f;
    public float interval = 3f;
    public GameObject objToSpawn = null;
    private Transform origin = null;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        origin = GameObject.FindGameObjectWithTag("Player").transform;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InvokeRepeating("Spawn", 0f, interval);
    }

    void Spawn()
    {
        if (origin == null)
        {
            return;
        }

        Vector3 spawnPos = origin.position + Random.onUnitSphere * maxRadius;
        spawnPos = new Vector3(spawnPos.x, 0f, spawnPos.z);
        Instantiate(objToSpawn, spawnPos, Quaternion.identity);
    }
}
