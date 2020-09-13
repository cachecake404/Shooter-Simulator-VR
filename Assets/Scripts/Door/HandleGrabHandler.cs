using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGrabHandler : OVRGrabbable
{
    public Transform handler;
    public GameObject MainDoor;
  

    // Start is called before the first frame update
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        MainDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        MainDoor.GetComponent<RequestOwner>().takeOwnerShip();
        
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);
        transform.position = handler.transform.position;
        transform.rotation = handler.transform.rotation;
        
        Rigidbody rbHandler = GetComponent<Rigidbody>();
        rbHandler.velocity = Vector3.zero;
        rbHandler.angularVelocity = Vector3.zero;

        MainDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    private void Update()
    {
        if(Vector3.Distance(handler.position,transform.position)>0.4f)
        {
            if(grabbedBy!=null)
            {
                grabbedBy.ForceRelease(this);
            }
        }
    }
}
