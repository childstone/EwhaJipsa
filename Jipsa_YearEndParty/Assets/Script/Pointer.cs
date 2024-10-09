using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float speed; // 이동 속도
    private bool isMoving = true; // 이동 여부
    private int direction = 1; // 이동 방향 (1: 오른쪽, -1: 왼쪽)
    private Collider2D objectCollider;
    public int valueOfClothesSet;

// Trigger 충돌 감지 함수
    void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트의 태그가 "Top"인지 확인
        if (other.gameObject.tag == "Top")
        {
            Debug.Log("Top 태그를 가진 오브젝트와 Trigger 충돌했습니다.");
            // 여기에 충돌 시 실행할 코드를 작성하세요.
            Clothes otherScript = other.gameObject.GetComponent<Clothes>();

            // 컴포넌트가 존재하는지 확인
            if (otherScript != null)
            {
                // 변수 A의 값을 가져옴
                valueOfClothesSet = otherScript.GetClothesSet();
                Debug.Log("충돌한 오브젝트의 A 값: " + valueOfClothesSet);

                // 가져온 값을 사용하여 원하는 동작을 수행할 수 있음
            }

        }
    }

    void Awake(){
         // 이 스크립트가 붙은 오브젝트의 Collider 컴포넌트를 가져옴
        objectCollider = GetComponent<Collider2D>();

        // Collider가 있는지 확인
        if (objectCollider != null)
        {
            // Collider가 존재하면, 처음에 isTrigger를 꺼둠
            objectCollider.isTrigger = false;
        }
    }

    void Update()
    {
        // 스페이스바 입력을 감지하여 이동/멈춤을 토글
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
            objectCollider.isTrigger = true;
            
        }

        // 오브젝트가 이동 중일 때만 좌우로 움직임
         if (isMoving)
        {
            // 현재 위치에서 이동할 값 계산
            float move = direction * speed * Time.deltaTime;
            transform.Translate(move, 0, 0);

            // x 좌표가 -10보다 작으면 오른쪽으로, 10보다 크면 왼쪽으로 방향 전환
            if (transform.position.x >= 6f)
            {
                direction = -1; // 왼쪽으로 방향 전환
            }
            else if (transform.position.x <= -6f)
            {
                direction = 1; // 오른쪽으로 방향 전환
            }
        }
    }
}
