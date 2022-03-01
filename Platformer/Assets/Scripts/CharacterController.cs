using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpImpulseForce = 20f;
    public float jumpSustainForce = 7.5f;
    public bool feetOnGround = false;
    public float maxHorizontalSpeed = 6f;
    private Animator animComp;
    private int jumpCounter = 0;
    public bool jumping = false;
    public bool forward = true;


    // Start is called before the first frame update
    void Start()
    {
        
        animComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Checks if character is on the ground
        Collider collider = GetComponent<Collider>();
        float castDistance = collider.bounds.extents.y + 0.1f;
        feetOnGround = Physics.Raycast(transform.position, Vector3.down, castDistance);

        if(feetOnGround && jumpCounter != 0)
        {
            jumpCounter = 0;
            jumping = false;
        }

        //Add force based on user input along horizontal axis
        float axis = Input.GetAxis("Horizontal");
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);
        if(axis > 0  && forward == false)
        {
            transform.Rotate(0f, 180f, 0f);
            forward = true;
        }
        else if(axis < 0 && forward == true)
        {
            transform.Rotate(0f, -180f, 0f);
            forward = false;
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && feetOnGround)
        {
            body.AddForce(Vector3.up * jumpImpulseForce, ForceMode.Impulse);
            jumpCounter++;
            jumping = true;
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            if(jumpCounter < 100)
            {
                body.AddForce(Vector3.up * jumpSustainForce, ForceMode.Force);
                jumpCounter++;
            }
        }

        // Check the velocity along x axis and clamp it if character is moving faster than max speed.
        float xVelocity = Mathf.Clamp(body.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);

        // If player isn't holding down a run button, start slowing down the character.
        if(Mathf.Abs(axis) < 0.1f)
        {
            xVelocity *= 0.9f;
        }

        body.velocity = new Vector3(xVelocity, body.velocity.y, body.velocity.z);

        animComp.SetFloat("Speed", body.velocity.magnitude);
        animComp.SetBool("Jumping", jumping);
    }
}
