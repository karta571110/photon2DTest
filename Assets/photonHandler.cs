using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class photonHandler : MonoBehaviour
{
    public PhotonButton photonB;
    public GameObject mainPlayer;
    private void Awake()
    {
        DontDestroyOnLoad(this.transform);

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void CreateNewRoom()
    {
        if (photonB.createRoomInput.text.Length >= 1)
            PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public void JoinOrCreateRoom()
    {

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);
        // PhotonNetwork.JoinRoom(joinRoomInput.text);
    }
    public void moveScene()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }

    private void OnJoinedRoom()
    {
        moveScene();
        //mLogic.disableMenuUI();
        Debug.Log("已連接到房間!");
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainGame")
        {
            spawnPlayer();
        }
    }

    private void spawnPlayer()
    {
        PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);
    }
}
