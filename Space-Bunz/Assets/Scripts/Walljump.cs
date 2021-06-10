using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walljump : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            other.attachedRigidbody.AddForce( new Vector2(-8, 4), ForceMode2D.Impulse);
        }
    }

}
