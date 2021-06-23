using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool moveRight = false;
    private bool moveUp = false;
    private float platformSpeed = 3f;
    private float maxPlatformPos = 4f;


    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("LeftRightPlatform"))
        {
            if (transform.position.x > maxPlatformPos)
            {
                moveRight = false;
            }
            if (transform.position.x < -maxPlatformPos)
            {
                moveRight = true;
            }


            //this is for platforms that move left to right
            if (moveRight)
            {
                transform.position = new Vector3(transform.position.x + platformSpeed * Time.deltaTime, transform.position.y, -1);
            }
            else
                transform.position = new Vector3(transform.position.x - platformSpeed * Time.deltaTime, transform.position.y, -1);
        }

        if (gameObject.CompareTag("UpDownplatform"))
        {
            if (transform.position.y > maxPlatformPos)
            {
                moveUp = false;
            }
            if (transform.position.y < -maxPlatformPos)
            {
                moveUp = true;
            }

            //this is for platforms that move up and down
            if (moveUp)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + platformSpeed * Time.deltaTime, -1);
            }
            else
                transform.position = new Vector3(transform.position.x, transform.position.y - platformSpeed * Time.deltaTime, -1);
        }
    }
}