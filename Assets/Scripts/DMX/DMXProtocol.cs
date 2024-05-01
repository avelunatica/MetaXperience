using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DMXProtocol : MonoBehaviour
{
    // Variables para almacenar el canal DMX y su valor
    private int DMXchannel;
    private int DMXValue;


    void Start()
    {
        // Asigna el valor del slider de canal DMX a la variable DMXchannel
        DMXchannel = 0;

        // Asigna el valor del slider de valor DMX a la variable DMXValue
        DMXValue = 0;

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("DMX channel / value: "+DMXchannel+", "+DMXValue);        
    } 

    public int getDMXChannel()
    {
        return DMXchannel;
    }
    public int getDMXValue()
    {
        return DMXValue;
    }

    public void setDMXChannel(int channel)
    {
       DMXchannel=channel;
    }

    public void setDMXValue(int values)
    {
        DMXValue=values;
    }

}

