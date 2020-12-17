using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageRate = 10f;

    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        Health h = other.gameObject.GetComponent<Health>();
        if (h == null)
        {
            return;
        }
        h.HealthPoints -= damageRate * Time.deltaTime;
    }
}
