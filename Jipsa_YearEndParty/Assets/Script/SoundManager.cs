using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // EBgm 열거형을 매개변수로 받아 해당하는 배경 음악 클립을 재생
    public void PlayBGM(EBGM bgmIdx)
    {
      	//enum int형으로 형변환 가능
        audioBgm.clip = bgms[(int)bgmIdx];
        audioBgm.Play();
    }

    // 현재 재생 중인 배경 음악 정지
    public void StopBGM()
    {
        audioBgm.Stop();
    }

    // ESfx 열거형을 매개변수로 받아 해당하는 효과음 클립을 재생
    public void PlaySFX(ESFX esfx)
    {
        audioSfx.PlayOneShot(sfxs[(int)esfx]);
    }
    
    void Start(){
        PlayBGM(EBGM.MainBGM);
    }

    void Update(){
            string currentSceneName = SceneManager.GetActiveScene().name;
            if(currentSceneName=="Scene4")
                StopBGM();

    }

}
