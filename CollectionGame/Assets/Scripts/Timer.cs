using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float maxTime = 60f;

    [SerializeField] private float countDown = 0;

    void Start()
    {
        countDown = maxTime;
    }

    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            Coin.coinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
