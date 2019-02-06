using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject[] generationsEasy;
    public GameObject[] generationsMedium;
    public GameObject[] generationsHard;
    private Queue<GameObject> generationsToDelete = new Queue<GameObject>();
    public List<GameObject> startingGenerations = new List<GameObject>();
    public int currentGenerations = 2;

    public void Start()
    {
        for (int i = 0; i < startingGenerations.Count; i++)
        {
            generationsToDelete.Enqueue(startingGenerations[i]);
        }
        for (int i = 0; i < 2; i++)
        {
            Generate();
        }
    }

    public void Generate()
    {
        if(GetComponent<CamTrack>().distance <= 150)
        {
            int spawnGeneration = Random.Range(0, generationsEasy.Length);
            GameObject newGeneration = Instantiate(generationsEasy[spawnGeneration], new Vector3((16 * currentGenerations) - 1, -0.75f, 0), Quaternion.identity);
            generationsToDelete.Enqueue(newGeneration);
        }
        else if (GetComponent<CamTrack>().distance <= 300)
        {
            int spawnGeneration = Random.Range(0, generationsMedium.Length);
            GameObject newGeneration = Instantiate(generationsMedium[spawnGeneration], new Vector3((16 * currentGenerations) - 1, -0.75f, 0), Quaternion.identity);
            generationsToDelete.Enqueue(newGeneration);
        }
        else
        {
            int spawnGeneration = Random.Range(0, generationsHard.Length);
            GameObject newGeneration = Instantiate(generationsHard[spawnGeneration], new Vector3((16 * currentGenerations) - 1, -0.75f, 0), Quaternion.identity);
            generationsToDelete.Enqueue(newGeneration);
        }
        currentGenerations++;
    }

    public void CleanUp()
    {
        Destroy(generationsToDelete.Peek());
        generationsToDelete.Dequeue();
    }
}
