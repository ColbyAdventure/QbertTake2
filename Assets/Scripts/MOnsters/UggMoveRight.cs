using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UggMoveRight : MonoBehaviour
{
    private int stepsToClimb = 3;

    public AudioSource sndObject;

    public AudioClip sndUggHello;

    // Use this for initialization
    void Start()
    {
        sndObject.clip = sndUggHello;
        sndObject.Play();
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

            if (stepsToClimb > 0)
            {
               // Debug.Log("StillClimbing");
                transform.eulerAngles = new Vector3(0, 180, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
                stepsToClimb -= 1;
            }
            else
            {
                //Debug.Log("DoneClimbing");
                if (Random.Range(0, 2) == 0)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
                }
            }
    }






    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SafetyNet")
        {
        Destroy(gameObject);
        Debug.Log("Ugg Fell To His Death");
            TempMonsterSpawner.totalMonstersOnScreen--;
            //****ToDO:

            //Debug.Log("Ugg Move totalMonstersOnScreen" + TempMonsterSpawner.totalMonstersOnScreen);
        }
    }
}