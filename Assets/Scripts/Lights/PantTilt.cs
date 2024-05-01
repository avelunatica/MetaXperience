using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantTilt : MonoBehaviour
{

    public float velocidadRotacion = 60f;
    private Light spotlight;
    // public Button UpButton;
    // public Button DownButton;
    // public Button LeftButton;
    // public Button RightButton;
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    public int PantTiltChannel = 0;

    private Quaternion initialRotation = Quaternion.Euler(0f, 0f, 0f);

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
        if (dmxProtocol.getDMXChannel() == PantTiltChannel)
        {
            if (dmxProtocol.getDMXValue() == 0) transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
            if (dmxProtocol.getDMXValue() == 1) transform.Rotate(Vector3.down * velocidadRotacion * Time.deltaTime);
            if (dmxProtocol.getDMXValue() == 2) transform.Rotate(Vector3.left * velocidadRotacion * Time.deltaTime);
            if (dmxProtocol.getDMXValue() == 3) transform.Rotate(Vector3.right * velocidadRotacion * Time.deltaTime);
            if (dmxProtocol.getDMXValue() == 4) transform.Rotate(Vector3.zero);
            if (dmxProtocol.getDMXValue() == 5) transform.rotation = Quaternion.RotateTowards(transform.rotation, initialRotation, 90f * Time.deltaTime); //por defecto, valor inicial
        }

   
    } 
}
