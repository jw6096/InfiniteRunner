using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject floor;
    public GameObject background;
    public GameObject[] platforms;
    public GameObject powerup;
    private Queue<GameObject> floorsToDelete = new Queue<GameObject>();
    private Queue<GameObject> backgroundsToDelete = new Queue<GameObject>();
    private Queue<GameObject> platformsToDelete = new Queue<GameObject>();
    public List<GameObject> startingFloors = new List<GameObject>();
    public List<GameObject> startingBackgrounds = new List<GameObject>();
    public int difficulty = 1;
    private int currentHoles = 0;
    public int backgroundsGenerated = 2;
    private int platformsGenerated = 4;
    private int floorsGenerated = 1;

    public void Start()
    {
        for (int i = 0; i < startingFloors.Count; i++)
        {
            floorsToDelete.Enqueue(startingFloors[i]);
        }
        for (int i = 0; i < startingBackgrounds.Count; i++)
        {
            backgroundsToDelete.Enqueue(startingBackgrounds[i]);
        }
    }

    public void GenerateFloor()
    {
        currentHoles = 0;
        for (int i = 0; i < 15; i++)
        {
            int spawnPlatform = Random.Range(difficulty, 15);
            if (spawnPlatform != 14 || currentHoles == difficulty)
            {
                GameObject newFloor = Instantiate(floor, new Vector3((1.6f * floorsGenerated) + 35.15f, -5, 0), new Quaternion(0, 0, 180, 0));
                floorsToDelete.Enqueue(newFloor);
            }
            else
            {
                currentHoles++;
                floorsToDelete.Enqueue(null);
            }
            floorsGenerated++;
        }
    }

    public void GenerateBackground()
    {
        GameObject newBackground = Instantiate(background, new Vector3((16 * backgroundsGenerated) + 11, -0.6f, 1), Quaternion.identity);
        backgroundsToDelete.Enqueue(newBackground);
        backgroundsGenerated++;
    }

    public void GeneratePlatforms()
    {
        for (int i = 0; i < 2; i++)
        {
            float randomY = Random.Range(-2.0f, 2.0f);
            int platformNum = Random.Range(0, 2);
            GameObject newPlatform = Instantiate(platforms[platformNum], new Vector3(8 * platformsGenerated, randomY, 0), Quaternion.identity);
            platformsToDelete.Enqueue(newPlatform);
            int hasPowerup = Random.Range(0, 100);
            if (hasPowerup <= 14)
            {
                Instantiate(powerup, new Vector3(8 * platformsGenerated, randomY + 0.6f, 0), Quaternion.identity);
            }
            platformsGenerated++;
        }
    }

    public void CleanUp()
    {
        for (int i = 0; i < 7; i++)
        {
            if (floorsToDelete.Peek() != null)
            {
                Destroy(floorsToDelete.Peek());
            }
            floorsToDelete.Dequeue();
        }
        Destroy(backgroundsToDelete.Peek());
        backgroundsToDelete.Dequeue();
        Destroy(platformsToDelete.Peek());
        platformsToDelete.Dequeue();
    }
}
