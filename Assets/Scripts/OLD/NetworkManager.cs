using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 10;
    public float waitSeconds = 2f;
    // instance
    public static NetworkManager instance;
    void Awake()
    {
        if (instance != null && instance != this)
            // The code that was here before broke, so now its grounded and can't do nothing.
            DoNothing();
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine("GoToMenu");
        }
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene("Menu");
    }
    void DoNothing()
    {
        // >:(
    }
    // Start is called before the first frame update
    void Start()
    {
        // connect to the master server
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("We've connected to the master server.");
        // seems this is now required in order to receive OnRoomListUpdate callbacks:
        PhotonNetwork.JoinLobby();
    }
    // attempts to create a room
    public void CreateRoom(string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.CreateRoom(roomName, options);
    }
    // attempts to join a room
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
    public override void OnDisconnected(DisconnectCause yes)
    {
        PhotonNetwork.LoadLevel("Menu");
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        GameManager.instance.alivePlayers--;
        GameUI.instance.UpdatePlayerInfoText();
        if (PhotonNetwork.IsMasterClient)
        {
            GameManager.instance.CheckWinCondition();
        }
    }

}
