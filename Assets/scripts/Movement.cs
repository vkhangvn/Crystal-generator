
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject moveSOund;
    public float speed = 10f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            moveSOund.SetActive(true);
        }
        if (Input.GetKey(KeyCode.S))

        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            moveSOund.SetActive(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            moveSOund.SetActive(true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            moveSOund.SetActive(true);
        }


        if (Input.GetKeyUp(KeyCode.W))
        {

            moveSOund.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.S))

        {

            moveSOund.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            moveSOund.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {

            moveSOund.SetActive(false);
        }

    }


}
