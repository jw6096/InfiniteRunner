using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject background;
    public GameObject[] platforms;
    private int backgroundsGenerated = 1;
    private int platformsGenerated = 2;

    public void GenerateBackground()
    {
        Instantiate(background, new Vector3((16 * backgroundsGenerated) + 11, 0, 1), Quaternion.identity);
        backgroundsGenerated++;
    }

    public void GeneratePlatforms()
    {
        float randomY = Random.Range(-2.0f, 2.0f);
        Debug.Log(randomY);
        int platformNum = Random.Range(0, 2);
        Instantiate(platforms[platformNum], new Vector3(11 * platformsGenerated, randomY, 0), Quaternion.identity);
        platformsGenerated++;
    }
}
