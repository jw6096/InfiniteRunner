using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamTrack : MonoBehaviour {

    public float baseSpeed;
    public float maxSpeed;
	public float incRate;	

	public Text distCount;
    public GameObject deathScreen;
    public bool gameOver = false;
    private float distanceSinceReset = 0;
    private float distanceAtLastReset = 0;

    private float speed;
    private BoxCollider2D[] targetZone;
    private Camera camera;

	// Use this for initialization
	void Start () {
        speed = baseSpeed;

        camera = gameObject.GetComponent<Camera>();

        targetZone = gameObject.GetComponents<BoxCollider2D>();

        targetZone[0].offset = new Vector2(-Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + 0.5f, 0);
        targetZone[0].size = new Vector2(1, Camera.main.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight, 0)).y * 2);

        targetZone[1].offset = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - 0.5f, 0);
        targetZone[1].size = new Vector2(1, Camera.main.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight, 0)).y * 2);

        targetZone[2].offset = new Vector2(0, -Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + 0.5f);
        targetZone[2].size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(camera.pixelWidth, 0, 0)).x * 2, 1);

        targetZone[3].offset = new Vector2(0, Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f);
        targetZone[3].size = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(camera.pixelWidth, 0, 0)).x * 2, 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
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
        }

		transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

		distCount.text = "Distance: " + transform.position.x.ToString("F2");
        distanceSinceReset = transform.position.x - distanceAtLastReset;

        if(distanceSinceReset >= 5)
        {
            GetComponent<PlatformGeneration>().GenerateBackground();
            GetComponent<PlatformGeneration>().GeneratePlatforms();
            distanceSinceReset = 0;
            distanceAtLastReset = transform.position.x;
        }
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log ("Collision: ");
		//Debug.Log (other);
		//Debug.Log (other.gameObject.GetComponent<SpriteRenderer> ().color);

		//other.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;

		//Debug.Log ("Death Collision");
		//other.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
        deathScreen.SetActive(true);
        speed = 0;
        gameOver = true;
	}
}
