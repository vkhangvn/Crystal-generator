using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassRandom : MonoBehaviour
{
    public GameObject grassBlade;
    public int grassCounterMax = 1000;

    // Start is called before the first frame update
    void Start()
    {
        int grassCounter = 0;
        while (grassCounter < grassCounterMax) 
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-40f, 40f), Random.Range(-40, 40));

            GameObject newGrass = Instantiate(grassBlade, spawnPosition, Quaternion.Euler(0, 0, Random.Range(-180f, 180f)));

            grassCounter += 1;
        }
    }
}
