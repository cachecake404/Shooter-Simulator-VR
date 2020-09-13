using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public string SceneToLoad; // Type scene to load in the inspector
    private int isTeacher = 0;
    private string roomName = "";
    // Start is called before the first frame update
    void Start()
    {
        isTeacher = PlayerPrefs.GetInt("IsTeacher");
        roomName = PlayerPrefs.GetString("RoomName");
        print("OKAY I AM HERE NOW IS TEACHER IS "+ isTeacher.ToString());
        PhotonNetwork.AutomaticallySyncScene = true; // If master client loads a scene so should the children and this will sync it. 
        if (PhotonNetwork.IsConnected) // Check if we are connected to the network
        {
            if(isTeacher==0)
            {
                PhotonNetwork.JoinRoom(roomName);
            }
            else
            {
                createRoom();
            }
        }
        else
        {

            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings(); // Connets to the master photon server. This will now call OnConnectedToMaster because you are connected.
        }
    }

    public override void OnConnectedToMaster()
    {

        Debug.Log("Player have connected to master server!");
        if (isTeacher == 0)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        else
        {
            createRoom();
        }

    }


    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log(returnCode.ToString() + ": " + message);
        SceneManager.LoadScene("FailedStudent");
    }

    // Function to create a room
    void createRoom()
    {
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 }; // Options for your room
        PhotonNetwork.CreateRoom(roomName, roomOps); // Creating the room if it fails it will called the OnCreateRoomFailed if doesn't fail then goes OnJoinedRoom
    }

    // Lets stop here since creating a room failed and check why
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create room failed the reason is " + message);
        SceneManager.LoadScene("FailedTeacher");
    }

    // Now we are in the room so lets start the game
    public override void OnJoinedRoom()
    {
        Debug.Log("We are now in a room with others so let's start the game and load the common scene");
        StartGame();
    }

    // Starts the game with the scene to load
    void StartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.LoadLevel(SceneToLoad);

        }
    }

    // If we ever disconnect
    public override void OnDisconnected(DisconnectCause cause)
    {

        Debug.LogError("We disconnected!");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
