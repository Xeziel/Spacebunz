using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush
{
    private Transform GrabDetect = GameObject.Find("Grab Detect").transform;
    private Transform BoxHolder = GameObject.Find("Box Holder").transform;
    private GameObject ThePlayer = GameObject.Find("Player");
    Vector3 temp;
    bool tempactive = false;
    private float rayDist;


    public PlayerPush(float raydist)
    {
        rayDist = raydist;
        UpdateCaller.OnUpdate += Update;
    }

    //Destructor: Dit voert hetgeen uit wanneer een 'object' niet meer nodig is.
    ~PlayerPush()
    {
        UpdateCaller.OnUpdate -= Update;
    }

    void Update()
    {
        
        RaycastHit2D grabCheck = Physics2D.Raycast(GrabDetect.position, Vector2.right * ThePlayer.transform.localScale, rayDist);
        if (grabCheck.collider != null && grabCheck.collider.tag == "Drag")
        {
            
            if (Input.GetKey(KeyCode.Space))
            {
                temp = grabCheck.collider.gameObject.transform.position;
                tempactive = true;
                grabCheck.collider.gameObject.transform.SetParent(BoxHolder, true);
                grabCheck.collider.gameObject.transform.position = BoxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                ThePlayer.GetComponent<Player2DController>().player.JumpForce = 1f;
            }
            else
            {
                grabCheck.collider.gameObject.transform.SetParent(null, true); // dit released hem (je hebt hem dan niet meer vast)
                //grabCheck.collider.gameObject.transform.position = BoxHolder.position;
                if (tempactive == true)
                {
                    grabCheck.collider.gameObject.transform.position = temp;
                    tempactive = false;
                }
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                ThePlayer.GetComponent<Player2DController>().player.JumpForce = 4f;
            }
        }
    }

















}

