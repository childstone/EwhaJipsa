using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    [SerializeField] private int clothesSet; // 의상 세트 번호
    // 의상 세트 번호를 반환하는 메서드
    public int GetClothesSet()
    {
        return clothesSet;
    }

}