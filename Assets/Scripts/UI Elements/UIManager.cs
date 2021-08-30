using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text playerScore;

    public Image[] qbertPixelIcons;
    public RawImage[] qbertCameraIcons;


    // Use this for initialization
    void Start () {

    for (int i = 0; i < qbertPixelIcons.Length; i++)
        {
            //Disable all images
            qbertPixelIcons[i].transform.GetComponent<Image>().enabled = false;
            qbertCameraIcons[i].transform.GetComponent<RawImage>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        playerScore.text = GameManager.S_PlayerScore + "";

        for (int i = 0; i < qbertPixelIcons.Length; i++)
        {
            //Disable all images
            qbertPixelIcons[i].transform.GetComponent<Image>().enabled = false;
            qbertCameraIcons[i].transform.GetComponent<RawImage>().enabled = false;
        }

        for (int i = 0; i < GameManager.S_LivesLeft; i++)
        {
            //Disable all images
            qbertPixelIcons[i].transform.GetComponent<Image>().enabled = true;
            qbertCameraIcons[i].transform.GetComponent<RawImage>().enabled = true;
        }
    }
}
