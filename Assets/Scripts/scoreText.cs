using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText: MonoBehaviour
{
    private Text score;
    private int finalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "Score: " + finalScore;
    }

    // Update is called once per frame
    public void updateScore(int points)
    {
        finalScore = finalScore + points;
        score.text = "Score: " + finalScore;
    }
}
