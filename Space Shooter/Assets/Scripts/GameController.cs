using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GameControllerInstance = null;

    public static int score;
    public string scorePrefix = string.Empty;
    public Text scoreText = null;
    public Text gameOverText = null;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameControllerInstance = this;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = scorePrefix + score.ToString();
        }
    }

    public static void GameOver()
    {
        if (GameControllerInstance.gameOverText != null)
        {
            GameControllerInstance.gameOverText.gameObject.SetActive(true);
        }
    }
}
