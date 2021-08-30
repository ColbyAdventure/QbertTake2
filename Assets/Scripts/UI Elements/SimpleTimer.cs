using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SimpleTimer : MonoBehaviour
{
    public bool isGaming;
    public Text txt;

    void Awake()
    {
        //txt = GetComponent<Text>();
        txt.text = "0";
    }

    void Start()
    {
        isGaming = true;
    }

    void Update()
    {
        if (isGaming)
            txt.text = Time.time.ToString("#.00");
    }
}
