using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform target;

    private float xPosMin = -9.96f;
    private float xPosMax = 9.96f;
    private float yPosMin = 0f;
    private float yPosMax = 26.2f;
    

    private void FixedUpdate()
    {
        Vector3 targetpos = target.position;
        targetpos.y = Mathf.Clamp(target.position.y, yPosMin, yPosMax);
        targetpos.x = Mathf.Clamp(target.position.x, xPosMin, xPosMax);



        transform.position = new Vector3(targetpos.x, targetpos.y, -10);
    }
}
