using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject platformGameObject;

    private bool canMovePlatform = false;
    private bool moveUp = false;
    private bool moveRight = false;
    private bool turnOn = false;

    private float platformSpeed = 3f;

    [SerializeField]
    private float maxPlatformPos = 4f;

    [SerializeField]
    private float minPlatformPos = -4f;

    private void Update()
    {
        if (canMovePlatform == true && platformGameObject.CompareTag("UpDownplatform"))
        {
            if (platformGameObject.transform.position.y > maxPlatformPos)
            {
                moveUp = false;
            }
            if (platformGameObject.transform.position.y < minPlatformPos)
            {
                moveUp = true;
            }

            PlatformMoveUp();
        }


        if (canMovePlatform == true && platformGameObject.CompareTag("LeftRightPlatform"))
        {
            if (platformGameObject.transform.position.x > maxPlatformPos)
            {
                moveRight = false;
            }
            if (platformGameObject.transform.position.x < minPlatformPos)
            {
                moveRight = true;
            }

            PlatformMoveRight();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PressurePlatePlatform"))
        {
            canMovePlatform = true;
        }
        if (gameObject.tag == "LeverPlatform" && turnOn == false)
        {
            turnOn = true;
            GetComponent<Animator>().SetBool("lever on", true); //lever is on
            canMovePlatform = true;
        }
        else if (gameObject.tag == "LeverPlatform" && turnOn == true)
        {
            turnOn = false;
            GetComponent<Animator>().SetBool("lever on", false); //lever is off
            canMovePlatform = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.CompareTag("PressurePlatePlatform"))
        {
            canMovePlatform = false;
        }
    }


    private void PlatformMoveUp()
    {
        if (moveUp)
        {
            platformGameObject.transform.position = new Vector3(platformGameObject.transform.position.x, platformGameObject.transform.position.y + platformSpeed * Time.deltaTime, -1);
        }
        else
            platformGameObject.transform.position = new Vector3(platformGameObject.transform.position.x, platformGameObject.transform.position.y - platformSpeed * Time.deltaTime, -1);
    }


    private void PlatformMoveRight()
    {
        if (moveRight)
        {
            platformGameObject.transform.position = new Vector3(platformGameObject.transform.position.x + platformSpeed * Time.deltaTime, platformGameObject.transform.position.y, -1);
        }
        else
            platformGameObject.transform.position = new Vector3(platformGameObject.transform.position.x - platformSpeed * Time.deltaTime, platformGameObject.transform.position.y, -1);
    }
}
