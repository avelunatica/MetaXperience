using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioIntensidad : MonoBehaviour
{
    // Referencia al objeto que contiene el script DMXProtocol
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    private Light spotlight;
    float valueIntensity = 0;
    public int intensityChannel = 0;

    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
        // Encuentra el objeto por su nombre. Aseg�rate de que el nombre sea correcto.
        dmxProtocolObject = GameObject.Find("GameManager");

        // Verifica si se encontr� el objeto y el script
        if (dmxProtocolObject != null)
        {
            dmxProtocol = dmxProtocolObject.GetComponent<DMXProtocol>();
        }
        else
        {
            Debug.LogError("Objeto DMXProtocol no encontrado.");
        }

        spotlight.intensity = 0; //la pongo a 0 al principio, hasta que toque algo de la interfaz
    }

  
    void Update()
    {
        if(dmxProtocol.getDMXChannel()==intensityChannel)
        {
            valueIntensity=(float)dmxProtocol.getDMXValue()/255;
            spotlight.intensity = valueIntensity;
        }
    }
}

//Debug.Log("Valor del slider de cambintensidad: " + intensityChannel);
            //Debug.Log("Intensidad: "+dmxProtocol.getDMXValue());