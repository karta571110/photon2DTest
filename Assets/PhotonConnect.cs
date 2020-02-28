using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : Photon.PunBehaviour
{
    public static string versionName = "0.1";
    public GameObject sectionView1, sectionView2, sectionView3;

    private void Start()
    {
        connectToPhoton();
    }
    public void connectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("連接到Photon....");
    }

   private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("連到Master...");
    }

  private void OnJoinedLobby()
    {
        sectionView1.SetActive(false);
        sectionView2.SetActive(true);
        Debug.Log("加入大廳~");
    }

    private void OnDisconnectedFromFromPhoton() 
    {
        if (sectionView1.active)
            sectionView1.SetActive(false);
        if(sectionView2.active)
            sectionView2.SetActive(false);

        sectionView3.SetActive(true);
        Debug.Log("從Photon斷開連接~");
    }

    private void OnFailedToConnectToPhoton() 
    {
        Debug.Log("連接失敗~");
    }

}
