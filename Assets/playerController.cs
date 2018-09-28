using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

  
    CharacterController cc;
    public float moveSpeed = 7f;
    string state = "Movement";
    public float gravity = 0f;
    public float jumpVelocity = 0;
    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        if (state == "Movement") {
            Movement();
        }

    }

    void Movement() {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        Vector3 direction = new Vector3(x, 0, z).normalized;
        Vector3 velocity = direction * moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded) {

            jumpVelocity = jumpHeight;
        }

        if (cc.isGrounded) {
            gravity = 0;

        } else {
            gravity += 0.25f;
            gravity = Mathf.Clamp(gravity, 1f, 20f);

        }
        Vector3 gravityVector = -Vector3.up * gravity * Time.deltaTime;
        cc.Move(velocity + gravityVector);

        if (velocity.magnitude > 0) { 
        float yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, yAngle, 0);

    }
    }
}
