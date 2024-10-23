using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{

    public GameObject Endings;
    bool isTrueEnding;

    // Start is called before the first frame update
    void Start()
    {
        int [] clothesSet = GameManager.Instance.getCurrentClothesSet();
        isTrueEnding=false;
        DetermineEnding(clothesSet);
        
    }

    void DetermineEnding(int [] clothesSet)
    {
        int EndingNum = FindNum(clothesSet);
        
        //임시로 Ending 1이 실행되도록 하였습니다.
        Transform Child = Endings.transform.GetChild(0);
        GameObject Ending = Child.gameObject;
        Ending.SetActive(true);
           


        /*
        if(isTrueEnding){
            Transform Child = Endings.transform.GetChild(EndingNum);
            GameObject Ending = Child.gameObject;
            Ending.SetActive(true);
            }
        else {
            Transform Child = Endings.transform.GetChild(EndingNum+5);
            GameObject Ending = Child.gameObject;
            Ending.SetActive(true);
            }
        */
    }

    int FindNum(int [] clothesSet){
        int max=0;
        int answer=0;
        int [] count = new int[5];

        for(int i=0; i<clothesSet.Length; i++){
            count[clothesSet[i]]++;

            if(max<count[clothesSet[i]]){
                max=count[clothesSet[i]];
                answer=clothesSet[i];
            }
        }

        if(max==4){
            isTrueEnding=true;
            return answer;
        }
        else{
            return max;
        }


    }
}
