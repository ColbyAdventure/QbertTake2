using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QbertRobo : MonoBehaviour {
    public bool midJump = false;
    // Use this for initialization
    void Start () {
        StartCoroutine(IntroPause());
        StartCoroutine(IntroDance());
	}

    IEnumerator IntroPause()
    {
        Debug.Log("Timer Has Begun");
        yield return new WaitForSeconds(7.0f);
        Debug.Log("Load The Next Level");
        SceneManager.LoadScene("Level01");
    }

    IEnumerator IntroDance()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Step 2wo" + "Down and Right");
        transform.eulerAngles = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);

        yield return new WaitForSeconds(1.0f);
        Debug.Log("Step Thr3" + " Up and Left");
        transform.eulerAngles = new Vector3(0, 180, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);

        yield return new WaitForSeconds(1.0f);
        Debug.Log("Step 1ne" + " Down and Left");
        transform.eulerAngles = new Vector3(0, 90, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);





        yield return new WaitForSeconds(1.0f);
        Debug.Log("Step 4our" + " Up and Right");
        transform.eulerAngles = new Vector3(0, -90, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);


    }
	// Update is called once per frame
	//void Update () {
		
	//}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && midJump == false) //Down and Left
        {

            transform.eulerAngles = new Vector3(0, 90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        }
        if (Input.GetKeyDown("s") && midJump == false) //Down and Right
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        }
        if (Input.GetKeyDown("q") && midJump == false) //Up and Left
        {

            transform.eulerAngles = new Vector3(0, 180, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
        }
        if (Input.GetKeyDown("w") && midJump == false) //Up and Right
        {

            transform.eulerAngles = new Vector3(0, -90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
        }

    }

}
