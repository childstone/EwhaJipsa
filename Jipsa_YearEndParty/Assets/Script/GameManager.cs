using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // 싱글턴 인스턴스

    [SerializeField] private int[] currentClothesSet=new int[4]; // 현재 선택된 의상 세트 번호

    public void setCurrentClothesSet(int count, int value){
        currentClothesSet[count] = value;
    }

    private void Awake()
    {
        // 중복된 GameManager가 생성되지 않도록 설정
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
}
