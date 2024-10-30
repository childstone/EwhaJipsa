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
    public TMP_Text React1;
    public TMP_Text React2;
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

        Button.SetActive(false);

        Invoke("ShowResult", 5f);  //scene4�� �ε�� �� 5�� �ڿ� ȣ��
    }

    void ShowResult()
    {
        Image.SetActive(true);
        int num = 0;

        switch(num)
        {
            case 1:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 2:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 3:
                React1.text = "대사 1입니다.";
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

            case 8:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 9:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 10:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            case 11:
                React1.text = "대사 1입니다.";
                React2.text = "대사 2입니다.";
                break;

            default:
                React1.text = "초기 설정";
                React2.text = "초기 설정";
                break;


        }


        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float duration = 1.0f;
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
        Button.SetActive(true); //ó������ ��ư Ȱ��ȭ
    }
}
