using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    private float moveLR, jump, movement;

    [SerializeField]
    Player player = null; 

    // Update is called once per frame
    void Update()
    {

        moveLR = Input.GetAxisRaw("Horizontal") * player.MovementSpeed;
        jump = Input.GetAxisRaw("Vertical") * player.JumpForce;
        movement = Input.GetAxisRaw("Horizontal");

        //if (Input.GetButtonDown("Jump") && Mathf.Abs(this.player.rigidbody.velocity.y) < 0.001f)
        //{
        //    this.player.rigidbody.AddForce(new Vector2(0, player.JumpForce), ForceMode2D.Impulse);
        //}
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(movement, 0) * Time.fixedDeltaTime * this.player.MovementSpeed;

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
        transform.position += new Vector3(moveLR, jump, 0) * Time.fixedDeltaTime;
    }
}
