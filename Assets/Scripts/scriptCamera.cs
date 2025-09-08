using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public Transform player;                 

    public float smoothSpeed = 0.125f;     //speed in which camera will lock on too object
    public Vector3 offset;      //public camera position setting on inspector

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
