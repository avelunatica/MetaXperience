using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioColor : MonoBehaviour
{
    private float valueR = 0;
    private float valueG = 0;
    private float valueB = 0;
    private Light spotlight;
    public Slider redSlider;
    public Slider blueSlider;
    public Slider greenSlider;
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    public int redChannel = 0;
    public int greenChannel = 0;
    public int blueChannel = 0;

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

        //spotlight.color = new Color(1,1,1);
    }

void Update()
    {
        if (dmxProtocol.getDMXChannel() == redChannel)
        {
            valueR = (float)dmxProtocol.getDMXValue() / 255;
        }
        if (dmxProtocol.getDMXChannel() == greenChannel)
        {
            valueG = (float)dmxProtocol.getDMXValue() / 255;
        }
        if (dmxProtocol.getDMXChannel() == blueChannel)
        {
            valueB = (float)dmxProtocol.getDMXValue() / 255;
        }

        spotlight.color = new Color(valueR,valueG,valueB);

    }

}