using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private bool toTheRight;
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private float shootspeed;
    private float time;

    private void Awake()
    {
        time = shootspeed;
    }

    private void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if (time < 0.4)
        {
            gameObject.GetComponent<Animator>().SetBool("firing", true);
        }
        if (time < 0)
        {
            
            if (toTheRight)
            {
                Instantiate(rocket, new Vector3(transform.position.x + 2, transform.position.y, -1), Quaternion.Euler(0f, 180f, 0f));
            }
            else
            {
                Instantiate(rocket, new Vector3(transform.position.x + -2, transform.position.y, -1), Quaternion.Euler(0f, 0f, 0f));
            }
            gameObject.GetComponent<Animator>().SetBool("firing", false);
            time = shootspeed; 
        }
    }
}
