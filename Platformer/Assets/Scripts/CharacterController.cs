using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float runForce = 50f;
    public float maxRunSpeed = 6f;
    public float jumpForce = 20f;
    private Rigidbody body;
    public bool feetOnGround;
    private Collider collider;
    public float maxJumpForce = 40f;
    public bool jumpCheck;
    private int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        jumpCheck = false;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if(jumpCheck)
        {
            if(Input.GetKey(KeyCode.Space) && jumpCount < 20)
            {
                body.AddForce(Vector3.up * maxJumpForce, ForceMode.Force);
                jumpCount++;
            }
            else
            {
                jumpCount = 0;
                jumpCheck = false;
            }
        }
        // Checks if character is on the ground
        float castDistance = collider.bounds.extents.y + 0.1f;
        feetOnGround = Physics.Raycast(transform.position, Vector3.down, castDistance);

        //Add force based on user input along horizontal axis
        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);

        //Cap the run speed only if you're running, not if you're falling.
        if(Mathf.Abs(body.velocity.x) > maxRunSpeed)
        {
            float newX = maxRunSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && feetOnGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCheck = true;
        }

        if(Mathf.Abs(axis) < 0.1f)
        {
            float newX = body.velocity.x * (1f - Time.deltaTime * 3f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
        }
    }
}
