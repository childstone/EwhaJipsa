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
    private int count=0;
    public GameObject sceneChange;
    public GameObject [] visible = new GameObject[4];

    public int getCount(){
        return count;
    }

// Trigger 충돌 감지 함수
     void OnTriggerEnter2D(Collider2D other)
    {

        if(other ==null)
            Debug.Log("null입니다");
        // 충돌한 오브젝트의 태그가 "ClothesChoice"인지 확인
        if (other.gameObject.CompareTag("ClothesChoice"))
        {

            // Clothes 컴포넌트를 가져옴
            Choice otherScript = other.gameObject.GetComponent<Choice>();

            // 컴포넌트가 존재하는지 확인
            if (otherScript != null)
            {
                // 변수 A의 값을 가져옴
                valueOfClothesSet = otherScript.GetChoiceClothesSet();
                Debug.Log("충돌한 오브젝트의 clothesSet 값: " + valueOfClothesSet);

                // 가져온 값을 사용하여 원하는 동작을 수행할 수 있음
            }
            else
            {
                Debug.LogWarning("충돌한 오브젝트에 Clothes 컴포넌트가 없습니다.");
            }
        }
    }

    void Start(){
         for(int i=0; i<4; i++){
            visible[i].SetActive(false);
        }

        visible[0].SetActive(true);
    }

        // Coroutine으로 1초 기다린 후 실행
    private IEnumerator DelayAction()
    {
        // 3초 대기
        yield return new WaitForSeconds(1f);

        isMoving = true;
    }

    public void VisibleControl(int count)
    {
        visible[count].SetActive(true);
        visible[(count-1)].SetActive(false);
    }

    

    void Update()
    {
        // 스페이스바 입력을 감지하여 이동/멈춤을 토글
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
             // 현재 clothesSet 값을 GameManager에 저장
            GameManager.Instance.setCurrentClothesSet(count,valueOfClothesSet); 

            if(count<3){
                count++;
                VisibleControl(count);
            }         
            else
                sceneChange.GetComponent<ChScene4>().SceneChange();


            StartCoroutine(DelayAction());
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
