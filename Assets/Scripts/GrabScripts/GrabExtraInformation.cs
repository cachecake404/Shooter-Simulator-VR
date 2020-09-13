using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//using Photon.Realtime;

public class GrabExtraInformation : MonoBehaviourPun
{
    public bool isGrabbed = false;
    public string handsLeftOrRight = "None";
    public bool makeKinetmatic = false;
    public bool addConstraints = false;
    public bool makeTrigger = false;
    public bool makeAvoidable = false;
    private bool inContact = false;
    private bool madeChange = false;
    private GameObject playerObj;
    public void makeMine()
    {
        base.photonView.RequestOwnership();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (makeAvoidable == true && playerObj != null)
        {

            if (collision.gameObject.tag == "Ground")
            {
                print("I AM GOING TO FORCE COLLISIONS");
                Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), playerObj.GetComponent<Collider>(),false);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (makeAvoidable == true && playerObj != null)
        {
            if (collision.gameObject.tag == "Ground")
            {
                print("I AM GOING TO REMOVE COLLISIONS");
                Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), playerObj.GetComponent<Collider>());
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        string gameTag = collision.gameObject.tag;

        if (gameTag == "Hands" || gameTag == "HandsR")
        {
            if (gameTag == "Hands")
            {
                handsLeftOrRight = "Left";
            }
            else
            {
                handsLeftOrRight = "Right";
            }
            this.gameObject.GetComponent<PhotonView>().RequestOwnership();
            inContact = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        string gameTag = collision.gameObject.tag;
        if (gameTag == "Hands" || gameTag == "HandsR")
        {
            isGrabbed = false;

            handsLeftOrRight = "None";

            inContact = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("/PlayerManager/StudentPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        float Grab1 = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        float Grab2 = OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);
        bool grabbing = Grab2 >= 0.70f || Grab1 >= 0.70f;
        if (grabbing == true && inContact == true && madeChange == false)
        {
            isGrabbed = true;
            if (makeKinetmatic == true)
            {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            if (makeTrigger == true)
            {
                this.gameObject.GetComponent<Collider>().isTrigger = true;
            }
            if (addConstraints == true)
            {
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
            madeChange = true;
        }

        if ((grabbing == false || inContact == false) && madeChange == true)
        {
            madeChange = false;
            if (makeKinetmatic == true)
            {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
            if (addConstraints == true)
            {
                this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            if (makeTrigger == true)
            {
                this.gameObject.GetComponent<Collider>().isTrigger = false;
            }
        }
    }
}
