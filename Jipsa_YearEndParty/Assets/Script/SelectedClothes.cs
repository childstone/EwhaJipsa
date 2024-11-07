using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedClothes : MonoBehaviour{
    private SpriteRenderer spriteRenderer;
    public Sprite [] sprites;
    public int order;


    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        int [] selectedClothes =GameManager.Instance.getCurrentClothesSet();
        int select=selectedClothes[order];
         // value 값이 배열 범위 내인지 확인
        if (select >= 0 && select < sprites.Length)
        {
            // 2D 스프라이트일 경우
            if (spriteRenderer != null)
            {
                
                spriteRenderer.sprite = sprites[select];
            }
        }
    }   

}