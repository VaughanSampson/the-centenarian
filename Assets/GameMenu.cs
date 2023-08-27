using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        GameController.OnScoreChange += UpdateScore;
    }

    void UpdateScore(int amount)
    {
        scoreText.text = "Score: " + amount;
    }
}
