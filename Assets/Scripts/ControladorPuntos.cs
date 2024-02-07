using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class ControladorPuntos : MonoBehaviourPunCallbacks
{

    public TMP_InputField VariableLocalInput;
    public TMP_Text VariableLocalText;
    public TMP_Text VariableRedText;
    public TMP_Text TextoInformacion;

    //Variable para modificar en red
    public string tomarDatosRiva="0";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Cuando se introduce valortes en el inputfield trendra que sincronizarse. Metodo CambiarValor
    public void CambiarValor()
    {
        string value = VariableLocalInput.text;
        VariableLocalText.text = value;//Jugador local cambia el valor, cambia su puntuación.
        //Ahora tendremos que avisar al otro jugador para que lo vea y lo modifique
        photonView.RPC(nameof(CambiarValorEnRed), RpcTarget.OthersBuffered, value);

        Comproba();
    }

    [PunRPC]
    void CambiarValorEnRed(string variable)
    {
        VariableRedText.text = variable;//Cambia el valor del otro jugador
    }
    [PunRPC]
    void CambiarTexto() {

            TextoInformacion.text = "El numero ha sido encontrado";

    }

    public void Comproba()
    {
        int num1 = int.Parse(VariableLocalInput.text);
        int num2 = int.Parse(VariableRedText.text);

        if (photonView.IsMine && !VariableLocalInput.isFocused)
        {

            TextoInformacion.text = "Ya has introducido el numero";
        }
        if (!photonView.IsMine)
        {
            TextoInformacion.text = "Introduce un numero";
            if (num2 > num1)
            {
                TextoInformacion.text = "No has llegado";
            }
            else if (num2 < num1)
            {
                TextoInformacion.text = "Te has pasado";
            }
            else
            {
                TextoInformacion.text = "Lo has logrado";
                photonView.RPC(nameof(CambiarTexto), RpcTarget.OthersBuffered);
            }
        }


    }
}
