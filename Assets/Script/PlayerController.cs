using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float speed = 10f;
    public float runMultiplier = 1.5f;
    public float jumpForce = 5f;
    private bool isGrounded;
    public Animator animator;
    public float RotationSpeed = 250;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        animator.SetFloat("VelX", hor);
        animator.SetFloat("VelY", ver);


        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? speed * runMultiplier : speed;


        transform.Rotate(0, hor * Time.deltaTime * RotationSpeed, 0);


        if (hor != 0.0f || ver != 0.0f)
        {
            Vector3 dir = transform.forward * ver + transform.right * hor;
            rigidbody.MovePosition(transform.position + dir * currentSpeed * Time.deltaTime);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            animator.Play("Jump");

        }
    }


    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Ground"))
     {
           isGrounded = true;
       }
   }
}