using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.FilePathAttribute;

// INTRO TO PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you're up for a mind safari, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================
// put this script on a Sphere... it SHOULD move around, and drop a path of floor tiles behind it

public class Pathmaker : MonoBehaviour
{
    public int sphereCounter ;
    public GameObject crystalPrefab;
    public GameObject headPrefab;
    public GameObject PathmakerPreFab;
    public float moveSpeed = 100f;
    public sphereControl sphereControl;
    public int totalSphere;
    public int totalCrystal;
    public GameObject sphereManager;
    public bool noCrystalSpawn;
    public bool sphereTouching;
    public bool startGenerates;
    public float objectDetectRange = 0.2f;
    public int wormNumber;
    public float wormlength;
    public Button button;
    public GameObject labCamera;
    public GameObject microscopeCamera;
    public GameObject menu;
    public LayerMask ignoreLayer;
    public bool wallHit;
    public bool createHead;
    public bool headSpawned;
    public GameObject center;



    // STEP 2: ============================================================================================
    // translate the pseudocode below

    //	DECLARE CLASS MEMBER VARIABLES:
    //	Declare a private integer called counter that starts at 0; 		// counter will track how many floor tiles I've instantiated
    //	Declare a public Transform called floorPrefab, assign the prefab in inspector;
    //	Declare a public Transform called pathmakerSpherePrefab, assign the prefab in inspector; 		// you'll have to make a "pathmakerSphere" prefab later
    void Start()
    {
        sphereManager = GameObject.Find("sphereManager");
        sphereControl = sphereManager.GetComponent<sphereControl>();
        totalSphere = GetComponent<sphereControl>().totalSphere;

        totalCrystal = GetComponent<sphereControl>().totalCrystal;
        createHead = GetComponent<sphereControl>().createHead;



        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        wallHit = false;


    }

    public void TaskOnClick()
    {
        labCamera.SetActive(false);
        microscopeCamera.SetActive(true);
        menu.SetActive(false);
    }

    void Update()
    {






        if (microscopeCamera.activeInHierarchy == true)
        {
            
            Ray2D crystalRay = new Ray2D(transform.position, transform.up);
            Debug.DrawRay(crystalRay.origin, crystalRay.direction * objectDetectRange);
            if (Physics2D.Raycast(crystalRay.origin, crystalRay.direction * objectDetectRange, ~ignoreLayer) && wallHit == false)
            {
                RaycastHit2D objectHit = Physics2D.Raycast(crystalRay.origin, crystalRay.direction * objectDetectRange);
                Debug.Log(objectHit);
                wallHit = true;
      


            }

            
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);

            if (wallHit == false)
            {
            
                float randomNumber = Random.Range(0.0f, 1.0f);
                if (randomNumber < 0.25f)
                {
                    PathmakerPreFab.transform.Rotate(new Vector3(0, 0, 14));
                }
                else if (randomNumber < 0.5f && randomNumber >= 0.25f)
                {
                    PathmakerPreFab.transform.Rotate(new Vector3(0, 0, -10));
                }
                else if (randomNumber < 1f && randomNumber > 0.99f)
                {
                    if (sphereControl.spawnSphere == true)
                    {


                        GameObject newSphere = Object.Instantiate(PathmakerPreFab, new Vector3(Random.Range(-20f, 17f), Random.Range(13f, -14f), 0), Quaternion.identity);
                        sphereControl.plus();
                    }


                }
                else if (sphereCounter >= 50)
                {
                    Destroy(PathmakerPreFab);
                }
            }
            else if (wallHit)
            {
                PathmakerPreFab.transform.position = Vector2.MoveTowards(PathmakerPreFab.transform.position, center.transform.position, moveSpeed * Time.deltaTime);


                float distance = Vector3.Distance(PathmakerPreFab.transform.position, center.transform.position);
                float positiveDistance = Mathf.Abs(distance);

                if (positiveDistance < 15)
                {
                    Debug.Log("work");
                         wallHit = false;
                }
            }

            if (sphereControl.spawnCrystal == true)
            {
                {
                    GameObject newCrystal = Object.Instantiate(crystalPrefab, transform.position, Quaternion.identity);
                    sphereControl.crystal();

                }
            }

            else if(sphereControl.spawnCrystal == false)
            {
                createHead = true;
                spawnHead();
            }

            
        }
    }


 public void spawnHead()
    {
        if (createHead == true && headSpawned == false)
        {
            
            
            GameObject newHead = Object.Instantiate(headPrefab, transform.position, Quaternion.identity);
            headSpawned = true;
            createHead = false;
        }
    }
}










    //		If counter is less than 50, then:
    //			Generate a random number from 0.0f to 1.0f;
    //			If random number is less than 0.25f, then rotate myself 90 degrees;
    //				... Else if number is 0.25f-0.5f, then rotate myself -90 degrees;
    //				... Else if number is 0.99f-1.0f, then instantiate a pathmakerSpherePrefab clone at my current position;
    //			// end elseIf

//			Instantiate a floorPrefab clone at current position;
//			Move forward ("forward", as in, the direction I'm currently facing) by 5 units;
//			Increment counter;
//		Else:
//			Destroy my game object; 		// self destruct if I've made enough tiles already







// MORE STEPS BELOW!!!........

// STEP 3: =====================================================================================
// implement, test, and stabilize the system

//	IMPLEMENT AND TEST:
//	- save your scene! the code could potentially be infinite / exponential, and crash Unity
//	- put Pathmaker.cs on a sphere, configure all the prefabs in the Inspector, and test it to make sure it works
//	STABILIZE: 
//	- code it so that all the Pathmakers can only spawn a grand total of 500 tiles in the entire world; how would you do that?
//	- hint: declare a "public static int" and have each Pathmaker check this "globalTileCount", somewhere in your code? 
//      -  What is a 'static'?  Static???  Simply speak the password "static" to the instructor and knowledge will flow.
//	- Perhaps... if there already are enough tiles maybe the Pathmaker could Destroy my game object

// STEP 4: ======================================================================================
// tune your values...

// a. how long should a pathmaker live? etc.  (see: static  ---^)
// b. how would you tune the probabilities to generate lots of long hallways? does it... work?
// c. tweak all the probabilities that you want... what % chance is there for a pathmaker to make a pathmaker? is that too high or too low?



// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass

// - move the game camera to a position high in the world, and then point it down, so we can see your world get generated
// - CHANGE THE DEFAULT UNITY COLORS
// - add more detail to your original floorTile placeholder -- and let it randomly pick one of 3 different floorTile models, etc. so for example, it could randomly pick a "normal" floor tile, or a cactus, or a rock, or a skull
// - or... make large city tiles and create a city.  Set the camera low so and une the values so the city tiles get clustered tightly together.

//		- MODEL 3 DIFFERENT TILES IN BLENDER.  CREATE SOMETHING FROM THE DEEP DEPTHS OF YOUR MIND TO PROCEDURALLY GENERATE. 
//		- THESE TILES CAN BE BASED ON PAST MODELS YOU'VE MADE, OR NEW.  BUT THEY NEED TO BE UNIQUE TO THIS PROJECT AND CLEARLY TILE-ABLE.

//		- then, add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]


// EXTRA TASKS TO DO, IF YOU WANT / DARE: ===================================================

// AVOID SPAWNING A TILE IN THE SAME PLACE AS ANOTHER TILE  https://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html
// Check out the Physics.OverlapSphere functionality... 
//     If the collider is overlapping any others (the tile prefab has one), prevent a new tile from spawning and move forward one space. 

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore.  Throw that thing out!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast out from each floor tile (that'd be 4 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)