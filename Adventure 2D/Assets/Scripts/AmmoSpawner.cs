using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPrefab = null;
    public Vector2 timeRange = Vector2.zero;
    public float ammoLifeTime = 2f;
    public float ammoSpeed = 5f;
    public float ammoDamage = 100f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Fire();
    }

    private void Fire()
    {
        GameObject obj = Instantiate(ammoPrefab, transform.position, transform.rotation) as GameObject;
        Ammo ammoComponent = obj.GetComponent<Ammo>();
        Mover mover = obj.GetComponent<Mover>();
        ammoComponent.lifeTime = ammoLifeTime;
        ammoComponent.damage = ammoDamage;
        mover.speed = ammoSpeed;

        Invoke("Fire", Random.Range(timeRange.x, timeRange.y));
    }
}
