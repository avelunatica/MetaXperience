using System.Collections;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{
    public Button PlayButton;
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    
    private void Start()
    {
        dmxProtocolObject = GameObject.Find("GameManager");

        // Verifica si se encontró el objeto y el script
        if (dmxProtocolObject != null)
        {
            dmxProtocol = dmxProtocolObject.GetComponent<DMXProtocol>();
        }
        else
        {
            Debug.LogError("Objeto DMXProtocol no encontrado.");
        }
    }

        void PlayMusic()
    {
        // Verifica si el botón existe
        if (PlayButton != null)
        {
            // Simula la pulsación del botón
            PlayButton.onClick.Invoke();
        }
        else
        {
            Debug.LogError("No se ha asignado ningún botón para simular.");
        }
    }

    public void empezarDemo()
    {
        StartCoroutine(demo());
        Invoke("PlayMusic", 1f); //Simula la pulsación del botón Play.
    }

    //private IEnumerator demo(int totalIterations, int DMXchannel, int DMXvalue)
    private IEnumerator demo()
    {
        //encender wash1
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(100);
        dmxProtocol.setDMXValue(128);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(101);
        dmxProtocol.setDMXValue(120);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(102);
        dmxProtocol.setDMXValue(128);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(103);
        dmxProtocol.setDMXValue(188);

        
        
        //encender wash2
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(120);
        dmxProtocol.setDMXValue(128);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(121);
        dmxProtocol.setDMXValue(200);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(122);
        dmxProtocol.setDMXValue(250);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(123);
        dmxProtocol.setDMXValue(20);



        //encender spot1
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(0);
        dmxProtocol.setDMXValue(255);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(1);
        dmxProtocol.setDMXValue(255);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(2);
        dmxProtocol.setDMXValue(128);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(3);
        dmxProtocol.setDMXValue(65);
        //shutter
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(4);
        dmxProtocol.setDMXValue(255);
        //pantilt
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(2);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(3);
        yield return new WaitForSeconds(2f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(5);
        yield return new WaitForSeconds(1f);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(1);
        dmxProtocol.setDMXValue(12);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(2);
        dmxProtocol.setDMXValue(255);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(3);
        dmxProtocol.setDMXValue(128);
        //gobo
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(6);
        dmxProtocol.setDMXValue(5);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(6);
        dmxProtocol.setDMXValue(5);
        //iris
        for (int i = 0; i < 100; i++)
        {
            dmxProtocol.setDMXChannel(7);
            dmxProtocol.setDMXValue(i*10);
            yield return new WaitForSeconds(0.001f);
            i+=1;
        }



        //encender spot2
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(20);
        dmxProtocol.setDMXValue(255);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(21);
        dmxProtocol.setDMXValue(255);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(22);
        dmxProtocol.setDMXValue(128);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(23);
        dmxProtocol.setDMXValue(65);
        //shutter
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(24);
        dmxProtocol.setDMXValue(255);
        //pantilt
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(25);
        dmxProtocol.setDMXValue(1);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(25);
        dmxProtocol.setDMXValue(4);
        yield return new WaitForSeconds(2f);
        dmxProtocol.setDMXChannel(25);
        dmxProtocol.setDMXValue(5);
        yield return new WaitForSeconds(1f);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(21);
        dmxProtocol.setDMXValue(255);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(22);
        dmxProtocol.setDMXValue(255);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(23);
        dmxProtocol.setDMXValue(0);
        //gobo
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(26);
        dmxProtocol.setDMXValue(3);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(26);
        dmxProtocol.setDMXValue(3);
        //iris
        for (int i = 0; i < 2; i++)
        {
            dmxProtocol.setDMXChannel(7);
            dmxProtocol.setDMXValue(i*10);
            yield return new WaitForSeconds(0.001f);
            i+=1;
        }



        //encender blinder1 y 2
        for (int i = 0; i < 255; i++)
        {
            dmxProtocol.setDMXChannel(400);
            dmxProtocol.setDMXValue(128);
            yield return new WaitForSeconds(0.1f);
            dmxProtocol.setDMXValue(0);
            yield return new WaitForSeconds(0.1f);
            dmxProtocol.setDMXChannel(401);
            dmxProtocol.setDMXValue(255);
            yield return new WaitForSeconds(0.1f);
            dmxProtocol.setDMXValue(0);
            yield return new WaitForSeconds(0.1f);
            i+=70;
        }

        //encender beam1
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(40);
        dmxProtocol.setDMXValue(255);
        //pantilt
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(41);
        dmxProtocol.setDMXValue(2);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(41);
        dmxProtocol.setDMXValue(3);
        yield return new WaitForSeconds(2f);
        dmxProtocol.setDMXChannel(41);
        dmxProtocol.setDMXValue(5);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(41);
        dmxProtocol.setDMXValue(2);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(41);
        dmxProtocol.setDMXValue(3);
        yield return new WaitForSeconds(2f);
        dmxProtocol.setDMXChannel(41);
        dmxProtocol.setDMXValue(5);


        //apagar wash1
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(100);
        dmxProtocol.setDMXValue(0);
        
        //apagar wash2
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(120);
        dmxProtocol.setDMXValue(0);


        //encender spot1
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(0);
        dmxProtocol.setDMXValue(255);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(1);
        dmxProtocol.setDMXValue(255);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(2);
        dmxProtocol.setDMXValue(0);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(3);
        dmxProtocol.setDMXValue(0);
        //shutter
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(4);
        dmxProtocol.setDMXValue(255);
        //pantilt
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(2);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(3);
        yield return new WaitForSeconds(2f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(1);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(4);
        yield return new WaitForSeconds(1f);
        dmxProtocol.setDMXChannel(5);
        dmxProtocol.setDMXValue(5);
        yield return new WaitForSeconds(1f);
        //color
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(1);
        dmxProtocol.setDMXValue(12);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(2);
        dmxProtocol.setDMXValue(255);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(3);
        dmxProtocol.setDMXValue(128);
        //gobo
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(6);
        dmxProtocol.setDMXValue(5);
        yield return new WaitForSeconds(0.1f);
        dmxProtocol.setDMXChannel(6);
        dmxProtocol.setDMXValue(5);

        
        for (int i = 0; i < 511; i++)
        {
            yield return new WaitForSeconds(0.01f);
            dmxProtocol.setDMXChannel(i);
            dmxProtocol.setDMXValue(0);
            i+=1;
        }
    }
}
