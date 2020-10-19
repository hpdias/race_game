using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetPositon;
    public int rotX;
    public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offsetPositon;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;
        transform.position = player.position + offsetPositon;
        //transform.LookAt(player);
        transform.rotation = Quaternion.Euler(rotX,0,0);
    }
}
