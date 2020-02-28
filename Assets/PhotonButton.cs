using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButton : MonoBehaviour
{
    public MenuLogic mLogic;
    public photonHandler pHandler;

    public InputField createRoomInput, joinRoomInput;
    /// <summary>
    /// 創建房間
    /// </summary>
    public void onClickCreateRoom()
    {
        pHandler.CreateNewRoom();
       // if(createRoomInput.text.Length>=1)
       // PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }
    /// <summary>
    /// 加入房間
    /// </summary>
    public void onClickJoinRoom()
    {
        pHandler.JoinOrCreateRoom();
       // RoomOptions roomOptions = new RoomOptions();
        //roomOptions.MaxPlayers = 4;
        //PhotonNetwork.JoinOrCreateRoom(joinRoomInput.text, roomOptions, TypedLobby.Default);
       // PhotonNetwork.JoinRoom(joinRoomInput.text);
    }
    /// <summary>
    /// 判斷是否加入到房間
    /// </summary>
   /*
    private void OnJoinedRoom()
    {
        pHandler.moveScene();
        //mLogic.disableMenuUI();
        Debug.Log("已連接到房間!");
    }
    */
}
