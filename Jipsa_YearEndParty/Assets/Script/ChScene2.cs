using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChScene2 : MonoBehaviour
{
    public GameObject S2UI;
    public Button btun1;
    bool isUIActive = false;

    // Start is called before the first frame update
    void Start()
    {
        S2UI.SetActive(false);   
    }

    void OnClick(){
        S2UI.SetActive(true);
        isUIActive=true;
    }

    // Update is called once per frame
    void Update()
    {
        btun1.onClick.AddListener(OnClick);

        if(isUIActive){
            if(Input.GetMouseButtonDown(0))
                S2UI.SetActive(false);   
                
        }
    }
}
