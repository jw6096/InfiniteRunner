using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearDeathEffect : MonoBehaviour
{

    public Transform playerTransform;
    CamTrack track;
    SpriteRenderer effectSprite;
    float referenceDistance;

    float blinkTime;
    float minBlinkTime;

    float timeSinceBlink;

    bool solid;

	// Use this for initialization
	void Start ()
    {
        referenceDistance = -9.0f;
        minBlinkTime = 0.3f;
        track = Camera.main.GetComponent<CamTrack>();
	}
	
	// Update is called once per frame
	void Update ()
    {


        if ((playerTransform.position.x + referenceDistance) / 2.0f <= 3)
        {
            solid = true;
        }
        else
        {
            solid = false;

            blinkTime = Mathf.Max(minBlinkTime, (playerTransform.position.x + referenceDistance) * 0.5f);

            if(timeSinceBlink >= blinkTime)
            {
                Blink();
                AlterColor();
                timeSinceBlink = 0.0f;
            }
        }
	}

    public void UpdatePosition(float xOffset)
    {
        referenceDistance = xOffset;
        //transform.position = Vector3xOffset;
    }

    void Blink()
    {
        if(effectSprite.enabled == true)
        {
            effectSprite.enabled = false;
        }
        else
        {
            effectSprite.enabled = true;
        }
    }

    void AlterColor()
    {
        effectSprite.color = new Color(1, 1 - (playerTransform.position.x / referenceDistance), 1 - (playerTransform.position.x / referenceDistance));
    }
}
