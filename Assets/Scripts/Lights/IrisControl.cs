using UnityEngine;
using UnityEngine.UI;

public class ControladorIris : MonoBehaviour
{
    public int irisChannel;
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;

    void Start()
    {
        // Desactiva todos los iris al inicio
        DesactivarTodosLosIris();

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
        if(dmxProtocol.getDMXChannel()==irisChannel)
        {
            Debug.Log("Valor del slider de cambio iris: " + irisChannel);
            //Debug.Log("Intensidad: "+dmxProtocol.getDMXValue());
            ActualizarIris((float)dmxProtocol.getDMXValue()/255);
        }
    }

    void ActualizarIris(float valor)
    {
        // Obtiene el valor entero del slider y lo convierte a un entero
        int valorEntero = Mathf.RoundToInt(valor);

        // Desactiva todos los iris
        DesactivarTodosLosIris();

        // Activa los iris según el valor del slider
        for (int i = 0; i <= valorEntero; i++)
        {
            Transform iris = transform.Find("Iris" + i);
            if (iris != null)
            {
                iris.gameObject.SetActive(true);
            }
        }
    }

    void DesactivarTodosLosIris()
    {
        // Desactiva todos los iris
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}

// using UnityEngine;
// using UnityEngine.UI;

// public class ControladorIris : MonoBehaviour
// {
//     public Slider sliderIris;

//     void Start()
//     {
//         // Desactiva todos los iris al inicio
//         DesactivarTodosLosIris();

//         // Agrega un listener al slider para detectar cambios
//         sliderIris.onValueChanged.AddListener(ActualizarIris);
//     }

//     void ActualizarIris(float valor)
//     {
//         // Obtiene el valor entero del slider y lo convierte a un entero
//         int valorEntero = Mathf.RoundToInt(valor);

//         // Desactiva todos los iris
//         DesactivarTodosLosIris();

//         // Activa los iris según el valor del slider
//         for (int i = 0; i <= valorEntero; i++)
//         {
//             Transform iris = transform.Find("Iris" + i);
//             if (iris != null)
//             {
//                 iris.gameObject.SetActive(true);
//             }
//         }
//     }

//     void DesactivarTodosLosIris()
//     {
//         // Desactiva todos los iris
//         for (int i = 0; i < transform.childCount; i++)
//         {
//             transform.GetChild(i).gameObject.SetActive(false);
//         }
//     }
// }
