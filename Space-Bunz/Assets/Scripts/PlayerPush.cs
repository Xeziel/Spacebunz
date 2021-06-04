using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush
{
    private Transform GrabDetect = GameObject.Find("Grab Detect").transform;
    private Transform BoxHolder = GameObject.Find("Box Holder").transform;
    private GameObject player = GameObject.Find("Player");
    private float rayDist;


    public PlayerPush(float raydist)
    {
        rayDist = raydist;
        UpdateCaller.OnUpdate += Update;
    }

    ~PlayerPush()
    {
        UpdateCaller.OnUpdate -= Update;
    }

    void Update()
    {
        
        RaycastHit2D grabCheck = Physics2D.Raycast(GrabDetect.position, Vector2.right * player.transform.localScale, rayDist);
        Debug.Log("Collided!!");
        if (grabCheck.collider != null && grabCheck.collider.tag == "Drag")
        {
            
            if (Input.GetKey(KeyCode.Space))
            {
                grabCheck.collider.gameObject.transform.parent = BoxHolder;
                grabCheck.collider.gameObject.transform.position = BoxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }

















}

