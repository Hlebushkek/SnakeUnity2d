using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int score;
    public void RestartScore()
    {
        score = 0;
        UpdateScoreText(0);
    }
    public void UpdateScoreText(int i)
    {
        score += i;
        this.GetComponent<TMPro.TextMeshProUGUI>().text = "Score : " + score;
    }
    public int GetScore()
    {
        return score;
    }
}
