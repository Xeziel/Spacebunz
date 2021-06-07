using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
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
}
