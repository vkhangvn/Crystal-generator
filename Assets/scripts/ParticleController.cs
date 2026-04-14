using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public bool spawnParticle;
    public GameObject Crystal;
    public CrystalBurst CrystalBurst;
    public GameObject blueParticle;
    Vector3 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        CrystalBurst = Crystal.GetComponent<CrystalBurst>();
        spawnParticle = GetComponent<CrystalBurst>().spawnParticle;

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        if (CrystalBurst.spawnParticle)
        {
            CrystalBurst.spawnParticle = false;
        }
    }
}
