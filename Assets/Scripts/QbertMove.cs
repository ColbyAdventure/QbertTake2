using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QbertMove : MonoBehaviour {
    public bool midJump = false;

    public static int totalJumps = 0;

    public AudioSource sndObject;

    public AudioClip sndQbertSwear;
    public AudioClip sndQbertFall;
    //

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("a") && midJump == false ) //Down and Left
        {
            Debug.Log("A Key");
            midJump = true;
            totalJumps++;
            //transform.eulerAngles = new Vector3(-90, 0, 180);
            transform.eulerAngles = new Vector3(0, 90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
        }
        if (Input.GetKeyDown("s") && midJump == false) //Down and Right
        {
            Debug.Log("S Key");
            midJump = true;
            totalJumps++;
            //transform.eulerAngles = new Vector3(-90, 0, 90);
            transform.eulerAngles = new Vector3(0,0,0);
            GetComponent<Rigidbody>().velocity = new Vector3(1, 4, 0);
        }
        if (Input.GetKeyDown("q") && midJump == false) //Up and Left
        {
            Debug.Log("Q Key");
            midJump = true;
            totalJumps++;
            //transform.eulerAngles = new Vector3(-90, 0, -90);
            transform.eulerAngles = new Vector3(0, 180, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(-1, 6, 0);
        }
        if (Input.GetKeyDown("w") && midJump == false) //Up and Right
        {
            Debug.Log("W Key");
            midJump = true;
            totalJumps++;
            // transform.eulerAngles = new Vector3(-90, 0, 0);
            transform.eulerAngles = new Vector3(0,-90,0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 6, 1);
        }

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Tile")
        {
            Debug.Log("Tile Tag Collision");
            StartCoroutine(delayMove());
            midJump = false;
        }

        if (other.gameObject.tag == "BlobRed")
        {
            Debug.Log("Blob Tag Colllision");
            Time.timeScale = 0.0f;//ended With Delay Reset
            sndObject.clip = sndQbertSwear;
            sndObject.Play();
            GameManager.S_BoardReset = true;
            GameManager.S_LivesLeft -= 1;
            GetComponent<Transform>().position = new Vector3(0, 3, 0);
            transform.eulerAngles = new Vector3(0, 90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            StartCoroutine(delayReset());

            midJump = false;
        }
        if (other.gameObject.tag == "Coily")
        {
            Debug.Log("Snake Tag Colllision");
            Time.timeScale = 0.0f;//ended With Delay Reset
            sndObject.clip = sndQbertSwear;
            sndObject.Play();

            GameManager.S_BoardReset = true;
            GameManager.S_LivesLeft -= 1;
            GetComponent<Transform>().position = new Vector3(0, 3, 0);
            transform.eulerAngles = new Vector3(0, 90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            StartCoroutine(delayReset());

            midJump = false;
        }
        if (other.gameObject.tag == "Ugg")
        {
            Debug.Log("Ugg Tag Colllision");
            Time.timeScale = 0.0f;//ended With Delay Reset
            sndObject.clip = sndQbertSwear;
            sndObject.Play();


            GameManager.S_BoardReset = true;
            GameManager.S_LivesLeft -= 1;
            GetComponent<Transform>().position = new Vector3(0, 3, 0);
            transform.eulerAngles = new Vector3(0, 90, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            StartCoroutine(delayReset());

            midJump = false;
        }

        if (other.gameObject.tag == "Disc")
        {
            Debug.Log("Disc Tag Colllision");
            GameObject[] blobds = GameObject.FindGameObjectsWithTag("BlobRed");
            foreach (GameObject o in blobds)
            {
                //blobs.transform.GetComponent<Image>().enabled = false;
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }

            GameObject[] revrs = GameObject.FindGameObjectsWithTag("ReversingBaddy");
            foreach (GameObject o in revrs)
            {
                //blobs.transform.GetComponent<Image>().enabled = false;
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }

            GameObject[] Uggos = GameObject.FindGameObjectsWithTag("Ugg");
            foreach (GameObject o in Uggos)
            {
                //blobs.transform.GetComponent<Image>().enabled = false;
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }
            /*
             * 
             * almost the same as reset, Maybe make a resetMonsters and a REset Coily
             Check scene for Coily, destroy all other monters
             search for RedBlob, ReverseGuy, Ugg, Coily Egg
             ^^******  The Solution to the change of coily's sound was to change the tag, use that to keep him after hop on disc
             wait for x seconds

             */


            midJump = false;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "SafetyNet")
        {
            Debug.Log("Safety Net Collision");
            GetComponent<Transform>().position = new Vector3(0, 3, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

            //*****
            //Remove 1 life

            GameManager.S_LivesLeft = (GameManager.S_LivesLeft -1);
 
            //*****
            //sndObject.Play();
            //^^Moved To Wall Trigger
        }

        if (other.tag == "Top")
        {
            Debug.Log("Hit Top Of The Pyramid, time to Jump!");
            GetComponent<Transform>().position = new Vector3(0, 3, 0);
            //GetComponent<Rigidbody>().velocity = new Vector3(0, 4, -1);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.eulerAngles = new Vector3(0, 90, 0);

        }

    }

    


    IEnumerator delayMove() {
        // Debug.Log("Hello Delay Move");
        Debug.Log("DelayMove");
        yield return new WaitForSeconds(0.05f);
    }

    IEnumerator delayReset() {
        Debug.Log("DelayReset");

        yield return new WaitForSecondsRealtime(1.1f);
        GameManager.S_BoardReset = true;
        Time.timeScale = 1.0f;
        Debug.Log("Time.timeScale : " + Time.timeScale);
    }
}
