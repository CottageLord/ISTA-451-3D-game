using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float speed;
	public float jumpPower;
	public float gravity = 40f;
    public Rigidbody rb;
    public CharacterController controller;
    /*
    void Update() {
    	float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = Vector3.zero;
        if(controller.isGrounded) {
        	movement = new Vector3(moveHorizontal, 0f, moveVertical);
        	// convert move direction from local to world space
        	movement = transform.TransformDirection(movement);
        	movement *= speed;
        	if(Input.GetButtonDown("Jump")) {
	        	movement.y = jumpPower;
        	}
        }
        movement.y -= gravity * Time.deltaTime;

        controller.Move(movement * Time.deltaTime);
    }
	*/
    
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        // move on ground
        rb.velocity = new Vector3(moveHorizontal * speed, 
        	rb.velocity.y, moveVertical * speed);

        //transform.Rotation();

        if(Input.GetButtonDown("Jump")) {
        	rb.velocity = new Vector3(rb.velocity.x, 
        		jumpPower, rb.velocity.z);
        }
    }
}
