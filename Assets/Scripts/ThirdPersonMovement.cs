﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public AudioSource winM;
    public Text m_Text;
    public float speed = 6;
    private float wincondition = 0;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;

    //Jump Stuff
    Vector3 velocity;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundMask;
    //bool isGrounded;
    public float jumpHeight = 3;

    //Dash & Movement
    public Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {

        winM = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();

        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        Vector3 dir = new Vector3(h, 0, v).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //Jump
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Score.scoreCount += 1;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Coin");
            if (objs.Length == 0)
            {
                winM.Play();
                m_Text.gameObject.SetActive(true);
                //SceneManager.LoadScene(0);
            }
        }
    }

}
