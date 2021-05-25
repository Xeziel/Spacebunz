using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //public List<string> item;

    [SerializeField]
    internal Player2DController player2DController = null;

    private float movementSpeed = 5;

    public float MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            MovementSpeed = value;
        }
    }

    private float jumpForce = 4;

    public float JumpForce
    {
        get
        {
            return jumpForce;
        }
        set
        {
            JumpForce = value;
        }
    }

    internal Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //item = new List<string>();

        rigidbody = GetComponent<Rigidbody2D>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Collectables"))
    //    {

    //        string itemType = collision.gameObject.GetComponent<Collectables>().itemType;
    //        print("yay you have collected a:" + itemType);

    //        item.Add(itemType);

    //        Destroy(collision.gameObject);
    //    }
    //}
}

