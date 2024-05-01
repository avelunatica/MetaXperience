using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{

    private Light spotlight;
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    private float valueZoom = 0;
    public int shutterChannel = 0;

    void Start()
    {
        spotlight = GetComponent<Light>();
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
    }

    void Update()
    {
        if (dmxProtocol.getDMXChannel() == shutterChannel)
        {
            valueZoom = Mathf.Min((dmxProtocol.getDMXValue() / 255f) * 90f, 50f);
            //valueZoom = ((float)dmxProtocol.getDMXValue()/255)*90;
            spotlight.spotAngle = valueZoom;
        }
    }
}
