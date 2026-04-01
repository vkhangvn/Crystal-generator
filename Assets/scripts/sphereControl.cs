using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereControl : MonoBehaviour
{
    public int totalSphere = 0;
    public GameObject sphereManager;
    public bool spawnSphere;

    public int totalCrystal = 0;
    public bool spawnCrystal;

    // Start is called before the first frame update
    void Start()
    {
        spawnSphere = true;
        spawnCrystal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(totalSphere > 3)
        {
            spawnSphere = false;
        }
        if (totalCrystal > 30000)
        {
            spawnCrystal = false;
        }
    }
    public void plus()
    {
        totalSphere++;
    }

    public void crystal()
    {
        totalCrystal++;
    }
}
