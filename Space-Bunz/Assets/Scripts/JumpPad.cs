using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    private float jumpForce = 10f;
    public float JumpForce { get; set; }

    //public JumpPad()
    //{
    //    jumpForce = 10f;
    //}

    //public JumpPad(float jumpForce)
    //{
    //    this.jumpForce = jumpForce;
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger");
        //other.attachedRigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }


}
