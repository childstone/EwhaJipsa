using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreShow : MonoBehaviour
{
    public int FindNum(int [] clothesSet){
        int max=0;
        int answer=0;
        int [] count = new int[5];

        for(int i=0; i<clothesSet.Length; i++){
            count[clothesSet[i]]++;

            if(max<count[clothesSet[i]]){
                max=count[clothesSet[i]];
                answer=clothesSet[i];
            }
        }

        if(max==4){
            return answer;
        }
        else{
            return max+4;
        }


    }
    public TextMeshProUGUI scoreText;
    private int score = 0;
    
    void Awake()
    {
       
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.TIMPANI);
        yield return Delay();

        int[] clothesSet = GameManager.Instance.getCurrentClothesSet();
        int num = FindNum(clothesSet);
        switch (num) { 
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                yield return StartCoroutine(IncrementScore(100));
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.FANFARE);
                yield return Delay();
                break;

            case 5: //1���� ���� ���
                StartCoroutine(IncrementScore(20));
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.FANFARE);
                yield return Delay();
                break;

            case 6: //2�� ���� ���
                StartCoroutine(IncrementScore(50));
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.FANFARE);
                yield return Delay();
                break;

            case 7: //3�� ���� ���
                StartCoroutine(IncrementScore(80));
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.FANFARE);
                yield return Delay();
                break;
        }
        
        UpdateScoreText();        
    }

    IEnumerator IncrementScore(int targetScore)
    {
        for(int i=0; i<targetScore; i++)
        {
            score++;
            UpdateScoreText();
            yield return new WaitForSeconds(0.02f);
        }
        
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
    }


    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }



}
