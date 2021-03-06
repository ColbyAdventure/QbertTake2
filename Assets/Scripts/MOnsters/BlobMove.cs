using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.S_BoardReset == true)
        {
            Destroy(gameObject, 1);

        }
    }

    private void OnCollisionEnter(Collision other)//This doesn't start till it hits the ground
    {
        //WaitFor 0.5 Seconds

        //Down and Left

        if (Random.Range(0, 2) == 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SafetyNet")
        {
            Destroy(gameObject); //gameObject, 1
            Debug.Log("Red Blob Fell To His Death");
            TempMonsterSpawner.totalMonstersOnScreen--;
            //Debug.Log("Blob Move totalMonstersOnScreen" + TempMonsterSpawner.totalMonstersOnScreen);
        }
    }
}