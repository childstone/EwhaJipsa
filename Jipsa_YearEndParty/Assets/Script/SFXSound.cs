using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SFXSound : MonoBehaviour
{

      // 버튼 클릭 시 호출될 메서드
    public void OnClick()
    {
        SoundManager.Instance.PlaySFX(SoundManager.ESFX.PUSH_BUTTON);
        Debug.Log("버튼 클릭 효과음 재생!");
    }
}