using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//To enable the score functionality
public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    TMP_Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        textScore.text = score.ToString();
    }

    public void ScoreHit(int scoreIncrease) 
    {
        score = score + scoreIncrease;
        textScore.text = score.ToString();
    }
}
