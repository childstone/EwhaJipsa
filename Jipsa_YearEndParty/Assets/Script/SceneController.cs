using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Image;

    public GameObject Image1;
    public GameObject Image2;
    public GameObject Bubble1;
    public GameObject Bubble2;
    public GameObject Bubble3;
    public TMP_Text React1;
    public TMP_Text React2;
    public TMP_Text React3;
    public Light spotlight;
    public GameObject Button;

    void Start()
    {
        Image.SetActive(false);
        Image1.SetActive(false);
        Image2.SetActive(false);
        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);
        Bubble3.SetActive(false);
        React3.gameObject.SetActive(false);

        Button.SetActive(false);

        Invoke("ShowResultWrapper", 5f);  //scene4�� �ε�� �� 5�� �ڿ� ȣ��
    }
    
    void ShowResultWrapper()
    {
         //ClothesSet load from GameManager
        int [] clothesSet = GameManager.Instance.getCurrentClothesSet();
        ShowResult(clothesSet);
    }

    void ShowResult(int [] clothesSet)
    {
        Image.SetActive(true);
        int num = FindNum(clothesSet);;

        switch(num)
        {
            case 0:
                StartCoroutine(ShowDialogue4());
                break;
            case 1:
                React1.text = "머슴 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 2:
                React1.text = "대학 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 3:
                React1.text = "거지 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 4:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 5:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 6:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 7:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            default:
                React1.text = "초기 설정";
                React2.text = "초기 설정";
                break;


        }


    }

    private IEnumerator ShowDialogue1()
    {
        // 대사 1
        React1.text = "뭐지...?\n이 옷을 입고 나서부터...";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        // 대사 2
        React2.text = "계속 무언가를 찾고 있다...";
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        Button.SetActive(true); // 버튼 활성화
    }

    private IEnumerator ShowDialogue4()
    {
        Image1.SetActive(true);
        Image2.SetActive(true);

        yield return Delay(); 
        // 대사 1
        React1.text = "오오... 전하...";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        Bubble1.SetActive(false);
        yield return Delay(); // 대사 1 후 대기

        React1.text = "연말 파티로 향하시어";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);
        yield return Delay(); // 대사 1 후 대기


        // 대사 2

        React2.text = "세상에 이화의 이름을 드높여주시옵소서...";
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        React3.text = "암 그러도록 하지.";
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        React1.text = "만세~";
        React2.text = "만세~.";


        Button.SetActive(true); // 버튼 활성화
    }



    private IEnumerator Delay()
    {
        /*float duration = 1.0f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            Color newColor = Color.Lerp(Color.black, Color.white, t);
            Image.GetComponent<Image>().color = newColor;

            spotlight.intensity = Mathf.Lerp(0, 1.5f, t);

            yield return null;
        }

        yield return new WaitForSeconds(0.5f); //0.5�� ���
        Image1.SetActive(true);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return new WaitForSeconds(1); //0.5�� ���
        Image2.SetActive(true);
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.0f); //2�� ���
        Button.SetActive(true); //ó������ ��ư Ȱ��ȭ*/

        yield return new WaitForSeconds(2f); //2초 기다리기
    }


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


}
