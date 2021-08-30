using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {
    public AudioSource sndObject;

    public AudioClip sndSnakeFall;
    public AudioClip sndQbertFall;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }




    private void OnTriggerEnter(Collider other)
    {
        //TODO Enemies
        Debug.Log("Triggered");
        if (other.gameObject.tag == "Coily")
        {
            Debug.Log("Saw Coily Tag, make Snake Fall Sound");
            sndObject.clip = sndSnakeFall;
            sndObject.Play();
        }
        if (other.gameObject.tag == "Qbert")
        {
            Debug.Log("saw qbert tag, mke wbert fall sound");
            sndObject.clip = sndQbertFall;
            sndObject.Play();
        }
    }





}
