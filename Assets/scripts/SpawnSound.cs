using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSound : MonoBehaviour
{
    AudioSource CrystalSpawn;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CrystalSpawn = GetComponent<AudioSource>();
        CrystalSpawn.Play(0);
    }
}
