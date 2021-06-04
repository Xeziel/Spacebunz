using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    

    void Start()
    {
        if (gameObject.tag == "Jumppad")
        {
            Debug.Log("Tagged");
            //JumpPad jumppad = new JumpPad();
            JumpPad jumpPad = gameObject.AddComponent<JumpPad>();
        } 
        //else if (gameObject.tag == "Key")
        //{
        //    Key key = gameObject.AddComponent<Key>();
        //}
        else if (gameObject.tag == "Door")
        {
            Door door = new Door("RedKey");
        }

    }
}
