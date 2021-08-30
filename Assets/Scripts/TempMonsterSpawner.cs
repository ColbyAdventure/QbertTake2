using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMonsterSpawner : MonoBehaviour {

    //Spawn Points
    public Transform TopSpawnPoint;
    public Transform TopLeftSpawnPoint;
    public Transform TopRightSpawnPoint;


    public GameObject LeftSpawnPoint;
    public GameObject RighSpawnPoint;



    //Prefabs
    public Transform BlobGreenPrefab;
    public Transform BlobRedPrefab;
    public Transform CoilyPrefab;
    public Transform SlickAndSamPrefab;


    //Variables

    public static int totalMonstersOnScreen;
    private bool coliyOnScreen = false;
    private bool PickTopLeftPoint = true;



	// Use this for initialization
	void Start () {
        LevelCheck();


    }

    void LevelCheck()
    {
        if (GameManager.S_currentLevel == 1)
        {
            Debug.Log("Blobs Level");
            InitSpawnBlobs();
        }
        if (GameManager.S_currentLevel == 2)
        {
            Debug.Log("Level 2 - Blobs Level");
            InitSpawnBlobs();
        }
        if (GameManager.S_currentLevel == 3)
        {
            Debug.Log("Level 3 - Ugg Level");
            InitSpawnUgg();//Really Should Be Uggs
        }
        if (GameManager.S_currentLevel == 4)
        {
            Debug.Log("Level 4 - Blobs Level");
            InitSpawnBlobs();
        }
    }

    void InitSpawnBlobs()
    {
        Transform monsterSpawnnPoint;

        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                monsterSpawnnPoint = TopLeftSpawnPoint;
                //StartCoroutine(spawnBlobs());
                break;

            case 1:
                monsterSpawnnPoint = TopRightSpawnPoint;
                //StartCoroutine(spawnBlobs());
                break;

            default:
                break;

        }
        StartCoroutine(spawnBlobs());

        //monsterSpawnnPoint = TopLeftSpawnPoint;
        //StartCoroutine(spawnBlobs());

        //monsterSpawnnPoint = TopRightSpawnPoint;
        //StartCoroutine(spawnBlobs());
        //if (PickTopLeftPoint)
        //    {
        //        monsterSpawnnPoint = TopLeftSpawnPoint;
        //        PickTopLeftPoint = !PickTopLeftPoint;
        //    }
        //    else
        //    {
        //        monsterSpawnnPoint = TopRightSpawnPoint;
        //        PickTopLeftPoint = !PickTopLeftPoint;
        //    }


        //StartCoroutine(spawnBlobs());
        //StartCoroutine(spawnBlobs());
        //^^ Like This or repeat inside the Coroutine **Loop 2 times**

        //IEnumerator spawnBlobs()
        //{
        //    yield return new WaitForSeconds(4);
        //    TempMonsterSpawner.totalMonstersOnScreen++;
        //    Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        //    Instantiate(BlobRedPrefab, new Vector3(0, 3, 0), BlobRedPrefab.rotation);
        //    //StartCoroutine(spawnBlobs());
        //}
        /*
        wait(4) Seconds
        Instantiate(BlobRedPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), BlobRedPrefab.rotation);
        wait(4) Seconds
        Instantiate(BlobRedPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), BlobRedPrefab.rotation);
        wait(4) Seconds
        Instantiate(CoilyPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), CoilyPrefab.rotation);
        */
    }



    IEnumerator spawnBlobs()
    {
        yield return new WaitForSeconds(4);
        TempMonsterSpawner.totalMonstersOnScreen++;
        Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(BlobRedPrefab, new Vector3(0, 3, 0), BlobRedPrefab.rotation);
        StartCoroutine(spawnBlobs());
    }


















    void InitSpawnUgg()
    {
        /*
        wait(4) Seconds
        Instantiate(SlickAndSamPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), SlickAndSamPrefab.rotation);
        wait(4) Seconds
        Instantiate(SlickAndSamPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), SlickAndSamPrefab.rotation);
        wait(4) Seconds
        Instantiate(CoilyPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), CoilyPrefab.rotation);
        */

    }


    void Update ()
    {
        //WaitForSeconds(4);
        Spawnloop();


    }

    void Spawnloop()
    {
        Transform monsterSpawnnPoint;

        if (totalMonstersOnScreen < (GameManager.S_currentLevel +2)) //Cuz Level 1 got 3, level 3 got 5, thems the rules
        {
            if (PickTopLeftPoint)
            {
                monsterSpawnnPoint = TopLeftSpawnPoint;
                PickTopLeftPoint = !PickTopLeftPoint;
            }
            else
            {
                monsterSpawnnPoint = TopRightSpawnPoint;
                PickTopLeftPoint = !PickTopLeftPoint;
            }

            

            if (!coliyOnScreen)
            {
                //Instantiate(CoilyPrefab, new Vector3(0, 3, 0), CoilyPrefab.rotation);
                Instantiate(CoilyPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), CoilyPrefab.rotation);
                //^^**** I Want it to be Instantiate(CoilyPrefab, monsterSpawnnPoint, CoilyPrefab.rotation);
                totalMonstersOnScreen++; 
            }
            else
            {
                //Instantiate(BlobRedPrefab, new Vector3(0, 3, 0), BlobRedPrefab.rotation);
                Instantiate(BlobRedPrefab, new Vector3((monsterSpawnnPoint.transform.position.x), 3, (monsterSpawnnPoint.transform.position.z)), BlobRedPrefab.rotation);
                //^^**** I Want it to be Instantiate(CoilyPrefab, monsterSpawnnPoint, CoilyPrefab.rotation);
                totalMonstersOnScreen++;


            }
        }
        else
        {
            Debug.Log("No Monsters? ");
        }
    }



















    /*


    //**************************************************************
    IEnumerator spawnBlobs()
    {
        yield return new WaitForSeconds(511111);
        TempMonsterSpawner.totalMonstersOnScreen++;
        Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(blobObj, new Vector3(0, 3, 0), blobObj.rotation);
        StartCoroutine(spawnBlobs());
    }

    IEnumerator spawnReversingBaddies()
    {
        yield return new WaitForSeconds(111112);
        TempMonsterSpawner.totalMonstersOnScreen++;
        Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(reversingBaddyObj, new Vector3(0, 3, 0), reversingBaddyObj.rotation);
        StartCoroutine(spawnReversingBaddies());
    }

    IEnumerator spawnSnake()
    {
        yield return new WaitForSeconds(11110);
        TempMonsterSpawner.totalMonstersOnScreen++;
        //Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(SnakeObj, new Vector3(0, 3, 0), SnakeObj.rotation);
        StartCoroutine(spawnSnake());
    }

    IEnumerator spawnUggRight()
    {
        yield return new WaitForSeconds(2);
        TempMonsterSpawner.totalMonstersOnScreen++;
        Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(UggRightObj, new Vector3(8, -7, 0), UggRightObj.rotation);
        StartCoroutine(spawnUggRight());
    }

    IEnumerator spawnUggLeft()
    {
        yield return new WaitForSeconds(3);
        TempMonsterSpawner.totalMonstersOnScreen++;
        Debug.Log("totalMonstersOnScreen: " + TempMonsterSpawner.totalMonstersOnScreen);
        Instantiate(UggLeftObj, new Vector3(0, -7, -8), UggLeftObj.rotation);
        StartCoroutine(spawnUggLeft());
    }




    //StartCoroutine(spawnBlobs());
    //StartCoroutine(spawnReversingBaddies());
    //StartCoroutine(spawnSnake());
    //StartCoroutine(spawnUggRight());
    //StartCoroutine(spawnUggLeft());

    */
}
