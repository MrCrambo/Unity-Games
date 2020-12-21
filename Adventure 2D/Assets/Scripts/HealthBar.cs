using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float healthDecreaseSpeed = 10f;
    public RectTransform thisTranfosrm = null;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        thisTranfosrm = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        float healthUpdate = 0f;
        if (PlayerController.playerInstance != null)
        {
            healthUpdate = Mathf.MoveTowards(thisTranfosrm.rect.width, PlayerController.Health, healthDecreaseSpeed);
        }

        thisTranfosrm.sizeDelta = new Vector2(Mathf.Clamp(healthUpdate, 0, 100), thisTranfosrm.sizeDelta.y);
    }
}
