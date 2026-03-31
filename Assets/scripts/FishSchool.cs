using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSchool : MonoBehaviour
{
    public GameObject fishPrefab;
    public List<GameObject> myfishList;
    public int maxFish = 100;

    void Start()
    {
        int fishCounter = 0;
        while (fishCounter < maxFish)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(10f, 10f), Random.Range(-5f, 5f), 0);

            GameObject newFish = Instantiate(fishPrefab, spawnPosition, Quaternion.Euler(0, 0, Random.Range(-180f, 180f)));

            myfishList.Add(newFish);

            fishCounter += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < myfishList.Count; i++)
            {
                myfishList[i].GetComponent<Fishmovement>().destination = Vector3.zero;
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < myfishList.Count; i++)
            {
                foreach(GameObject eachFish in myfishList)
                {
                    if(eachFish.transform.localScale.x<2f)
                    {
                        eachFish.transform.localScale *= Random.Range(0.5f, 1.5f);

                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach(GameObject eachFish in myfishList)
            {
                eachFish.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(1f, 1f));
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (GameObject eachFish in myfishList)
            {
                eachFish.GetComponent<Fishmovement>().swimspeed = Random.Range (-40f, 40f);
            }
        }
    }
}
    