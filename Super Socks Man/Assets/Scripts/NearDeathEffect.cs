using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearDeathEffect : MonoBehaviour
{

    public Transform playerTransform;
    CamTrack track;
    SpriteRenderer effectSprite;
    public float referenceDistance;
    public float minBlinkTime;

    float blinkTime;
    float timeSinceBlink;

    float distance;
    float centerPoint;

	// Use this for initialization
	void Start ()
    {
        referenceDistance = -9.0f;
        //minBlinkTime = 0.3f;
        blinkTime = minBlinkTime;
        track = Camera.main.GetComponent<CamTrack>();

        effectSprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeSinceBlink += Time.deltaTime;
        centerPoint = track.distance;

        distance = playerTransform.position.x - (centerPoint + referenceDistance);

        AlterColor();

        if ((distance) <= 1.5)
        {
            timeSinceBlink = 0.0f;

            effectSprite.enabled = true;
        }
        else
        {
            blinkTime = Mathf.Max(minBlinkTime, distance * 0.1f);
            //Debug.Log(blinkTime);

            if(timeSinceBlink >= blinkTime)
            {
                Blink();
                timeSinceBlink = 0.0f;
            }
        }
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
        effectSprite.color = new Color(1, (distance / 5) - 1, (distance / 5) - 1, 1 - (distance * 0.05f));
    }
}
