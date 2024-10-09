using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    [SerializeField] private int clothesSet; // 의상 세트 번호
    public GameObject prefabs; // 의상 프리팹
    private GameObject clothess; // 인스턴스화된 의상 오브젝트

    // 의상 세트 번호를 반환하는 메서드
    public int GetClothesSet()
    {
        return clothesSet;
    }

}