﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RequestOwner : MonoBehaviourPun
{
    public void takeOwnerShip()
    {
        base.photonView.RequestOwnership();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
