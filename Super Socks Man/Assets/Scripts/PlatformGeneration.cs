using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject floor;
    public GameObject background;
    public GameObject[] platforms;
    private List<GameObject> floorsToDelete = new List<GameObject>();
    private List<GameObject> backgroundsToDelete = new List<GameObject>();
    private List<GameObject> platformsToDelete = new List<GameObject>();
    public int difficulty = 1;
    private int currentHoles = 0;
    private int backgroundsGenerated = 1;
    private int platformsGenerated = 2;
    private int floorsGenerated = 1;

    public void GenerateFloor()
    {
        currentHoles = 0;
        for (int i = 0; i < 15; i++)
        {
            int spawnPlatform = Random.Range(difficulty, 15);
            if (spawnPlatform != 14 || currentHoles == difficulty)
            {
                GameObject newFloor = Instantiate(floor, new Vector3((1.6f * floorsGenerated) + 19.15f, -5, 0), new Quaternion(0, 0, 180, 0));
                floorsToDelete.Add(newFloor);
            }
            else
            {
                currentHoles++;
            }
            floorsGenerated++;
        }
    }

    public void GenerateBackground()
    {
        GameObject newBackground = Instantiate(background, new Vector3((16 * backgroundsGenerated) + 11, 0, 1), Quaternion.identity);
        backgroundsToDelete.Add(newBackground);
        backgroundsGenerated++;
    }

    public void GeneratePlatforms()
    {
        float randomY = Random.Range(-2.0f, 2.0f);
        int platformNum = Random.Range(0, 2);
        GameObject newPlatform = Instantiate(platforms[platformNum], new Vector3(11 * platformsGenerated, randomY, 0), Quaternion.identity);
        platformsToDelete.Add(newPlatform);
        platformsGenerated++;
    }

    public void CleanUp()
    {
        for (int i = 0; i < 14; i++)
        {
            Destroy(floorsToDelete[i]);
        }
        Destroy(backgroundsToDelete[0]);
        Destroy(platformsToDelete[0]);
    }
}
