using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{


    private Vector3 targetpos;
    private float xPosMin;
    private float xPosMax;
    private float yPosMin;
    private float yPosMax;

    public Transform target;

    public float XPosMin { get; set; }
    public float XPosMax { get; set; }
    public float YPosMin { get; set; }
    public float YPosMax { get; set; }


    private void FixedUpdate()
    {
        targetpos = target.position;
        if (targetpos.x > 150 && targetpos.x < 215 && targetpos.y < 34)
        {
            xPosMin = 162;
            xPosMax = 210;
            yPosMin = -1;
            yPosMax = 32;
}

        Clamp();
        FollowPlayer();
    }

    private void Clamp()
    {
        targetpos = target.position;
        targetpos.y = Mathf.Clamp(target.position.y, yPosMin, yPosMax);
        targetpos.x = Mathf.Clamp(target.position.x, xPosMin, xPosMax);
    }

    private void FollowPlayer()
    {
        transform.position = new Vector3(targetpos.x, targetpos.y, -10);
    }
}
