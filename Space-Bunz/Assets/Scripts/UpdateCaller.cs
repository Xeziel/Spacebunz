using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCaller : MonoBehaviour
{
    private static UpdateCaller instance = null;
    public static System.Action OnUpdate;
    public static System.Action OnOnTriggerEnter2D;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
            Destroy(this);
    }

    void Update()
    {
        if (OnUpdate != null)
            OnUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnOnTriggerEnter2D != null)
            OnOnTriggerEnter2D();
    }
}
