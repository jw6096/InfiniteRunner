using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Camera mainCamera;
    AudioSource musicSource;

    //Store item array
    bool[] purchasedItems;

    static int coins = 200;
    static int currentSock = -1;   //-1 means no custom sock

    float musicVolume;

    public bool[] PurchasedItems
    {
        get { return purchasedItems; }
        set { purchasedItems = value; }
    }

    public int Coins
    {
        get { return coins; }
        set
        {
            if(coins <= 0)
            {
                coins = 0;
            }
            else
            {
                coins = value;
            }
        }
    }

    public int CurrentSock
    {
        get { return currentSock; }
        set
        {
            if (currentSock < -1)
            {
                currentSock = -1;
            }
            else if(currentSock >= purchasedItems.Length)
            {
                currentSock = purchasedItems.Length - 1;
            }
            else
            {
                currentSock = value;
            }
        }
    }

    private void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else if(GameManager.instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

    }

    // Use this for initialization
    void Start ()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        musicSource = mainCamera.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    //Options Methods
    public void ChangeMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = volume;
    }
}
