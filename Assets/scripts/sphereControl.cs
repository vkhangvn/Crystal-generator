using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereControl : MonoBehaviour
{
    public int totalSphere = 0;
    public GameObject sphereManager;
    public bool spawnSphere;

    // Start is called before the first frame update
    void Start()
    {
        spawnSphere = true;
}

    // Update is called once per frame
    void Update()
    {
        if(totalSphere > 10)
        {
            spawnSphere = false;
        }
            
    }
    public void plus ()
    {
        totalSphere++;
    }
}
