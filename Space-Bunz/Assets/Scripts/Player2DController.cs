using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    private RaycastHit2D groundCheck;
    private Rigidbody2D rb;
    public Speed player;
    private PlayerPush playerPush;
    public HealthBar healthBar;
    private bool isGrounded;
    private float moveLR, jump, movement;
    private bool isWallJumping = false;
    private bool isMovementOn;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = new Speed(Speed.Spd.normal, Speed.Jmp.high, Speed.Spd.normal, Speed.Jmp.high);
        playerPush = new PlayerPush(0.2f);
        healthBar = new HealthBar(3);
    }
    // Update is called once per frame
    void Update()
    {

        
        moveLR = Input.GetAxisRaw("Horizontal") * (float)player.MovementSpeed;
        jump = Input.GetAxisRaw("Vertical") * (float)player.JumpForce;
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (isMovementOn) 
        {
            Move();
        }
        Jump();
        Rotate();
        WallJump();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Wall")
        {
            Debug.Log("Walled");
            isWallJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movementOn();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Wall")
        {
            isWallJumping = false;
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
            CheckIfGrounded();
            if (isGrounded)
            {
                rb.velocity = new Vector2(0, (float)player.JumpForce);
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

    private void CheckIfGrounded()
    {
        groundCheck = Physics2D.Raycast(GameObject.Find("feet").transform.position, Vector2.down, 0.02f);

        if (groundCheck.collider != null && groundCheck.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("grounded!");
            isGrounded = true;
        }
    }

    private void WallJump()
    {
        if (movement != 0 && jump > 0 && isWallJumping)
        {
            Debug.Log("Walljumping!");
            rb.velocity = new Vector2((float)player.WallForce * -movement, (float)player.WallHeight);
            MovementOff();
        }
    }

    private void MovementOff()
    {
        isMovementOn = false;
    }

    private void movementOn()
    {
        isMovementOn = true;
    }


}
