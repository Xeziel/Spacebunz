using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    private float moveLR, jump, movement;
    private Rigidbody2D rb;
    private Speed player;
    private bool isGrounded;
    private PlayerPush playerPush;
    private HealthBar healthbar;
    //private PlayerInventory playerInventory;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = new Speed(5, 4);
        playerPush = new PlayerPush(0.2f);
        healthbar = new HealthBar(3);
        

        //playerInventory = new PlayerInventory(5);
    }
    // Update is called once per frame
    void Update()
    {

        moveLR = Input.GetAxisRaw("Horizontal") * player.MovementSpeed;
        jump = Input.GetAxisRaw("Vertical") * player.JumpForce;
        movement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && healthbar.CurrentHealth > 0)
        {
            healthbar.TakeDamage(1);
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Rotate();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Ground")
        {
            isGrounded = true;
        }
    }


    private void Move()
    {
        if (moveLR > 0 || moveLR < 0)
        {
            transform.position += new Vector3(moveLR, 0, 0) * Time.fixedDeltaTime;
        }
    }

    private void Jump()
    {
        if (jump > 0)
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0, player.JumpForce), ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
    }

    private void Rotate()
    {
        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }
    }
}
