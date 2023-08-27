using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreVal = 0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        addScore();
        score.text = scoreVal.ToString();
    }

    void addScore() {
        scoreVal += 1; //just for testing
        print(scoreVal);
    }
}
