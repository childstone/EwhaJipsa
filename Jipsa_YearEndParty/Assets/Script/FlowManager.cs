using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scene4의 게임 진행을 전반적으로 책임지는 스크립트

public class FlowManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Endings;
    public GameObject EndingManager;
    public GameObject GetDressed;
    public GameObject defaultMan;


    void Awake()
    {
        //모든 오브젝트 비활성화
        EndingManager.SetActive(false);
        Endings.SetActive(false);
        GetDressed.SetActive(false);
        defaultMan.SetActive(false);
    }


    void Start()
    {
        // 코루틴 시작
        StartCoroutine(FlowSequence());
    }

    private IEnumerator FlowSequence()
    {
        // default 오브젝트를 활성화
        defaultMan.SetActive(true);
        // GetDressed 오브젝트를 활성화
        GetDressed.SetActive(true);

        // GetDressed 작업 완료 후 대기 (여기서는 1초 대기)
        yield return new WaitForSeconds(1f); // 이 부분은 실제로 비동기 작업이 끝날 때까지 대기할 수 있습니다.

        // 그 이후 순서들 ... 
    }
}
