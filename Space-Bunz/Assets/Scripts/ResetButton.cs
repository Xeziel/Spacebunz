using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{


    [SerializeField]
    private GameObject connectedBox;

    [SerializeField]
    private Vector3 resetPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        connectedBox.transform.position = resetPosition;
        if (connectedBox.activeSelf == false)
        {
            connectedBox.SetActive(true);
        }
    }
}
