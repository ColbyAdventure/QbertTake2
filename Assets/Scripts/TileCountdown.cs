using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCountdown : MonoBehaviour {

    public Material Mat1;
    public Material Mat2;
    //public Material Mat3;
    //public Material Mat4;
    //public Material Mat5;
    //public Material Mat6;
    //public Material Mat7;
    //public Material Mat8;
    public Material Mat9;

    public int StepsTillDone = 1;
    //^^ The first square you land on needs to be +1, Change me TODO:****

    public static int S_TilesRemaining = 28;




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other) {
        //TODO Enemies

        if (other.gameObject.tag == "Qbert"){
            StepsTillDone -= 1;
            if (StepsTillDone == 0)
            {
                GetComponent<Renderer>().material = Mat1;
                GameManager.S_TilesRemaining -= 1;
            }
            if (StepsTillDone < 0)
            {
                StepsTillDone = 0;
            }
        }

        if (other.gameObject.tag == "ReversingBaddy")
        {
            StepsTillDone += 1;

            int  m_Max = 1; 
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

        }

    }
}
