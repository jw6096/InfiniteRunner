using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEffect : MonoBehaviour {
    public float countDown;

    private float cDown;
    private SpriteRenderer render;

	// Use this for initialization
	void Start () {
        render = gameObject.GetComponent<SpriteRenderer>();
        cDown = countDown;
	}
	
	// Update is called once per frame
	void Update () {
        cDown -= Time.deltaTime;
        gameObject.transform.position -= new Vector3(Time.deltaTime, 0, 0);
        render.color = new Color(render.color.r, render.color.b, render.color.g, cDown / countDown);

        if (cDown <= 0)
        {
            Destroy(gameObject);
        }
	}
}
