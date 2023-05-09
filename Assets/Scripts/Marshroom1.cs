using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marshroom1 : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    public GameObject focusPlayer;
    float miniDist = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in Players)
        {
            float d = Vector3.Distance(transform.position, player.transform.position);

            if (d < miniDist)
            {
                miniDist = d;
                focusPlayer = player;
            }
        }

        var targetRotation = Quaternion.LookRotation(focusPlayer.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 30 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            Destroy(gameObject);
        }
    }
}
