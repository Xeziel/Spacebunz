using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject beam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (beam.GetComponent<Animator>().GetBool("turnedOff"))
        {
            beam.GetComponent<Animator>().SetBool("turnedOff", false);
            foreach(BoxCollider2D c in beam.GetComponents<BoxCollider2D>())
            {
                c.enabled = true;
            }          
        } 
        else
        {
            beam.GetComponent<Animator>().SetBool("turnedOff", true);
            foreach (BoxCollider2D c in beam.GetComponents<BoxCollider2D>())
            {
                c.enabled = false;
            }
            
        }
        
    }
}
