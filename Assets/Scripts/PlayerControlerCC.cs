using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerCC : MonoBehaviour
{
    public float moveSpeed;
    public float jumpH;
    public float wallJumpF;
    public float gravity = 9.81f;
    private float velocityY;

    Vector3 moveP;
    private Vector3 wallNormal;

    private bool doubleJ;
    private bool wallJ;
    private bool dash;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("controller is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(h, 0, 0);
        moveP = dir * moveSpeed;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocityY = jumpH;
                doubleJ = true;
                moveP.y = 0f;
            }
        }
        else
        {
            velocityY -= gravity;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (wallJ)
                {
                    velocityY = jumpH;
                    moveP = wallNormal * wallJumpF * Time.deltaTime;
                    doubleJ = false;
                    wallJ = false;
                }
                else if (doubleJ)
                {
                    moveP.y = 0f;
                    velocityY += jumpH;
                    doubleJ = false;
                }
            }
        }


        moveP.y = velocityY;

        controller.Move(moveP * Time.deltaTime);


        if (moveP.magnitude > 0.1f)
        {

            float faceAngle = Mathf.Atan2(0, h) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 8f * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!controller.isGrounded && hit.collider.CompareTag("Wall"))
        {
            wallNormal = hit.normal;
            Debug.DrawLine(hit.point, hit.normal + hit.point, Color.blue);
        }

        if (hit.collider.CompareTag("ground"))
        {
            wallJ = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
