using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMining : MonoBehaviour
{
    //Variable for LayerMask For Everything But The Player
    [SerializeField] private LayerMask collisionMask;

    //Variable For Player Camera
    private Camera cam;

    private void Start()
    {   //Sets The Camera Variable To Be The Main Camera
        cam = Camera.main;
    }
    private void Update()
    {   //Creates A Ray Based On The MousePosition Which Is Frozen In Middle Of Screen.
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //Gets The Info On What The Ray Is Hitting
        RaycastHit hit;
        //Checks If The Ray Has Hit Something + Checks If The Hit Object Has The Layer Mineable
        if (Physics.Raycast(ray, out hit, collisionMask) && hit.collider.gameObject.layer == LayerMask.NameToLayer("Mineable"))
        {   //Checks if Mouse Was Clicked
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {   // Gives The Name Of The Object Hit
                Debug.Log(hit.transform);
                //Checks If The Object Has The specified Tag + Checks If The Axe Tool Is Equipped (Refers To ToolsManager Script)
                if (hit.collider.CompareTag("Tree") && ToolsManager.instance.axeEquipped == true)
                {   //creates a variable for the Mineable Object Script Containing Object Health ("Tree")
                    //Checks if the hit collider has The Mineable Object Script Attatched ("Tree")
                    //Makes Mineable Object Script Variable equal to the specific Object You Clicked ("Tree")
                    Tree tree = hit.collider.gameObject.GetComponent<Tree>();
                    //Runs The Mine Method On The Specific Object You Clicked
                    MineTree(tree);
                }
            }
        }
    }
    //Method For Taking Away Object Health From The Mineable Object Variable
    public void MineTree(Tree tree)
    {   //Checks If Player Is In Range (Refers to Mineable Object Script)
        if (tree.playerInRange == true)
        {   //Takes 10 Health Away From Object Every Click (Refers to Mineable Object Script)
            tree.currentHealth -= 10;
        }
    }
   
}
