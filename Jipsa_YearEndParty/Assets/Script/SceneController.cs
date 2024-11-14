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
    

    void Start(){
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

        Black.gameObject.SetActive(true);

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
                React1.text = "이러고\n나갈 순\n없어...";
                Bubble1.SetActive(true);
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
                React1.gameObject.SetActive(true);

                Button.SetActive(true); // 버튼 활성화
                break;

            case 6:
                React1.text = "조금\n애매하네...";
                Bubble1.SetActive(true);
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
                React1.gameObject.SetActive(true);

                Button.SetActive(true); // 버튼 활성화
                break;

            case 7:
                React1.text = "조금 더\n신경쓰면\n괜찮을 것\n같아.";
                Bubble1.SetActive(true);
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
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
        Debug.Log("실행");
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

        Black.gameObject.SetActive(false);

    }

    private IEnumerator ShowDialogue0()
    {
        // 말풍선사운드
        React1.text = "뭐지...?\n이 옷을 입고\n나서부터...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        // 말풍선사운드
        React2.text = "계속\n무언가를\n찾고\n있다...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); // 대사 2 후 대기

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);

        yield return Delay();


        // 말풍선사운드
        React1.text = "잊어서는\n안 되는\n사람,";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        // 말풍선사운드
        React2.text = "잊고 싶지\n않은 사람.";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
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
        React3.text = "아가씨,\n당신의\n이름은?";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        React3.gameObject.SetActive(true);
        yield return Delay();

        Stamp0.SetActive(true); //도장 쾅 소리
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.REALSCORE);

        Button.SetActive(true); 
    }

    private IEnumerator ShowDialogue1()
    {
        //말풍선사운드
        React1.text = "뭐지...?\n이 옷을 입고\n나서부터...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);
        yield return Delay(); // 대사 1 후 대기

        //말풍선사운드
        React2.text = "계속\n무언가를\n찾고\n있다...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); // 대사 2 후 대기

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);

        yield return Delay();


        //말풍선사운드
        React1.text = "잊어서는\n안 되는 것,";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        // 말풍선사운드
        React2.text = "잊고 싶지\n않은 것.";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay();


        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);
        yield return Delay();

        //말풍선사운드
        Bubble3.SetActive(true);
        React3.text = "아 빗자루\n여기있다\nㅎ";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        React3.gameObject.SetActive(true);
        yield return Delay();

        //도장쾅 사운드
        Stamp1.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.REALSCORE);
        Button.SetActive(true); // 버튼 활성화
    }

    private IEnumerator ShowDialogue2()
    {
        ImageProfessor.SetActive(true);

        // 말풍선사운드
        React1.text = "자,\n수업 시작\n하겠습니다.";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        //말풍선사운드
        React2.text = "출석 코드는\n여기\n칠판에...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기
        yield return Delay(); // 대사 2 후 대기
        yield return Delay();

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble2.SetActive(false);
        React2.gameObject.SetActive(false);

        yield return Delay();


        // 말풍선사운드
        React1.text = "자네,\n수업 안 듣고\n어디\n가는가?";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기

        // 말풍선사운드
        React3.text = "...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); // 대사 1 후 대기

        Bubble1.SetActive(false);
        React1.gameObject.SetActive(false);
        Bubble3.SetActive(false);
        React3.gameObject.SetActive(false);
        yield return Delay();

        // 말풍선사운드
        Bubble2.SetActive(true);
        React2.text = "자네는\nF일세.";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        React2.gameObject.SetActive(true);
        yield return Delay();

        //도장 쾅 사운드
        Stamp2.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.REALSCORE);
        Button.SetActive(true); // 버튼 활성화
    }

    private IEnumerator ShowDialogue3()
    {
        Image1.SetActive(true);
        Image2.SetActive(true);

        //말풍선사운드
        React3.text = "연말파티에\n가려면\n돈이\n필요한데...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);
        yield return Delay(); // 대사 1 후 대기
        yield return Delay(); // 대사 1 후 대기

        Bubble3.SetActive(false);
        yield return Delay(); // 대사 1 후 대기

       // 말풍선사운드
        React3.text = "한 푼만\n줍쇼~...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);
        yield return Delay(); // 대사 1 후 대기

        // 말풍선사운드
        React1.text = "아이고...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        //말풍선사운드
        React2.text = "옛다.";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); // 대사 2 후 대기

        //도장 쾅 소리
        Stamp3.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.REALSCORE);
        Button.SetActive(true); // 버튼 활성화
    }

    private IEnumerator ShowDialogue4()
    {
        Image1.SetActive(true);
        Image2.SetActive(true);

        //말풍선사운드
        React1.text = "오오...\n전하...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);

        yield return Delay(); // 대사 1 후 대기
        yield return Delay(); // 대사 1 후 대기

        Bubble1.SetActive(false);
        yield return Delay(); // 대사 1 후 대기

        //말풍선 사운드
        React1.text = "연말 파티로\n향하시어";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble1.SetActive(true);
        React1.gameObject.SetActive(true);
        yield return Delay(); // 대사 1 후 대기

        //말풍선 사운드
        React2.text = "세상에\n이화의\n이름을\n드높여주시옵소서...";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble2.SetActive(true);
        React2.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기
        yield return Delay(); // 대사 2 후 대기

        //말풍선 사운드
        React3.text = "암\n그러도록\n하지.";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        Bubble3.SetActive(true);
        React3.gameObject.SetActive(true);

        yield return Delay(); // 대사 2 후 대기

        //말풍선 사운드
        React1.text = "만세~";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        React2.text = "만세~.";
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.BUBBLE);
        yield return Delay(); // 대사 2 후 대기

        Stamp4.SetActive(true);
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.REALSCORE);
        Button.SetActive(true); // 버튼 활성화
    }



    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f); //1.5초 기다리기
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
