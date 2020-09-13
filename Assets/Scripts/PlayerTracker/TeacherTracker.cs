using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TeacherTracker : MonoBehaviourPun
{
    public GameObject headToChange;
    //public GameObject leftHandToChange;
    //public GameObject rightHandToChange;
    private GameObject head;
    //private GameObject leftHand;
    //private GameObject rightHand;

    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.Find("/PlayerManager/TeacherPlayer/HeadLocal");
        //leftHand = GameObject.Find("/PlayerManager/TeacherPlayer/HeadLocal/BodyLocal/Left");
        //rightHand = GameObject.Find("/PlayerManager/TeacherPlayer/HeadLocal/BodyLocal/Right");

    }

    // Update is called once per frame
    void Update()
    {
        if(headToChange == null)// || leftHandToChange== null || rightHandToChange== null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (headToChange.gameObject.GetPhotonView().IsMine)
            {
                headToChange.transform.position = head.transform.position;
                headToChange.transform.rotation = head.transform.rotation;
            }
            //if (leftHandToChange.gameObject.GetPhotonView().IsMine)
            //{
            //    leftHandToChange.transform.position = leftHand.transform.position;
            //    leftHandToChange.transform.rotation = leftHand.transform.rotation;
            //}
            //if (rightHandToChange.gameObject.GetPhotonView().IsMine)
            //{
            //    rightHandToChange.transform.position = rightHand.transform.position;
            //    rightHandToChange.transform.rotation = rightHand.transform.rotation;
            //}
        }
    }
}
