using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float damage = 100f;
    public float lifeTime = 2f;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", lifeTime);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Health h = other.gameObject.GetComponent<Health>();
        if (h == null)
        {
            return;
        }
        h.HealthPoints -= damage;
        Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
