using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes care of interacting with objects
/// </summary>
public class PlayerInteract : MonoBehaviour
{
    private GameObject currentInterObj = null;
    private InteractableObject currentInterobjScript = null;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = new PlayerInventory();
    }

    private void Update()
    {
        if (currentInterObj)
        {
            //check to see if this object is to be stored in inventory
            if (currentInterobjScript.Inventory)
            {
                playerInventory.AddItem(currentInterObj);
            }

            //check to see if the object is locked
            if (currentInterobjScript.Locked)
            {
                if (currentInterobjScript.ItemNeeded != null && currentInterobjScript.ItemNeeded2 == null) //so only 1 item is needed
                {
                    //check to see if we have the object needed to unlock, and search our inventory for the item needed - if found unlock object
                    if (playerInventory.FindItem(currentInterobjScript.ItemNeeded) && Input.GetKeyDown(KeyCode.E))
                    {
                        //we found the item needed
                        currentInterobjScript.Locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");

                        //door opens (disappears)
                        currentInterObj.SetActive(false);
                        playerInventory.RemoveItem(currentInterobjScript.ItemNeeded); //removes item we needed/key from inventory
                    }
                }
                if (currentInterobjScript.ItemNeeded != null && currentInterobjScript.ItemNeeded2 != null) // so 2 items needed
                {
                    if (playerInventory.FindItem(currentInterobjScript.ItemNeeded) && playerInventory.FindItem(currentInterobjScript.ItemNeeded2) && Input.GetKeyDown(KeyCode.E))
                    {
                        //we found the item needed
                        currentInterobjScript.Locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");

                        //door opens (disappears)
                        currentInterObj.SetActive(false);
                        playerInventory.RemoveItem(currentInterobjScript.ItemNeeded, currentInterobjScript.ItemNeeded2); //removes item we needed/key from inventory
                    }
                }
            }
            else
                Debug.Log("geen locked door");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractableObject"))
        {
            currentInterObj = collision.gameObject;
            currentInterobjScript = currentInterObj.GetComponent<InteractableObject>(); // getting the InteractableObject script and 
            //setting it to the 'currentInterObjScript' variable
            //getting all the information of the currentInterObj that can be found in the InteractableObject script
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("InteractableObject"))
        {
            if (collision.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}
