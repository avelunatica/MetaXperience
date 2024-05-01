using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinder : MonoBehaviour
{
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    public Light light;
    public int lightsBlinderChannel = 400;
    public GameObject cilynder1, cilynder2, cilynder3, cilynder4;
    public Material blinderOFF;
    public Material blinderON;
    private float valueIntensity = 0f;

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

        light.intensity = 0;
    }

    void Update()
    {
        if(dmxProtocol.getDMXChannel()==lightsBlinderChannel)
        {
            Debug.Log("Intensidad: "+dmxProtocol.getDMXValue());
            valueIntensity=(float)dmxProtocol.getDMXValue()/255;
            light.intensity = valueIntensity;

            if(dmxProtocol.getDMXValue() != 0)
            {
                cilynder1.GetComponent<Renderer>().material = blinderON;
                cilynder2.GetComponent<Renderer>().material = blinderON;
                cilynder3.GetComponent<Renderer>().material = blinderON;
                cilynder4.GetComponent<Renderer>().material = blinderON;
            }
            if(dmxProtocol.getDMXValue() == 0)
            {
                cilynder1.GetComponent<Renderer>().material = blinderOFF;
                cilynder2.GetComponent<Renderer>().material = blinderOFF;
                cilynder3.GetComponent<Renderer>().material = blinderOFF;
                cilynder4.GetComponent<Renderer>().material = blinderOFF;
            }
        }
    }

}