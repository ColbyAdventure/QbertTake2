using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour
{
    public AudioSource sndObject;
    public AudioClip sndDiscFly;
    public bool rightSideDisc;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (rightSideDisc)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2, 2, 0);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 3, 2);
        }


        //Add Green Flash To The SkyBox (Green to Black), 0.5 Seconds
        sndObject.clip = sndDiscFly;
        sndObject.Play();
    }
}