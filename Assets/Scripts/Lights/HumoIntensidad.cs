using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumoIntensidad : MonoBehaviour
{
    public ParticleSystem smoke;
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    public int smokeChannel = 200;
    public int smokeSpeedChannel = 201;

    void Start()
    {
        //spotlight = GetComponent<Light>();

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

        smoke.startSize = 0;
    }

    void Update()
    {
        if (dmxProtocol.getDMXChannel() == smokeChannel)
        {
            if ((float)dmxProtocol.getDMXValue() == 0)
            {
                smoke.startSize = 0;
            }
            else
            {
                smoke.startSize = ((float)dmxProtocol.getDMXValue() / 255) * 10;
            }
        }

        if (dmxProtocol.getDMXChannel() == smokeSpeedChannel)
        {
            smoke.startSpeed = ((float)dmxProtocol.getDMXValue() / 255) * 10;
        }

    }

}