using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerNameInput : MonoBehaviour
{
    public void playerNameInput(string playerName)
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player name cannot be empty");
            return;
        }
        PhotonNetwork.NickName = playerName;
        Debug.Log(playerName);
    } 
}
