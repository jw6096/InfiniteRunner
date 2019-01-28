using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public enum PUpType
    {
        SlowDown,
        Other1,
        Other2
    }

    public PUpType pUpType;
    public int value;

    private GameObject mObject;

	// Use this for initialization
	void Start () {
        mObject = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D()
    {
        if (pUpType == PUpType.SlowDown)
        {
            mObject.SendMessage("SlowDown", value);
            Destroy(gameObject);
        }
        

        switch (pUpType)
        {
            case PUpType.SlowDown:
                mObject.SendMessage("SlowDown", value);
                Destroy(gameObject);
                break;
            case PUpType.Other1:
                Debug.Log("Not handled case 1.");
                Destroy(gameObject);
                break;
            case PUpType.Other2:
                Debug.Log("Not handled case 2.");
                Destroy(gameObject);
                break;
            default:
                Debug.Log("Not an acceptable case.");
                Destroy(gameObject);
                break;

        }
    }
}
