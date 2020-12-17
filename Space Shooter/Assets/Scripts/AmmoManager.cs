using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager AmmoManagerSingleton = null;
    public GameObject ammoPrefab = null;
    public int poolSize = 100;
    public Queue<Transform> ammoQueue = new Queue<Transform>();
    
    private GameObject[] ammoArray;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (AmmoManagerSingleton != null)
        {
            Destroy(GetComponent<AmmoManager>());
            return;
        }

        AmmoManagerSingleton = this;
        ammoArray = new GameObject[poolSize];

        for(int i = 0; i < poolSize; ++i)
        {
            ammoArray[i] = Instantiate(ammoPrefab, Vector3.zero, Quaternion.identity, transform) as GameObject;
            Transform objTransform = ammoArray[i].transform;
            ammoQueue.Enqueue(objTransform);
            ammoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector3 position, Quaternion rotation)
    {
        Transform spawnedAmmo = AmmoManagerSingleton.ammoQueue.Dequeue();

        spawnedAmmo.gameObject.SetActive(true);
        spawnedAmmo.position = position;
        spawnedAmmo.localRotation = rotation;

        AmmoManagerSingleton.ammoQueue.Enqueue(spawnedAmmo);
        return spawnedAmmo;
    }
}
