using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using TMPro;
using Unity.VisualScripting;

public class RDMData : MonoBehaviour
{
    
    public Button onOffRDM; // Boton para enseñar o no los datos del RDM
    public TMP_Text textoRDM; // Referencia al texto que se muestra
    public GameObject panelRDM;

    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    private bool showing = false;

    private int channel;
    private int value;
    private String msgRDM;

    // Start is called before the first frame update
    void Start()
    {
        // Busca el objeto DMXProtocol en la escena
        dmxProtocolObject = GameObject.Find("GameManager");

        // Verifica si se encuentra el objeto y el script
        if (dmxProtocolObject != null)
        {
            dmxProtocol = dmxProtocolObject.GetComponent<DMXProtocol>();
        }
        else
        {
            Debug.LogError("Objeto DMXProtocol no encontrado.");
        }

        // Asocia la funci�n Grabar al evento de clic del bot�n
        if (onOffRDM != null)
        {
            
        }
        else
        {
            Debug.LogError("Boton RDM no asignado.");
        }

        onOffRDM.onClick.AddListener(changeShowing);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (showing) mostrarRDM();
        else mostrarPlaceholder();
    }

    void mostrarRDM()
    {
        panelRDM.active = true;
        channel = dmxProtocol.getDMXChannel();
        value = dmxProtocol.getDMXValue();
        msgRDM = "Channel: " + channel + ", Value: " + value;
        textoRDM.text = msgRDM;
        //Debug.Log(msgRDM);
        //getDMXchannel
        //En un cuadro de texto, escribir channel: nn || value: nn
    }

    void mostrarPlaceholder()
    {
        textoRDM.text = "";
        panelRDM.active = false;
    }

    void changeShowing()
    {
        showing = !showing;
    }
}
