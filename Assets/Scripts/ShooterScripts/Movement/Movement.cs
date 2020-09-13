using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject cameraObj;
    public float distance = 2f;
    private Camera cam;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        cam = cameraObj.GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            Vector3 moveDirection = cam.transform.forward;
            moveDirection.y = 0;
            Vector3 finalposition = transform.position + (moveDirection * distance * Time.deltaTime);
            rb.MovePosition(finalposition);
        }
        if (Input.GetKey("s"))
        {
            Vector3 moveDirection = cam.transform.forward;
            moveDirection.y = 0;
            Vector3 finalposition = transform.position - (moveDirection * distance * Time.deltaTime);
            rb.MovePosition(finalposition);
        }
        if (Input.GetKey("a"))
        {
            Vector3 moveDirection = cam.transform.right;
            moveDirection.y = 0;
            Vector3 finalposition = transform.position - (moveDirection * distance * Time.deltaTime);
            rb.MovePosition(finalposition);
        }
        if (Input.GetKey("d"))
        {
            Vector3 moveDirection = cam.transform.right;
            moveDirection.y = 0;
            Vector3 finalposition = transform.position + (moveDirection * distance * Time.deltaTime);
            rb.MovePosition(finalposition);
        }
        rb.velocity = Vector3.zero;
        
    }
}
