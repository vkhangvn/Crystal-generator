using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Myco());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Myco()
    {
        Debug.Log("1");
        yield return 0;
        yield return 1;
        yield return null;

        yield return new WaitForSeconds(1);
    }
}
