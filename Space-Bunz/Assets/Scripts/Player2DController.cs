using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DController : MonoBehaviour
{
    private float moveLR, jump, movement;
    private Rigidbody2D rb;
    private float timer = 0f;

    [SerializeField]
    Player player = null;



    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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


    private void Move()
    {
        if (moveLR > 0 || moveLR < 0)
        {
            transform.position += new Vector3(moveLR, 0, 0) * Time.fixedDeltaTime;
        }
    }

    private void Jump()
    {
        if (timer > 0f)
        {
                timer -= Time.fixedDeltaTime;
        }

        if (jump > 0)
        {
            if (timer < 0.01f)
            {
                timer = 1f;
                rb.AddForce(new Vector2(0, player.JumpForce), ForceMode2D.Impulse);
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
