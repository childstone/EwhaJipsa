using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    [SerializeField] private int choiceClothesSet; // 의상 세트 번호

    public int GetChoiceClothesSet()
    {
        return choiceClothesSet;
    }

    void Start(){
        Debug.Log(choiceClothesSet);
    }
}
