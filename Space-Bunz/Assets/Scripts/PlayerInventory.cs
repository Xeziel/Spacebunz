using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class contains all methods for what the inventory of the player can do
/// </summary>
public class PlayerInventory 
{
    private Button[] inventoryButtons;
    private GameObject[] inventory;

    public PlayerInventory()
    {
        inventory = new GameObject[4]; //the inventory array can hold 4 items
        inventoryButtons = new Button[4];

        inventoryButtons[0] = GameObject.FindGameObjectWithTag("Button0").GetComponent<Button>();
        inventoryButtons[1] = GameObject.FindGameObjectWithTag("Button1").GetComponent<Button>();
        inventoryButtons[2] = GameObject.FindGameObjectWithTag("Button2").GetComponent<Button>();
        inventoryButtons[3] = GameObject.FindGameObjectWithTag("Button3").GetComponent<Button>();
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

                //Update UI
                //each button has an image 'component' and we want to override that
                inventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                inventoryButtons[i].image.enabled = true;

                itemAdded = true;

                //put in inventory
                item.SetActive(false);
                Debug.Log("inventory op plaats 0 = " + inventory[0]);
                Debug.Log("inventory op plaats 1 = " + inventory[1]);
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
                //Update UI

                inventoryButtons[i].image.enabled = false;
                inventoryButtons[i].image.overrideSprite = null;
                break;
            }
        }
    }
}
