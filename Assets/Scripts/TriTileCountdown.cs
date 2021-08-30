using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriTileCountdown : MonoBehaviour
{

    public Material Mat1; //Blue
    public Material Mat2; //Yellow
    public Material Mat3; //Green
    //public Material Mat4; //Red
    //public Material Mat5; //Left
    //public Material Mat6; //Right
    //public Material Mat7;
    //public Material Mat8;
    public Material Mat9;

    public int StepsTillDone = 1;
    //^^ The first square you land on needs to be +1, Change me TODO:****


    //Qbert Sounds
    public AudioSource sndObject;
    public AudioClip sndChangeColour; //Land and Colour Change
    public AudioClip sndNoChangeColour; //Land and No Colour Change

    //Enemy Sounds
    public AudioClip sndBlobLand; //BlobLand =snd_Jump3
    public AudioClip sndSnakeLand; //snd_Jump4
    public AudioClip sndUggLand;//snd_Jump2

    // Use this for initialization
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        //TODO Enemies

        if (other.gameObject.tag == "Qbert")
        {
            StepsTillDone -= 1;

            //********** Add Score
            //S_PlayerScore = S_PlayerScore + 25;
            //**** Placing the score here, means adding 25 to start to remove the "Extra" 25 of the first hit
            //but then you need a system to give point only on change, on landing
            //********** Add Score

            if (StepsTillDone == 0)
            {
                GetComponent<Renderer>().material = Mat1;
                GameManager.S_TilesRemaining -= 1;
                GameManager.S_PlayerScore = GameManager.S_PlayerScore + 25;
                //Add DoneStepSound
                sndObject.clip = sndChangeColour;
                sndObject.Play();
            }
            else {
                sndObject.clip = sndNoChangeColour;
                sndObject.Play();
            }





            if (StepsTillDone < 0)
            {
                StepsTillDone = 0;
            }
        }

        if (other.gameObject.tag == "ReversingBaddy")
        {
            StepsTillDone += 1;

            int m_Max = 1;
            //^^ Temp till adding an if > Max Statement

            if (StepsTillDone == 1)
            {
                GetComponent<Renderer>().material = Mat2;
                GameManager.S_TilesRemaining += 1;
            }
            if (StepsTillDone > m_Max)
            {
                StepsTillDone = m_Max;
            }
            sndObject.clip = sndBlobLand;
            sndObject.Play();
        }

        if (other.gameObject.tag == "BlobRed")//Blobs
        {
            sndObject.clip = sndBlobLand;
            sndObject.Play();
        }
        if (other.gameObject.tag == "Coily")//Coily
        {
            sndObject.clip = sndSnakeLand;
            sndObject.Play();
        }

        if (other.gameObject.tag == "Ugg")//Uggs
        {
            sndObject.clip = sndUggLand;
            sndObject.Play();
        }


    }
}
