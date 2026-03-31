using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spheremovenent : MonoBehaviour
{
    public int sphereCounter;
    public Transform floorPrefab;
    public Transform PathmakerSpherePreFab;
    public GameObject PathmakerPreFab;
    public Vector3 destination;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

 
}
