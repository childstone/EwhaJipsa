using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Getdressed : MonoBehaviour
{

    public GameObject [] Hair;
    public GameObject [] Top;
    public GameObject [] Bottom;
    public GameObject [] Shoes;

    private int [] clothesSet;

    // default에게 옷을 입히는 스크립트
    void Start()
    {
        clothesSet = GameManager.Instance.getCurrentClothesSet();
        Dressed(clothesSet);
    }

    void Dressed(int [] clothesSet){
        int i = 0;
        
        Instantiate(Hair[clothesSet[i++]], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Top[clothesSet[i++]], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Bottom[clothesSet[i++]], new Vector3(0, 0, 0), Quaternion.identity);
        Instantiate(Shoes[clothesSet[i]], new Vector3(0, 0, 0), Quaternion.identity);
    }
}
