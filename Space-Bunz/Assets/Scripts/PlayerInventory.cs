using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class contains all methods for what the inventory of the player can do
/// </summary>
public class PlayerInventory
{
    private GameObject[] inventory; 

    public PlayerInventory()
    {
        inventory = new GameObject[5]; //the inventory array can hold 5 items
    }

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        //Find the first open slot in the inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                itemAdded = true;

                //put in inventory
                //item.SendMessage("DoInteraction");
                item.SetActive(false);
                break; //you want to use break, cause else the loop continues and fills every slot with the same item
            }
        }
        
        //inventory full
        if (!itemAdded)
        {
            Debug.Log("inventory is full, item not picked up");
        }
    }

    public bool FindItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == item)
            {//we found the item 
                return true;
            }
        }
        //item not found
        return false;
    }


    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory [i] == item)
            {
                inventory[i] = null;
                break;
            }
        }
    }

}
