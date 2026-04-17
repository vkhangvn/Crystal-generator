using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sphereControl : MonoBehaviour
{
    public int totalSphere = 0;
    public GameObject sphereManager;
    public bool spawnSphere;

    public int totalCrystal = 0;
    public bool spawnCrystal;
    public GameObject microsopeCamera;

    public float crystalLimit;
    public float sphereLimit;

    public Slider sphereLimitSlider;
    public Slider crystalLimitSlider;
    public Slider colorSlider;

    public float numberOfColor;
    public bool createHead;

    public float moveSpeed;
    public GameObject PathMakerSphere;
    public Pathmaker Pathmaker;

    public GameObject turningSound1;
    public GameObject turningSound2;
    public GameObject turningSound3;


    // Start is called before the first frame update
    void Start()
    {
        spawnSphere = true;
        sphereLimit = 1;
        crystalLimit = 500;
        numberOfColor = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (microsopeCamera.activeInHierarchy)
        {
            spawnCrystal = true;
        }
        if (totalSphere >= sphereLimit)
        {
            spawnSphere = false;
        }
        if (totalCrystal > crystalLimit)
        {
            createHead = true;
            
        }
    }
    public void plus()
    {
        totalSphere++;
    }

    public void crystal()
    {
        totalCrystal++;
    }

    public void setSpherelLimit()
    {
        sphereLimitSlider.onValueChanged.AddListener(delegate { sphereChangeCheck(); });
        
    }

    public void setCrystalLimit()
    {
        crystalLimitSlider.onValueChanged.AddListener(delegate { crystalChangeCheck(); });

    }

    public void setcolorLimit()
    {
        colorSlider.onValueChanged.AddListener(delegate { colorChangeCheck(); });

    }

    public void sphereChangeCheck()
    {
        sphereLimit = sphereLimitSlider.value;
        StartCoroutine(Turn1());
    }

    public void crystalChangeCheck()
    {
        crystalLimit = crystalLimitSlider.value;
        StartCoroutine(Turn2());
    }

    public void colorChangeCheck()
    {
        numberOfColor = colorSlider.value;
        StartCoroutine(Turn3());
    }

    IEnumerator Turn1()
    {
        turningSound1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        turningSound1.SetActive(false);
    }

    IEnumerator Turn2()
    {
        turningSound2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        turningSound2.SetActive(false);
    }

    IEnumerator Turn3()
    {
        turningSound3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        turningSound3.SetActive(false);
    }
}
