using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;

public class OnBulletHit : MonoBehaviourPunCallbacks
{
    float time = 0.0f;
    private void OnCollisionEnter(Collision collision)
    {
        PhotonNetwork.LeaveRoom();
        PlayerPrefs.SetFloat("TimeAlive", time);
        if (collision.gameObject.tag!="VictoryWall")
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("Victory");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
