using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]
    float movementStrength = 1;
    [SerializeField]
    float maxSpeed = 10;

    [Header("Jump Settings")]
    [SerializeField]
    float jumpStrength = 1;
    [SerializeField]
    float groundCheckDistance = .1f;
    [SerializeField]
    LayerMask groundMask;

    [HideInInspector]
    public bool isDead;
    Vector3 movementDir;
    Rigidbody rb;
    bool isJumping;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ApplyForces();
    }

    void GetInput()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
        movementDir = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
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

        //Check if over max speed then set make velocity at max speed
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector3(maxSpeed, rb.velocity.y, rb.velocity.z);
        else if (rb.velocity.x < -maxSpeed)
            rb.velocity = new Vector3(-maxSpeed, rb.velocity.y, rb.velocity.z);

        if (rb.velocity.z > maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        else if (rb.velocity.z < -maxSpeed)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fogPlane")
        {
            isDead = true;
            this.GetComponent<Restart>().Die();
        }
    }
}
