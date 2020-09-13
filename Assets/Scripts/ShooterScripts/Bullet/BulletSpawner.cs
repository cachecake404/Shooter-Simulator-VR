using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BulletSpawner : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject obj = PhotonNetwork.Instantiate("Bullet", this.transform.position, this.transform.rotation);
            GameObject obj2 = PhotonNetwork.InstantiateSceneObject("BulletSound", this.transform.position, this.transform.rotation);
            BulletMovement b = obj.GetComponent<BulletMovement>();
            b.moveDirection = this.transform.forward;
            b.move = true;
        }
    }
}
