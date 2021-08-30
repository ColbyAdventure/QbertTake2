using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int S_TilesRemaining = 28;
    //^^Start Should Read the value of the Ints in Countdown on Awake
    public Transform blobObj;
    public Transform reversingBaddyObj;
    public Transform SnakeObj;
    public Transform UggRightObj;
    public Transform UggLeftObj;

    public static int S_LivesLeft = 3;

    //**** 
    public static bool S_BoardReset = false;

    public static int S_PlayerScore = 0; // What about -25 for first drop????


    //*****
    public static int S_currentLevel = 1;
    //*****

    // Use this for initialization
    void Start()
    {
        S_PlayerScore = 0;
        //^^To Rest After The Demo Screen
        StartCoroutine(spawnBlobs());
        StartCoroutine(spawnReversingBaddies());
        //StartCoroutine(spawnSnake());
        //StartCoroutine(spawnUggRight());
        //StartCoroutine(spawnUggLeft());
        //^^Change this to An "Object pool" Instatniate and 
    }

    // Update is called once per frame
    void Update()
    {
        if (S_TilesRemaining < 1)
        {
            //S_PlayerScore += 1000; //Base Score + LevelNumber * x
            S_PlayerScore += 750 + (S_currentLevel * 250);
            Debug.Log("You Win the Game,Hail Hydra");
            Debug.Log("Now, Wait for Four Seconds");
            StartCoroutine(loadNextLevel());
        }

        if (S_LivesLeft <= 0)
        {
            Debug.Log("Zero Lives, Game Over");
            SceneManager.LoadScene("GameOver");
        }

        if (S_BoardReset)
        {
            //Destroy all the enemies TAGS:BlobRed, Coily, ReversingBaddy, Ugg
            GameObject[] blobds = GameObject.FindGameObjectsWithTag("BlobRed") ;
            foreach (GameObject o in blobds)
            {
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }
            GameObject[] snkes = GameObject.FindGameObjectsWithTag("Coily");
            foreach (GameObject o in snkes)
            {
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }
            GameObject[] revrs = GameObject.FindGameObjectsWithTag("ReversingBaddy");
            foreach (GameObject o in revrs)
            {
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }
            GameObject[] blobgn = GameObject.FindGameObjectsWithTag("BlobGreen");
            foreach (GameObject o in blobgn)
            {
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }
            GameObject[] Uggos = GameObject.FindGameObjectsWithTag("Ugg");
            foreach (GameObject o in Uggos)
            {
                Destroy(o);

                TempMonsterSpawner.totalMonstersOnScreen--;
            }
            //*******
            S_BoardReset = false;
            //********
        }
    }

    IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(4);
        S_TilesRemaining = 28;
        //^^TODO:Create a "Level Set Up"
        SceneManager.LoadScene("Level01");
    }

    IEnumerator spawnBlobs()
    {
        yield return new WaitForSeconds(4);
        TempMonsterSpawner.totalMonstersOnScreen++;
        //Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(blobObj, new Vector3(0, 3, 0), blobObj.rotation);
        StartCoroutine(spawnBlobs());
    }

    IEnumerator spawnReversingBaddies()
    {
        yield return new WaitForSeconds(11);
        TempMonsterSpawner.totalMonstersOnScreen++;
        //Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(reversingBaddyObj, new Vector3(0, 3, 0), reversingBaddyObj.rotation);
        StartCoroutine(spawnReversingBaddies());
    }

    IEnumerator spawnSnake()
    {
        yield return new WaitForSeconds(5);
        TempMonsterSpawner.totalMonstersOnScreen++;
        //Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(SnakeObj, new Vector3(0, 3, 0), SnakeObj.rotation);
        StartCoroutine(spawnSnake());
    }

    IEnumerator spawnUggRight()
    {
        yield return new WaitForSeconds(3);
        TempMonsterSpawner.totalMonstersOnScreen++;
        Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(UggRightObj, new Vector3(8, -7, 0), UggRightObj.rotation);
        StartCoroutine(spawnUggRight());
    }

    IEnumerator spawnUggLeft()
    {
        yield return new WaitForSeconds(7);
        TempMonsterSpawner.totalMonstersOnScreen++;
        Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(UggLeftObj, new Vector3(0, -7, -8), UggLeftObj.rotation);
        StartCoroutine(spawnUggLeft());
    }
}