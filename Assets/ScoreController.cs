using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int inc = 0;

    void Update()
    {
        inc += 1;
        scoreText.text = "Score: " + inc;
    }
    void UpdateScore(int amount)
    {
        scoreText.text = "Score: " + amount;
    }
}
