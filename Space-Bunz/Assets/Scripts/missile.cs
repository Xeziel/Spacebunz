using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    Speed speed = new Speed(Speed.Spd.normal);

    private void FixedUpdate()
    {
        if (transform.rotation == new Quaternion (0, -180, 0, 1))
        {
            transform.position += new Vector3((float)speed.MovementSpeed, 0, 0) * Time.fixedDeltaTime;
        }

        if (transform.rotation == new Quaternion (0, 0, 0, 1))
        {
            transform.position += new Vector3((float)speed.MovementSpeed * -2, 0, 0) * Time.fixedDeltaTime;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject.Find("Player").GetComponent<Player2DController>().healthBar.TakeDamage(HealthBar.Hitpoints.Low);
        }

        if (collision.gameObject.name == "box" || collision.gameObject.name == "mbox")
        {
            collision.gameObject.SetActive(false);
        }
            Destroy(gameObject);
    }
}
