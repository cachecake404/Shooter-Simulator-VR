using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SoundObectCleanUp : MonoBehaviour
{
    private float timeToDestroy = 1f;
    private float totalTime = 0f;
    bool called = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        if(called==false && totalTime>=timeToDestroy)
        {
            if(this.gameObject.GetPhotonView().IsMine)
            {
                try
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
                catch
                {
                    print("Destoryed object!");
                }
            }
            //Destroy(this.gameObject);
            called = true;
        }
    }
}
