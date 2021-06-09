using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //De volgende Fields zijn private, maar door de 'SerializeField' zijn ze toch zichtbaar in de inspector.
    //Omdat we in Unity werken, werken sommige dingen net wat anders daarom hebben we het op deze manier gedaan

    [SerializeField]
    private bool inventory; //if true, this object can be stored in inventory

    [SerializeField]
    private bool locked; //if true the object is locked

    [SerializeField]
    private GameObject itemNeeded; //item needed in order to interact with this item

    JumpPad jumpPad;
    

    void Start()
    {
        if (gameObject.tag == "Jumppad")
        {
            Debug.Log("Tagged");
            jumpPad = new JumpPad(10f);    
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "Jumppad")
        {
            jumpPad.OnTriggerStay2D(other);
        }
    }


    public bool Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

    public bool Locked
    {
        get { return locked; }
        set { locked = value; }
    }

    public GameObject ItemNeeded
    {
        get { return itemNeeded; }
        set { itemNeeded = value; }
    }
}
