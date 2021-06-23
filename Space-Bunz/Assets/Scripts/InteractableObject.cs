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

    [SerializeField]
    private GameObject itemNeeded2;

    [SerializeField]
    private float jumpforce;
    [SerializeField]
    private float angle;

    private JumpPad jumpPad;
    private Spike spikes;
    private FlameJet fire;
    

    private void Start()
    {
        if (gameObject.tag == "Jumppad")
        {
            Debug.Log("Tagged");
            jumpPad = new JumpPad(jumpforce, angle);    
        }
        
        if(gameObject.tag == "Spike")
        {
            Debug.Log("Spiked!");
            spikes = new Spike(Spike.Dmg.low);

        }
        if (gameObject.tag == "fireboi")
        {
            fire = new FlameJet(5, 5, gameObject.GetComponent<Animator>(), gameObject.GetComponent<BoxCollider2D>());
            Debug.Log("Fireboi made!");
        } 
        else
        {
            Debug.Log("Uhoh, no fire!");
        }

    }

    private void FixedUpdate()
    {
        if (gameObject.tag == "fireboi")
        {
            fire.Update();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.tag == "Jumppad")
        {
            jumpPad.OnTriggerStay2D(other);
        }

        if (this.gameObject.tag == "Spike")
        {
            spikes.OnTriggerEnter2D(other);
        }

        if (this.gameObject.tag == "fireboi")
        {
            fire.OnTriggerEnter2D(other);
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

    public GameObject ItemNeeded2
    {
        get { return itemNeeded2; }
        set { itemNeeded2 = value; }
    }
}
