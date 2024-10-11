using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
   [SerializeField] private List<GameObject> clothesPrefabs; // 의상 프리팹 리스트

    void Start()
    {

    }

    // 의상 인스턴스화 메서드
    public void InstantiateClothes(int index)
    {
        if (index >= 0 && index < clothesPrefabs.Count)
        {
            Instantiate(clothesPrefabs[index], transform.position, Quaternion.identity);
            Debug.Log("인스턴스화");
        }
        else
        {
            Debug.LogWarning("잘못된 인덱스입니다.");
        }
    }
}
