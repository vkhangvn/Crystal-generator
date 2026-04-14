using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBurst : MonoBehaviour
{

    Vector3 mousePosition;
    Transform clickObject;
    RaycastHit2D raycastHit2D;
    public bool spawnParticle;
    public GameObject blueParticle;
    public LayerMask hitLayer;
    public bool raycastOn;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction, ~hitLayer);
            if (raycastHit2D.collider != null)
            {
                Debug.Log("Debug.Log(\"Hit: \" + hit.collider.name)");
                GameObject newParticle = Object.Instantiate(blueParticle, transform.position, Quaternion.identity);
            }

            else
            {
                Destroy(GameObject.FindWithTag("crystalParticle"));

            }

        }
    }

}
