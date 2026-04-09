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

    public float crystalLimit = 0;
    public float sphereLimit = 0;

    public Slider sphereLimitSlider;
    public Slider crystalLimitSlider;

    // Start is called before the first frame update
    void Start()
    {
        spawnSphere = true;
        sphereLimit = 1;
        crystalLimit = 500;


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
            spawnCrystal = false;
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

    public void sphereChangeCheck()
    {
        sphereLimit = sphereLimitSlider.value;

    }

    public void crystalChangeCheck()
    {
        crystalLimit = crystalLimitSlider.value;

    }
}
