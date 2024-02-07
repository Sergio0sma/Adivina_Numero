using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class ManejadorDeRed : MonoBehaviourPunCallbacks
{

    public TMP_Text Informacion;
    public static ManejadorDeRed manejadorRed;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Informacion.text = "Conectando";
        print("informcion.text");
        Debug.Log("Conectado");
    }

    public override void OnJoinedLobby() { 
        PhotonNetwork.JoinOrCreateRoom("Sala", new RoomOptions { MaxPlayers=2}, TypedLobby.Default);
    }
}
