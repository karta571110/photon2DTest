using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plMove :Photon.MonoBehaviour
{
    public bool devTesting = false;

    public PhotonView photonView;

    public GameObject plCam;

    public float moveSpeed = 100f;

    public float jumpForce = 800f;

    private Vector3 selfPos;

    private GameObject sceneCam;
    private void Awake()
    {
        if(!devTesting && photonView.isMine)
        {
            sceneCam = GameObject.Find("Main Camera");

            sceneCam.SetActive(false);
            plCam.SetActive(true);
        }
    }
    private void Update()
    {
        if (!devTesting)
        {
            if (photonView.isMine)
                checkInput();
            else
                smoothNetMovement();
        }
        else
            checkInput();
    }

    private void checkInput()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"),0,0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    private void smoothNetMovement()
    {
        transform.position = Vector3.Lerp(transform.position, selfPos, Time.deltaTime * 8);
    
    }

    private void OnPhotonSerializeView(PhotonStream Stream,PhotonMessageInfo info)
    {
        if(Stream.isWriting)
        {
            Stream.SendNext(transform.position);
        }
        else
        {
            selfPos = (Vector3)Stream.ReceiveNext();
        }
    }
}
