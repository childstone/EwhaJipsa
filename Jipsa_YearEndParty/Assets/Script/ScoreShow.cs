using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    
    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncrementScore(100));
        UpdateScoreText();        
    }


    IEnumerator IncrementScore(int targetScore)
    {
        for(int i=0; i<targetScore; i++)
        {
            score++;
            UpdateScoreText();
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
