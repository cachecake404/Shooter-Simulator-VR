using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MeshDisabler : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
