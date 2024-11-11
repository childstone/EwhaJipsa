using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public Image Black;
    public float fadeDuration = 1;

    // Start is called before the first frame update
    void Start()
    {
        Black.gameObject.SetActive(true);

        Color color = Black.color;
        color.a = 1;
        Black.color = color;

        StartCoroutine(Transparent());   
    }

    private IEnumerator Transparent()
    {
        Color color = Black.color;
        float startAlpha = color.a;
        float time = 0;

        while (time<fadeDuration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, 0, time / fadeDuration); // 알파 값을 보간
            Black.color = color;
            yield return null; // 다음 프레임까지 대기
        }

        color.a = 0;
        Black.color = color;
    }
}
