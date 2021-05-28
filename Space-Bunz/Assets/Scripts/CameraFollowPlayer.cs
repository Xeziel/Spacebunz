using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    

    private float xPosMin = -9.96f;
    private float xPosMax = 9.96f;
    private float yPosMin = 0f;
    private float yPosMax = 26.2f;

    //public CameraFollowPlayer(float minX, float maxX, float minY, float maxY)
   //{
    //    xPosMin = minX;
    //    xPosMax = maxX;
    //    yPosMin = minY;
    //    yPosMax = maxY;
    //}

    public Transform target;

    public float XPosMin { get; set; }
    public float XPosMax { get; set; }
    public float YPosMin { get; set; }
    public float YPosMax { get; set; }


    private void FixedUpdate()
    {
        Vector3 targetpos = target.position;
        targetpos.y = Mathf.Clamp(target.position.y, yPosMin, yPosMax);
        targetpos.x = Mathf.Clamp(target.position.x, xPosMin, xPosMax);
        transform.position = new Vector3(targetpos.x, targetpos.y, -10);
    }
}
