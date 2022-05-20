using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    Vector3 currentVelocity;
    [SerializeField]
    float movementStrength = 1;
    [SerializeField]
    float maxMovementSpeed = 10;
    [SerializeField]
    float maxVelocity = 10;

    [Header("Jump Settings")]
    [SerializeField]
    float jumpStrength = 1;
    [SerializeField]
    float groundCheckDistance = .1f;
    [SerializeField]
    LayerMask groundMask;

    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public bool startingCam;
    [HideInInspector]
    bool wonLevel = false;
    [SerializeField]
    Vector3 movementDir;
    Rigidbody rb;
    bool isJumping;
    bool isGrounded;
    ScoreManager scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreManager>();
        startingCam = true;
        rb = this.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (!wonLevel && !isDead)
        {
            GetInput();
            ApplyForces();
        }
    }

    void GetInput()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
        movementDir = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Mathf.Clamp(Input.GetAxisRaw("Vertical"), 0, 1));
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }
    }

    void ApplyForces()
    {
        rb.AddForce(movementDir * movementStrength);
        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpStrength);
            isJumping = false;
        }

        Vector3 hvel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (hvel.magnitude > maxVelocity)
        {
            hvel = hvel.normalized * maxVelocity;
            rb.velocity = new Vector3(hvel.x, rb.velocity.y, hvel.z);
        }

        
        currentVelocity = rb.velocity;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!wonLevel && !isDead)
        {
            if (other.gameObject.tag == "fogPlane")
            {
                isDead = true;
                this.GetComponent<Restart>().Die();
            }
            if (other.gameObject.tag == "levelStart")
            {
                startingCam = false;
            }
            if (other.gameObject.tag == "collectable")
            {
                scoreCounter.collectablesGot += 1;
                other.gameObject.GetComponent<Pickup>().collect();
            }
            if (other.gameObject.tag == "finishZone")
            {
                isDead = true;
                wonLevel = true;
            }
        }
    }
}


/*
//Check if over max speed then set make velocity at max speed
if (rb.velocity.x > maxVelocity)
    rb.velocity = new Vector3(maxVelocity, rb.velocity.y, rb.velocity.z);
else if (rb.velocity.x < -maxVelocity)
    rb.velocity = new Vector3(-maxVelocity, rb.velocity.y, rb.velocity.z);
if (rb.velocity.z > maxVelocity)
{
    Debug.Log("gaeming");
    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxVelocity);
}
else if (rb.velocity.z < -maxVelocity)
    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxVelocity);

//check if over max movespeed if not then addforce
if (rb.velocity.x < maxMovementSpeed)
    rb.AddForce(new Vector3(movementDir.x * movementStrength, 0, 0));
else if (rb.velocity.x > -maxMovementSpeed)
    rb.AddForce(new Vector3(-movementDir.x * movementStrength, 0, 0));

if (rb.velocity.z < maxMovementSpeed)
    rb.AddForce(new Vector3(0, 0, movementDir.z * movementStrength));
else if (rb.velocity.z > -maxMovementSpeed)
    rb.AddForce(new Vector3(0, 0, -movementDir.z * movementStrength));
*/
