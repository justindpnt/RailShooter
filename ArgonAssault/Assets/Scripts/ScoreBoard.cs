using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//To enable the score functionality
public class ScoreBoard : MonoBehaviour
{
    //Same score no matter the enemy
    [SerializeField] int scorePerHit = 12;

    int score = 0;
    TMP_Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        textScore.text = score.ToString();
    }

    public void ScoreHit() 
    {
        score = score + scorePerHit;
        textScore.text = score.ToString();
    }
}
