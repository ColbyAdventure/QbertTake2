using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempUIScripts : MonoBehaviour {
    //public static int S_TilesRemaining = 28;
    //public GameManager gm;
    public Text totalJumps;
    public Text spotsLeft;
    public Text playerScore;
    public Text highScore;
    public Text livesLeft;

    public Image Live01;
    public Image Live02;
    public Image Live03;
    public Image Live04;
    public Image Live05;
    public Image Live06;
    public Image Live07;
    public Image Live08;
    public Image Live09;
    public Image Live10;

    //public Image[] qbertPixelIcons;



    // Use this for initialization
    void Start () {
        spotsLeft.text = GameManager.S_TilesRemaining + "";
        totalJumps.text = QbertMove.totalJumps + ""; ;
        //Debug.Log (GameManager.S_TilesRemaining + "");
        //playerScore.text = "Zero";
        //highScore.text = "> Zero";
        //Debug.Log(GameManager.S_LivesLeft + "");
        livesLeft.text = GameManager.S_LivesLeft + "";

        //GameObject[] o = GameObject.FindGameObjectsWithTag("QbertIcon");
        //foreach (GameObject qberticon in o)
        //{
        //    qberticon.transform.GetComponent<Image>().enabled = false;
        //}


    }

    // Update is called once per frame
    void Update () {
        // spotsLeft.text = S_TilesRemaining + "";
        spotsLeft.text = GameManager.S_TilesRemaining + "";
        totalJumps.text = QbertMove.totalJumps + "";
        playerScore.text = GameManager.S_PlayerScore + "";
        livesLeft.text = GameManager.S_LivesLeft + "";


        for (int i = 0; i < GameManager.S_LivesLeft; i++)
        {
            //Disable all images
            //Live01.enabled = false;
            //qbertPixelIcons[i].transform.GetComponent<Image>().enabled = true;
        }






        {
            //Enable Images
        }

    }
}
