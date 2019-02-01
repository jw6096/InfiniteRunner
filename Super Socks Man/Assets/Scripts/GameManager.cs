using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    //public Camera mainCamera;
    AudioSource musicSource;

    //Store item array
    GameObject[] storeItems;
    bool[] purchasedItems;

    static int coins = 200;
    float musicVolume = 1.0f;

    public GameObject[] StoreItems
    {
        get { return storeItems; }
        set { storeItems = value; }
    }

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
        //if(mainCamera == null)
        //{
        //    mainCamera = Camera.main;
        //}
        //musicSource = mainCamera.GetComponent<AudioSource>();
        musicSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        musicSource.volume = musicVolume;
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
