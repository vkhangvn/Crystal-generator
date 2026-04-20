using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazy : MonoBehaviour


{
    public Vector3 destination = new Vector3(5, 5, 0);
    void Update()
    {

    transform.position += (destination - transform.position) * 0.1f;
    }
}