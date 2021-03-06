using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    float yOffset;
    [SerializeField]
    float zOffset;
    [SerializeField]
    float smoothSpeed;
    [SerializeField]
    GameObject player;

    float timer;
    Quaternion startingCamRot;
    BallMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        startingCamRot = transform.rotation;        
        playerMovement = player.GetComponent<BallMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerMovement.isDead)
        {   
            if (playerMovement.startingCam)
            {
                Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z - (zOffset * 2f));
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.LookAt(player.transform.position);
                transform.position = smoothedPosition;
            }
            else
            {
                timer += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(transform.rotation, startingCamRot, smoothSpeed);
                Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }
        }
    }
}
