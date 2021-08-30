using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    public Text Instructions1;
    public Text Instructions2;
    public Text Instructions3;
    public Text Instructions4;

    // Use this for initialization
    void Start () {
        StartCoroutine(IntroSteps());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator IntroSteps()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Step 2wo" + "Down and Right");
        transform.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        Instructions1.GetComponent<Text>().enabled = true;

        yield return new WaitForSeconds(2.0f);
        Debug.Log("Step 2wo" + "Down and Right");
        transform.eulerAngles = new Vector3(0, 0, 0);
        Instructions2.GetComponent<Text>().enabled = true;
        GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);


        yield return new WaitForSeconds(2.0f);
        Debug.Log("Step 2wo" + "Down and Right");
        transform.eulerAngles = new Vector3(0, 0, 0);
        Instructions3.GetComponent<Text>().enabled = true;
        GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);


        yield return new WaitForSeconds(2.0f);
        Debug.Log("Step 2wo" + "Down and Right");
        transform.eulerAngles = new Vector3(0, 0, 0);
        Instructions4.GetComponent<Text>().enabled = true;
        GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);



        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("IntroLevel");
    }

    }

