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

        
        moveLR = Input.GetAxisRaw("Horizontal") * player.MovementSpeed;
        jump = Input.GetAxisRaw("Vertical") * player.JumpForce;
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Rotate();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "WalljumpArea")
        {
            WallJump();
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
                rb.velocity = (new Vector2(0, player.JumpForce));
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
        groundCheck = Physics2D.Raycast(GameObject.Find("feet").transform.position, Vector2.down, 0.2f);

        if (groundCheck.collider != null && groundCheck.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("grounded!");
            isGrounded = true;
        }
    }

    private void WallJump()
    {
        if (movement != 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(player.WallForce * -movement, player.WallHeight);
        }
    }


}
