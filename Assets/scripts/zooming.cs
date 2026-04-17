using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zooming : MonoBehaviour
{
    public float minFOV = 49f;
    public float maxFOV = 79f;
    public float sensitivity = 2f;
    public float FOV;

    public GameObject zoominsound;
    public GameObject zoomoutsound;
    

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        FOV = Camera.main.fieldOfView;
        FOV += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        Camera.main.fieldOfView = FOV;

        if (Mathf.Approximately(FOV , FOV/ (FOV + sensitivity)))
        {
            zoomoutsound.SetActive(true);
        }

        if (scroll > 0)
        {
            StartCoroutine(zoomIn());
        }

        if (scroll < 0)
        {
            StartCoroutine(zoomOut());
        }

    }

    IEnumerator zoomIn()
    {
        zoomoutsound.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        zoomoutsound.SetActive(false);
    }

    IEnumerator zoomOut()
    {
        zoominsound.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        zoominsound.SetActive(false);
    }
}
