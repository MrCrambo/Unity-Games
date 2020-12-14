using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject deathParticlesPrefab = null;
    public bool shoudDestrouOnDeath = true;
    [SerializeField] private float _HealthPoints = 100f;

    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            _HealthPoints = value;

            if (_HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if (deathParticlesPrefab != null)
                {
                    Instantiate(deathParticlesPrefab, transform.position, transform.rotation);
                }
                if (shoudDestrouOnDeath)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
