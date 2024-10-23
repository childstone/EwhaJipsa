using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingA: MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(CaseA());
        }   
    }

    IEnumerator CaseA()
    {
        SceneManager.LoadScene("Scene4");
        yield return null;
    }
}
