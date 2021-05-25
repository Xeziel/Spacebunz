using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    private float movement;

    [SerializeField]
    Player player = new Player();

    // Update is called once per frame
    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && Mathf.Abs(this.player.rigidbody.velocity.y) < 0.001f)
        {
            this.player.rigidbody.AddForce(new Vector2(0, this.player.JumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0) * Time.fixedDeltaTime * this.player.MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
    }
}
