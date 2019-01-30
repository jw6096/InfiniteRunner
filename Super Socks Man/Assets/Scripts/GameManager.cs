using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int coins;

    int Coins
    {
        get { return coins; }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start ()
    {
        //Test purposes
        coins = 100000;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
