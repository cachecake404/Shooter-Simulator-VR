using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public bool move = false;
    private Rigidbody rb;
    private float distance = 50f;
    private float timeToDestory = 1f;
    public Vector3 moveDirection = Vector3.zero;


    private void OnCollisionEnter(Collision collision)
    {
        //GrabExtraInformation netInfo = collision.gameObject.GetComponent<GrabExtraInformation>();
        //if(netInfo!=null)
        //{
        //    netInfo.makeMine();
        //}
        print(collision.gameObject.name);
        Destroy(this.gameObject);
    }


    void Start()
    {
        Destroy(this.gameObject, timeToDestory);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(move==true)
        {     
            Vector3 finalposition = transform.position + (moveDirection * distance * Time.deltaTime);
            rb.MovePosition(finalposition);
        }
    }
}
