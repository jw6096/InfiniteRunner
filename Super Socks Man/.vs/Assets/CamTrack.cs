using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamTrack : MonoBehaviour {

	public float baseSpeed;
	public float maxSpeed;
	public float incRate;

	public Text distCount;

	private float speed;

	// Use this for initialization
	void Start () {
		speed = baseSpeed;
	}

	// Update is called once per frame
	void Update () {
		if (speed != maxSpeed)
		{
			if (speed < maxSpeed)
			{
				speed += incRate;
			}
			else
			{
				speed = maxSpeed;
			}
		}

		transform.position += new Vector3(speed, 0, -10) * Time.deltaTime;

		distCount.text = "Distance: " + transform.position.x.ToString("F2");
	}
}
