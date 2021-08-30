using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ScreenPause());
    }

    IEnumerator ScreenPause()
    {



        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("InstructionScreen");
    }
}
