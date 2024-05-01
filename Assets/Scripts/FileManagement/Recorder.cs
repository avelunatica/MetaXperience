using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;
using TMPro;

public class Recorder : MonoBehaviour
{
    //public static float intervaloGrabacion = 0.05f; // Intervalo de grabaci�n en segundos
    public string nombreArchivo = "demo.txt"; // Nombre del archivo de texto
    public Button botonGrabar; // Referencia al bot�n en Unity que activar� la grabaci�n
    public TMP_Text textoGrabando; // Referencia al texto de la grbacion

    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    private bool recording = false;

    private int channel;
    private int value;

    private bool showText = true;
    private void Start()
    {
        // Busca el objeto DMXProtocol en la escena
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

        // Asocia la funci�n Grabar al evento de clic del bot�n
        if (botonGrabar != null)
        {
            //botonGrabar.onClick.AddListener(RecordOn);
        }
        else
        {
            Debug.LogError("Boton de grabacion no asignado.");
        }
    }

    public void Update()
    {
        if (recording) Grabar();
    }

    public void hideText()
    {
        showText = !showText;
        textoGrabando.gameObject.SetActive(showText);
    }

    public void RecordOn()
    {
        recording = !recording;
        Debug.Log("no funciona " + recording);
    }

    public void Grabar()
    {
        RecordChannel();
        RecordValue();
        StoreFileWithTimestamp(); // Nuevo método para almacenar con timestamp
        Debug.Log("Grabando datos...");
    }

    public void StoreFileWithTimestamp()
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(folderPath, nombreArchivo);

        // Obtiene la fecha y hora actual como timestamp
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            // Escribe la línea con timestamp, canal y valor
            sw.WriteLine(timestamp + " " + channel.ToString() + " " + value.ToString());
        }

        Debug.Log("Datos guardados en: " + filePath);
        textoGrabando.text = "Datos guardados en: " + filePath;
    }

    public void RecordChannel()
    {
        // Obtiene el valor del canal DMX del objeto DMXProtocol
        channel = dmxProtocol.getDMXChannel();
    }

    public void RecordValue()
    {
        // Obtiene el valor DMX del objeto DMXProtocol
        value = dmxProtocol.getDMXValue();
    }
}