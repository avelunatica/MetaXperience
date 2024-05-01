using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffBeam : MonoBehaviour
{
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    public MeshRenderer meshRenderer;
    public MeshRenderer meshRendererLaser;
    public int OnOffChannel = 0;
    int valueOnOff;

    void Start()
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
        meshRendererLaser.enabled = false;
    }

    void Update()
    {
        if (dmxProtocol.getDMXChannel() == OnOffChannel)
        {
            valueOnOff = dmxProtocol.getDMXValue();
            
            if (valueOnOff > 0) 
            {
                meshRendererLaser.enabled = true;
            }
            if (valueOnOff == 0) 
            {
                meshRendererLaser.enabled = false;
            }
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class OnOffBeam : MonoBehaviour
// {
//     private GameObject dmxProtocolObject;
//     public ParticleSystem beamLight;
//     private DMXProtocol dmxProtocol;
//     public MeshRenderer meshRenderer;
//     public int OnOffChannel = 0;
//     public Light lightBeam;
//     int valueOnOff;

//     void Start()
//     {
//         lightBeam.enabled = false; //apagada por defecto
//         dmxProtocolObject = GameObject.Find("GameManager");

//         // Verifica si se encontró el objeto y el script
//         if (dmxProtocolObject != null)
//         {
//             dmxProtocol = dmxProtocolObject.GetComponent<DMXProtocol>();
//         }
//         else
//         {
//             Debug.LogError("Objeto DMXProtocol no encontrado.");
//         }
//         //beamLight = dmxProtocolObject.GetComponent<ParticleSystem>();
//         //beamLight.Play();
//     }

//     void Update()
//     {
//         if (dmxProtocol.getDMXChannel() == OnOffChannel)
//         {
//             valueOnOff = dmxProtocol.getDMXValue();
            
//             if (valueOnOff > 0) 
//             {
//                 if(beamLight.isPlaying == false)
//                     beamLight.Play();
//                 lightBeam.enabled = true;
//             }
//             if (valueOnOff == 0) 
//             {
//                 if(beamLight.isPlaying == true)
//                     beamLight.Stop();
//                 lightBeam.enabled = false;
//             }
//         }
//     }
// }
