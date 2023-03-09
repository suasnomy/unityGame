using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);
        //rb.AddForce(new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed);
        //if(Input.GetKeyDown("space")) 
        //{
        //  rb.velocity = new Vector3(0,5f,0);  
        //}
        //this prevent us from stop moving as soon as we jump.
        // the upper code with space key track dont have sensitivity of moving forward and falling when someone jumps
        if (Input.GetButtonDown("Jump") && isgrounded())
        {
            Jump();
        }
        //if (Input.GetKey("up"))
        //{
        //    rb.velocity = new Vector3(0, 0, 5f);
        //}

        //if (Input.GetKey("right"))
        //{
        //    rb.velocity = new Vector3(5f, 0, 0);
        //}

        //if (Input.GetKey("left"))
        //{
        //    rb.velocity = new Vector3(-5f, 0, 0);
        //}

        //if (Input.GetKey("down"))
        //{
        //    rb.velocity = new Vector3(0, 0, -5f);
        //}

       

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    //used to check weather our player reached the ground or not.
    // this is to check so that user will only be able to jump when ground is touched.

    bool isgrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    private void FixedUpdate()
    {
        
    }
}
