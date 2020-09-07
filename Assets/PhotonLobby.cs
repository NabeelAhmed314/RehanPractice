using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public GameObject nameInputPanel;
    public GameObject connectionsPanel;
    public GameObject lobbyPanel;


    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.NickName + " is Connected to server");
        lobbyPanel.SetActive(true);
        connectionsPanel.SetActive(false);
        nameInputPanel.SetActive(false);
    }
    public override void OnConnected()
    {
        Debug.Log("Connected to internet");
    }
    public void ConnectedToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            connectionsPanel.SetActive(true);
            nameInputPanel.SetActive(false);
        }

    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " Joined to " + PhotonNetwork.CurrentRoom);
        PhotonNetwork.LoadLevel("GamePlay");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " (new Player)  joined to " + PhotonNetwork.CurrentRoom);
    }
    private void CreateAndJoinRoom()
    {
        string room = "Room" + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 20;
        PhotonNetwork.CreateRoom(room, roomOptions);
    }

}
