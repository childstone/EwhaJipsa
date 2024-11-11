using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{public static SoundManager Instance { get; private set; } // 싱글턴 인스턴스

    private void Awake()
    {
        // 중복된 SoundManager 생성되지 않도록 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum EBGM{
        MainBGM
    }

    public enum ESFX{
        LEVER,
        PUSH_BUTTON,
        TIMPANI,
        FANFARE,
        REALSCORE,
        BUBBLE
    }

    
    //audio clip 담을 수 있는 배열
    [SerializeField] AudioClip[] bgms;
    [SerializeField] AudioClip[] sfxs;

    //플레이하는 AudioSource
    [SerializeField] AudioSource audioBgm;
    [SerializeField] AudioSource audioSfx;


}
