using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Image Black;
    public GameObject Image1; //스탠딩1
    public GameObject Image2; //스탠딩2

    public GameObject ImageProfessor;

    public GameObject Bubble1; //말풍선1
    public GameObject Bubble2; //말풍선2
    public GameObject Bubble3; //말풍선3
    public TMP_Text React1; 
    public TMP_Text React2;
    public TMP_Text React3;
    public Light spotlight;
    public GameObject Button;

    public GameObject Stamp0;
    public GameObject Stamp1;
    public GameObject Stamp2;
    public GameObject Stamp3;
    public GameObject Stamp4;

    public float fadeDuration = 2.0f;

    void Start()
    {
        Black.gameObject.SetActive(true);

        Image1.SetActive(false);
        Image2.SetActive(false);
        ImageProfessor.SetActive(false);
        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);
        Bubble3.SetActive(false);
        React3.gameObject.SetActive(false);

        Stamp0.SetActive(false);
        Stamp1.SetActive(false);
        Stamp2.SetActive(false);
        Stamp3.SetActive(false);
        Stamp4.SetActive(false);

        Button.SetActive(false);

        Color color = Black.color;
        color.a = 1; // 불투명으로 초기화
        Black.color = color;

        StartCoroutine(FadeOut());
        Invoke("ShowResultWrapper", 7f);  //scene4�� �ε�� �� 5�� �ڿ� ȣ��
    }
    
    void ShowResultWrapper()
    {
         //ClothesSet load from GameManager
        int [] clothesSet = GameManager.Instance.getCurrentClothesSet();
        ShowResult(clothesSet);
    }

    void ShowResult(int [] clothesSet)
    {
        int num = FindNum(clothesSet);;

        switch(num)
        {
            case 0:
                StartCoroutine(ShowDialogue0());
                break;
            case 1:
                StartCoroutine(ShowDialogue1());
                break;

            case 2:
                StartCoroutine(ShowDialogue2());
                break;

            case 3:
                StartCoroutine(ShowDialogue3());
                break;

            case 4:
                StartCoroutine(ShowDialogue4());
                break;

            case 5:
                React1.text = "이러고 나갈 순 없어...";
                Bubble1.SetActive(true);
                React1.gameObject.SetActive(true);
                Button.SetActive(true); // 버튼 활성화
                break;

            case 6:
                React1.text = "조금 애매하네...";
                Bubble1.SetActive(true);
                React1.gameObject.SetActive(true);
                Button.SetActive(true); // 버튼 활성화
                break;

            case 7:
                React1.text = "조금 더 신경쓰면 괜찮을 것 같아.";
                Bubble1.SetActive(true);
                React1.gameObject.SetActive(true);
                Button.SetActive(true); // 버튼 활성화
                break;

            default:
                React1.text = "공습경보!!공습경보!!";
                React2.text = "버그발생!!버그발생!!!";
                React1.gameObject.SetActive(true);
                React2.gameObject.SetActive(true);
                break;


        }
    }

    private IEnumerator FadeOut()
    {
        Color color = Black.color;
        float startAlpha = color.a; // 시작 알파 값
        float time = 0; // 경과 시간

        yield return Delay();
        // 페이드 아웃 효과
        while (time < fadeDuration)
        {
            time += Time.deltaTime; // 경과 시간 증가
            color.a = Mathf.Lerp(startAlpha, 0, time / fadeDuration); // 알파 값을 보간
            Black.color = color;
            yield return null; // 다음 프레임까지 대기
        }

        color.a = 0; // 최종 알파 값을 0으로 설정
        Black.color = color; // 색상 업데이트

    }

    private IEnumerator ShowDialogue0()
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
        yield return Delay(); // 대사 2 후 대기

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);

        yield return Delay();


        // 대사 1
        React1.text = "잊어서는 안 되는 사람,";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        // 대사 2
        React2.text = "잊고 싶지 않은 사람.";
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); 

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);
        yield return Delay();

        Bubble3.SetActive(true);
        React3.text = "아가씨, 당신의 이름은?";
        React3.gameObject.SetActive(true);
        yield return Delay();

        Stamp0.SetActive(true);

        Button.SetActive(true); // 버튼 활성화
    }

    private IEnumerator ShowDialogue1()
    {
        yield return Delay();
        // 대사 1
        React1.text = "뭐지...?\n이 옷을 입고 나서부터...";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        React2.text = "계속 무언가를 찾고 있다...";
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); // 대사 2 후 대기

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);

        yield return Delay();


        // 대사 1
        React1.text = "잊어서는 안 되는 것,";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        // 대사 2
        React2.text = "잊고 싶지 않은 것.";
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay();

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);
        yield return Delay();

        Bubble3.SetActive(true);
        React3.text = "아 빗자루 여기있다 ㅎ";
        React3.gameObject.SetActive(true);
        yield return Delay();

        Stamp1.SetActive(true);
        Button.SetActive(true); // 버튼 활성화
    }

    private IEnumerator ShowDialogue2()
    {
        ImageProfessor.SetActive(true);

        yield return Delay();
        // 대사 1
        React1.text = "자, 수업 시작하겠습니다.";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        React2.text = "출석 코드는 여기 칠판에...";
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);

        yield return Delay();


        // 대사 1
        React1.text = "자네, 수업 안 듣고 어디 가는가?";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        //학생 대사3
        React3.text = "...";
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble3.SetActive(false);
        React3.gameObject.SetActive(false);
        yield return Delay();

        Bubble2.SetActive(true);
        React2.text = "자네는 F일세.";
        React2.gameObject.SetActive(true);
        yield return Delay();

        Stamp2.SetActive(true);
        Button.SetActive(true); // 버튼 활성화
    }

    private IEnumerator ShowDialogue3()
    {
        Image1.SetActive(true);
        Image2.SetActive(true);

        yield return Delay();
        // 대사 1
        React3.text = "연말파티에 가려면 돈이 필요한데...";
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);
        yield return Delay(); // 대사 1 후 대기

        Bubble3.SetActive(false);
        yield return Delay(); // 대사 1 후 대기

        React3.text = "한 푼만 줍쇼~...";
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);
        yield return Delay(); // 대사 1 후 대기


        // 대사 2

        React1.text = "아이고...";
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        React2.text = "옛다.";
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); // 대사 2 후 대기

        Stamp3.SetActive(true);
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

        Stamp4.SetActive(true);
        Button.SetActive(true); // 버튼 활성화
    }



    private IEnumerator Delay()
    {
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
