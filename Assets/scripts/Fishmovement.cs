using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishmovement : MonoBehaviour
{
    public Vector3 destination;
    public float swimspeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f,1f), Random.Range(0f,1f),Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, swimspeed * Time.deltaTime);
        Debug.DrawLine(transform.position, destination, Color.cyan);

        if(Vector2.Distance(transform.position, destination) <1f)
        {
            destination = new Vector3(Random.Range(-40f, 40f), Random.Range(-40f, 40f), 0);

        }
    }

}
