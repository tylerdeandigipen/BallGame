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


    BallMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = player.GetComponent<BallMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerMovement.isDead)
        {
            Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
