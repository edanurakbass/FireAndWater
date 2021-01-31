using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
     float inputDelay = 0.1f;
     float forwardVel = 12f;
     float rotateVel = 100f;
     public Animator animator;
     public bool isRunning;
     Quaternion targetRotation;
     Rigidbody rb;
     float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    private void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
            rb = GetComponent<Rigidbody>();
        else
            Debug.Log("the character needs a rb");

        forwardInput = turnInput = 0;

    }
     void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        
    }
    void Update()
    {
        GetInput();
        Turn();

        isRunning = false;
        if (forwardInput != 0 || turnInput != 0)
        {
            isRunning = true;
        }
        animator.SetBool("Run", isRunning);
    }
    private void FixedUpdate()
    {
        Run();
    }
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
           rb.velocity = transform.forward * forwardInput * forwardVel;
        }
        else
        {
           rb.velocity = Vector3.zero;
        }
    }
     void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
           
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);

        }
        transform.rotation = targetRotation;
    }


}
