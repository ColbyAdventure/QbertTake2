using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSankeMove : MonoBehaviour {

    //private bool hatched = false;
    private int stepsToHatch = 6;
    private bool RandomNotSearching = true;

    //private Vector3 coilyPosition;
    public GameObject whereQbertIs;
    //public Vector3 qbertPosition;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.S_BoardReset == true)
        {
            Destroy(gameObject, 1);

        }
    }

    private void OnCollisionEnter(Collision other)//This doesn't start till it hits the ground
    {
        if (stepsToHatch > 0)
        {
            //WaitForSeconds(0.5);
            if (Random.Range(0, 2) == 0)
            {
                //Down and left
                transform.eulerAngles = new Vector3(0, 90, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
            }
            stepsToHatch -= 1;
        }
        else {
            Debug.Log("Hatched");
            //WaitForSeconds(3.0f);
            //Disable Ball, Enable Snake
            //*****

            transform.gameObject.tag = "Coily";
            //*****
            transform.Find("BallMeshes").GetComponent<MeshRenderer>().enabled = false;
            transform.Find("CoilyMesh").GetComponent<SkinnedMeshRenderer>().enabled = true;



            if (RandomNotSearching)
            {
                if (Random.Range(0, 2) == 0)
                {
                    //UP And Left
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
                }
                else
                {
                    //UP And RIGHT
                    transform.eulerAngles = new Vector3(0, -90, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
                }
            }
            else
            {
                //This is Searching

                float checkX;
                //checkX = qbertPosition.x - coilyPosition.x;
                checkX = whereQbertIs.transform.position.x - this.transform.position.x;
                float checkZ;
                //checkZ = qbertPosition.z - coilyPosition.z;
                checkZ = whereQbertIs.transform.position.z - this.transform.position.z;

            if (checkX <0 && checkZ <0)
            {
                Debug.Log ("moveSouthWest");
                    //Down and Left
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
                }
            else if (checkX <0 && checkZ >0)
            {
            Debug.Log ("moveNorthWest");
                    //Up and Left
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);

                }
            else if (checkX >0 && checkZ <0)
            {
            Debug.Log ("moveNorthEast");
                    //UP and Right
                    transform.eulerAngles = new Vector3(0, -90, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
                }
            else if (checkX >0 && checkZ >0)
            {
            Debug.Log ("moveSouthEast");
                    //Down and Right
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
                }
            /*
                if (distancex <0 && distancez <0)--
                     moveSouthWest
                if (distancex <0 && distancez >0)-+
                    moveNorthWest
                if (distancex >0 && distancez <0)+-
                    moveSouthEast
                if (distancex >0 && distancez >0)++
                    moveNorthEast


                PLayerObject.position.x - SnakeObject.position.x = distancex
                PLayerObject.position.y - SnakeObject.position.y = distancey
                */
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SafetyNet")
        {
            Destroy(gameObject);
            Debug.Log("Snake Fell To His Death");
            TempMonsterSpawner.totalMonstersOnScreen--;
            //Debug.Log("SnaketotalMonstersOnScreen" + TempMonsterSpawner.totalMonstersOnScreen);
        }


    }
}

/*
 new Vector3 from Player Object
 New Vector3 From Snake Object

    The other minus the home guy, the target minus the start

    PLayerObject.position.x - SnakeObject.position.x = distancex
    PLayerObject.position.y - SnakeObject.position.y = distancey
    ^^ Probably wrong, Nope corrct, the Player Is The Target, The Snake Is The Start Pos



    if (distancex <0 && distancey <0)--
        moveSouthWest
    if (distancex <0 && distancey >0)-+
        moveNorthWest
    if (distancex >0 && distancey <0)+-
        moveSouthEast
    if (distancex >0 && distancey >0)++
        moveNorthEast
     */
