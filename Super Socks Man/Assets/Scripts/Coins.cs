using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    private CamTrack camTrack;
    private float coins;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        camTrack = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamTrack>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (camTrack.deathScreen && !camTrack.check)
        {
            coins += (float)Math.Round(camTrack.distTraveled);
            text.text = "Total Coins: " + coins.ToString();
            camTrack.check = true;
        }
    }
}
