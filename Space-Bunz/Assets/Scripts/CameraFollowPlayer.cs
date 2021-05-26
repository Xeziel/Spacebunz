using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public Transform target;
    

    private void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y, -10);
    }
}
