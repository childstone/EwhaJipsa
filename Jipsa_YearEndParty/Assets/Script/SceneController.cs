using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Image;
    public GameObject Bubble;
    public Light spotlight;
    public GameObject Button;

    void Start()
    {
        Image.SetActive(false);
        Bubble.SetActive(false);
        Button.SetActive(false);

        Invoke("ShowResult", 5f);  //scene4가 로드된 후 5초 뒤에 호출
    }

    void ShowResult()
    {
        Image.SetActive(true);
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

        yield return new WaitForSeconds(0.5f); //0.5초 대기
        Bubble.SetActive(true);

        yield return new WaitForSeconds(2.0f); //2초 대기
        Button.SetActive(true); //처음으로 버튼 활성화
    }
}
