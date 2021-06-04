using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    private GameObject itemNeeded;
    public Door(string ItemNeeded)
    {    
        itemNeeded = GameObject.Find(ItemNeeded);
    }

    
}
