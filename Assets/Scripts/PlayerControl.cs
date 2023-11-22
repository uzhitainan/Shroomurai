using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float dashSpeed;
    public float dashInterval;
    private float dashTime;
    public float dashDuration;
    Vector3 moveP;
    Vector3 dashP;
    private bool isGround;
    //private bool isJump;
    public bool doubleJump = true;
    //private bool wallJump1;
    //private bool wallJump2;
    private bool isDash;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isDash = false;
        dashInterval = 0;
        //wallJump1 = false;
        //wallJump2 = false;
    }

    void Update()
    {
        moveMent();
        jumpControl();
    }


    private void moveMent()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dashInterval -= Time.deltaTime;
        Vector3 moveDir = new Vector3(h, 0, v) * moveSpeed;
        Vector3 moveDirD = new Vector3(h, 0, v) * dashSpeed;
        moveP = moveDir * moveSpeed * Time.deltaTime;
        dashP = moveDirD * dashSpeed * Time.deltaTime;
        rb.AddForce(moveP);

        if (!isDash)
        {
            if (Input.GetButtonDown("Dash") && dashInterval <= 0)
            {
                Debug.Log("go");
                isDash = true;
                dashP = transform.forward;
                dashP.y = 0f;
                dashInterval = 3;
            }
        }
        else
        {
            if(dashTime <= 0)
            {
                isDash = false;
                dashTime = dashDuration;
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.velocity = dashP * dashTime * dashSpeed;
            }
        }

        if (moveP.magnitude > 0.1f)
        {

            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
    }

    private void jumpControl()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround == true)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGround = false;
                moveSpeed = 20;
            }
            //else if (doubleJump && !isGround)
            //{
            //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //    doubleJump = false;
            //}
            //else if (wallJump1 && !isGround)
            //{
            //    Debug.Log("left");
            //    rb.AddForce(Vector3.left * 12, ForceMode.Impulse);
            //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //}
            //else if (wallJump2 && !isGround)
            //{
            //    Debug.Log("right");
            //    rb.AddForce(Vector3.right * 12, ForceMode.Impulse);
            //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //}
        }
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "ground")
        {
            Debug.Log("hi");
            isGround = true;
            doubleJump = true;
            rb.velocity = Vector3.zero;
            moveSpeed = 50;
        }
    }

    //private void OnCollisionStay(Collision Other)
    //{
    //    //ContactPoint contact = Other.contacts[0];
    //    //Debug.DrawRay(contact.point, contact.normal, Color.red, 1.25f);
    //    if (Other.gameObject.tag == "Wall")
    //    {
    //        Debug.Log("harder");
    //        wallJump1 = true;
    //        doubleJump = false;
    //        Physics.gravity = new Vector3(0, -10f, 0);
    //    }
        
    //    if(Other.gameObject.tag == "Wall2")
    //    {
    //        wallJump2 = true;
    //        doubleJump = false;
    //        Physics.gravity = new Vector3(0, -10f, 0);
    //    }
    //}

    //private void OnCollisionExit(Collision Exit)
    //{
    //    if (Exit.gameObject.tag == "Wall")
    //    {
    //        Debug.Log("Out");
    //        wallJump1 = false;
    //        Physics.gravity = new Vector3(0, -50f, 0);
    //    }

    //    if (Exit.gameObject.tag == "Wall2")
    //    {
    //        Debug.Log("Out");
    //        wallJump2 = false;
    //        Physics.gravity = new Vector3(0, -50f, 0);
    //    }
    //}

}
