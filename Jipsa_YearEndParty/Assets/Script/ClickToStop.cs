using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStop : MonoBehaviour
{
    public Pointer pointer;
    public GameObject Lever;
    public GameObject Lever_Hover;
    public bool Click_flag=true;

    void Start()
    {
        // 시작 시 targetObject를 비활성화할 수 있음
        if (Lever_Hover != null)
        {
            Lever_Hover.SetActive(false);
        }
    }

    private void Update()
    {
        if(Click_flag){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.LEVER);
                pointer.SaveClothesSet();
            }

            if (Input.GetMouseButtonDown(0))
            {
                SoundManager.Instance.PlaySFX(SoundManager.ESFX.LEVER);
                DetectObjectUnderMouse();
            }
        }
    }

    private void DetectObjectUnderMouse()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null && hit.collider.CompareTag("Lever"))
        {
            pointer.SaveClothesSet();
        }
    }

    // 마우스가 오브젝트 위로 올라왔을 때
    private void OnMouseEnter()
    {
        if (Lever_Hover != null && Lever != null)
        {
            Lever_Hover.SetActive(true); // 오브젝트 활성화
            Lever.SetActive(false); //오브젝트 비활성화
        }
    }

    // 마우스가 오브젝트에서 나갔을 때
    private void OnMouseExit()
    {
        if (Lever_Hover != null && Lever != null)
        {
            Lever_Hover.SetActive(false); // 오브젝트 활성화
            Lever.SetActive(true); //오브젝트 비활성화
        }
    }
}


