using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    public Vector3 destination = new Vector3(4, 0, 0);
    public AnimationCurve tweeningCurve;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(A123());
        StartCoroutine(Myco());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (destination - transform.position) * 0.1f;
    }

    IEnumerator Myco()
    {
        Vector3 squareStart = transform.position;
        float tweenDuration = 3f;


        for (float t = 0; t < 1f; t += Time.deltaTime / tweenDuration)
        {

            transform.position = Vector3.Lerp(squareStart, destination, t);
            yield return 0;
        }


       

        transform.position = destination;
    }

    IEnumerator A123()
    {
        Vector3 squareStart = transform.position;
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        Color startColor = mySprite.color;

        for (float t = 0f; t < 1f; t += Time.deltaTime)
        {

            transform.position = Vector3.LerpUnclamped(squareStart, destination,tweeningCurve.Evaluate(t));
            mySprite.color = Color.Lerp(startColor, Color.black, t);
            yield return 0;
        }
    }
}
