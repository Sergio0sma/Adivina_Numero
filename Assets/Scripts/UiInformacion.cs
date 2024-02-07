using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class UiInformacion : MonoBehaviourPunCallbacks, IPunObservable //hacemos que sea observable
{
    //Variables
    public TMP_Text informacion;//Texto del banner  
    public int playersNum; //numero de jugador

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SetPlayerOrEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SetPlayerOrEnemy()
    {
        yield return new WaitForSeconds(3);
        if(photonView.IsMine)
            informacion.text = "Yo Soy el jugador";
        if (!photonView.IsMine)
            informacion.text = "Yo No soy el jugador";
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //throw new System.NotImplementedException();
    }
}
