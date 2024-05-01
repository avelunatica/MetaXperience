﻿using AnotherFileBrowser.Windows;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;


public class Loader : MonoBehaviour
{
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    //public TMP_Text textField;

    //private float intervalBetweenIterations = 0.01f; // Intervalo de tiempo entre cada iteración en segundos
    private DateTime previousTimestamp; // Variable para almacenar el timestamp anterior

    //ligamos el script al boton de play del audio
    public Button PlayButton;



    public void Start()
    {
        // Busca el objeto DMXProtocol en la escena
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

    public void Update()
    {
        // No es necesario implementar nada en Update para este script
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

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Text files (*.txt) | *.txt";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            // Cargar el contenido del archivo de texto
            StartCoroutine(LoadAndProcessText(path));
            //Audio:
            Invoke("PlayMusic", 1f); //Simula la pulsación del botón Play.
        });
    }

    IEnumerator LoadAndProcessText(string path)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(path))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error al cargar el archivo: {uwr.error}");
            }
            else
            {
                string loadedText = uwr.downloadHandler.text;
                Debug.Log($"Contenido del archivo cargado:\n{loadedText}"); // Mostrar el contenido cargado

                yield return StartCoroutine(ProcessLoadedText(loadedText)); // Ejecutar la corutina de procesamiento
            }
        }
    }

    IEnumerator ProcessLoadedText(string loadedText)
    {
        string[] lines = loadedText.Split('\n');

        foreach (string line in lines)
        {
            if (!string.IsNullOrEmpty(line.Trim()))
            {
                string[] parts = line.Trim().Split(' ');

                if (parts.Length >= 3)
                {
                    // Intenta convertir el primer elemento en un DateTime (timestamp)
                    if (DateTime.TryParse(parts[0] + " " + parts[1], out DateTime timestamp))
                    {
                        // Calcula el tiempo de espera en base a la diferencia con el timestamp anterior
                        if (previousTimestamp != DateTime.MinValue)
                        {
                            TimeSpan timeDifference = timestamp - previousTimestamp;
                            float waitTime = (float)timeDifference.TotalSeconds;
                            yield return new WaitForSeconds(waitTime);
                        }

                        // Intenta convertir los siguientes dos elementos en enteros (channel y value)
                        if (int.TryParse(parts[2], out int channel) && int.TryParse(parts[3], out int value))
                        {
                            // Asignación exitosa de channel y value, ahora podemos utilizarlos
                            SetDMXChannel(channel);
                            SetDMXValue(value);
                            Debug.Log($"Canal DMX establecido en: {channel}, Valor DMX establecido en: {value}, Timestamp: {timestamp}");

                            // Actualiza el timestamp anterior con el timestamp actual
                            previousTimestamp = timestamp;
                        }
                        else
                        {
                            Debug.LogWarning($"Error al convertir los valores en la línea: {line}");
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"Error al convertir el timestamp en la línea: {line}");
                    }
                }
                else
                {
                    Debug.LogWarning($"Formato incorrecto en la línea: {line}");
                }
            }
        }
    
    }

    void SetDMXChannel(int channel)
    {
        dmxProtocol.setDMXChannel(channel);
    }

    void SetDMXValue(int value)
    {
        dmxProtocol.setDMXValue(value);
    }
}