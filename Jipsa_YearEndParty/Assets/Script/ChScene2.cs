using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChScene2 : MonoBehaviour
{
    public GameObject S2UI;
    bool isUIActive = false;

    // Start is called before the first frame update
    void Start()
    {
        S2UI.SetActive(false);   
    }

    public void OnButtonClick(){
        S2UI.SetActive(true);
        isUIActive=true;
    }
}
