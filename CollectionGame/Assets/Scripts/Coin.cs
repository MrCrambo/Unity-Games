using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    public static int coinCount = 0;

    void Start()
    {
        ++coinCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
            Destroy(gameObject);
    }

    void OnDestroy()
    {
        --coinCount;

        if (coinCount <= 0)
        {
            GameObject timer = GameObject.Find("LevelTimer");
            Destroy(timer);

            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach(GameObject obj in fireworks)
            {
                obj.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
