using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerCC : MonoBehaviour
{
    private Vector3 moveM;
    private Vector3 lastM;
    public float moveSpeed = 8;
    public float jumpForce = 8;
    private float gravity = 25;
    private float verticalVelocity;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveM = Vector3.zero;
        moveM.x = Input.GetAxisRaw("Horizontal");
        moveM.z = Input.GetAxisRaw("Vertical");


        if (controller.isGrounded)
        {
            verticalVelocity = -1;

            if (Input.GetButton("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            moveM = lastM;
        }

        moveM.y = 0;
        moveM.Normalize();
        moveM *= moveSpeed;
        moveM.y = verticalVelocity;

        controller.Move(moveM * Time.deltaTime);
        lastM = moveM;
    }

    private void Move()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //moveM.x = Input.GetKey(KeyCode.RightArrow);
        //moveM = Vector3.zero;
        //moveM.x = Input.GetAxisRaw("Horizontal");

        //if (controller.isGrounded)
        //{
        //    verticalVelocity = -1;

        //    if (Input.GetButtonDown("Jump"))
        //    {
        //        verticalVelocity = jumpForce;
        //    }
        //}
        //else
        //{
        //    verticalVelocity -= gravity * Time.deltaTime;
        //    moveM = lastM;
        //}

        //moveM.y = 0;
        //moveM.Normalize();
        //moveM *= moveSpeed;
        //moveM.y = verticalVelocity;

        //controller.Move(moveM * Time.deltaTime);
        //lastM = moveM;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
            Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
    }
}
