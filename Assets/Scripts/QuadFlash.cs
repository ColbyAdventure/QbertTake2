using UnityEngine;

public class QuadFlash : MonoBehaviour
{
    /*
     Enable the Quad
     Take The Colour From Green to Black in 1 second
     Disable Quad
         
         
         */




    Color lerpedColor = Color.green;

    void start()
    {
        this.transform.GetComponent<Material>().color = lerpedColor;
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.green, Color.black, Mathf.PingPong(Time.time, 1));
    }
}