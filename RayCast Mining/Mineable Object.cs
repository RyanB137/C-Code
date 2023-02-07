using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineableObject : MonoBehaviour
{
    //variables for Health
    private Image healthBar;
    public int currentHealth;
    public int maxHealth = 100;

    //Bool To Check If Player Is Inside Collider
    public bool playerInRange;

    // Prefab For Instantiating A Dropped Object After Mined
    public GameObject Mineable //Change Name To Applicable

    public void Awake()
    {   //Sets The Current Health To What The Max Health Is On Game Start
        currentHealth = maxHealth;
    }

    public void Update()
    {       //Checks If Objects Health Is 0
        if (currentHealth <= 0)
        {   //If It Is, Destroy The Object And Instantiate The Prefab Variable
            Destroy(gameObject);
            Instantiate(treeLogsPrefab, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {   //Checks If The Player Is In Range
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {   //Checks If The Player Is In Range
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
