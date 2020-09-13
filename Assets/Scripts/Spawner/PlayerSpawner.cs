using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject student;
    public GameObject teacher;
    public List<GameObject> spawnPoints;
    public int totalPlayers = 0;

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print("Player Has Left!");
        PhotonNetwork.DestroyPlayerObjects(otherPlayer);
        totalPlayers -= 1;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        totalPlayers += 1;
    }

    void Start()
    {
        Debug.Log("Making your player!");
        if(PlayerPrefs.GetInt("IsTeacher")==0)
        {
            PhotonNetwork.Instantiate("StudentNetwork", transform.position, Quaternion.identity);
        }
        else
        {
            student.SetActive(false);
            teacher.SetActive(true);
            Cursor.visible = false;
            GameObject spawnerPoint = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
            teacher.transform.position = spawnerPoint.transform.position;
            PhotonNetwork.Instantiate("TeacherNetwork", spawnerPoint.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
