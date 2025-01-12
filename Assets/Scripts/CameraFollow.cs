using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player; 
    public Vector3 offset;  

    void Start()
    {
       
        if (offset == Vector3.zero)
        {
            offset = transform.position - Player.position;
        }
    }

    void LateUpdate()
    {
        Vector3 targetPos = Player.position + offset;

        targetPos.x = transform.position.x; 
        transform.position = targetPos;
    }
}
