using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    //Makes This Script Into A Static Variable
    public static ToolsManager instance;

    //Bool For If Any Tools Are Equipped
    public bool isToolEquipped;
    //Bool For If Specific Tool Is Equipped
    public bool axeEquipped;

    //Variable To Store The Axe GameObject
    public GameObject axe;

    private void Awake()
    {   //Creates A Reference To The Current Object That Can Be Used In Other Code
        instance = this;
    }

    private void Update()
    {
        //Equips and unequips Axe
        if (Input.GetKeyDown("1"))
        {
            axeEquipped = !axeEquipped;
        }

        //Turning Tool on 
        if (axeEquipped == true)
        {
            axe.SetActive(true);
            isToolEquipped = true;
            pickaxeEquipped = false;
        }
        else
        {
            axe.SetActive(false);
        }
    }
}
