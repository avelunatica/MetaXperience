using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNight : MonoBehaviour
{
    public Light sunLight;  // Referencia a la luz direccional (sol)
    public Color dayColor;  // Color del día
    public Color nightColor; // Color de la noche
    public TMP_Text timeText;

    private bool isDay = true; // Estado actual: día o noche

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Day";
    }

    // Método para establecer el ciclo día
    public void changeHourButton()
    {
        if (!isDay)
        {
            sunLight.gameObject.SetActive(true);
            sunLight.color = dayColor;
            RenderSettings.ambientLight = dayColor;
            timeText.text = "Day";
            isDay = true;
        }
        else if(isDay)
        {
            // sunLight.color = nightColor;
            // RenderSettings.ambientLight = nightColor;
            sunLight.gameObject.SetActive(false);
            timeText.text = "Night";
            isDay = false;
        }
    }

    public void ChangeHourSlider(float value)
    {
        Vector3 lightRotation = new Vector3(value * 360f, -30f, 0f); // Corrected syntax for Vector3 creation
        sunLight.transform.eulerAngles = lightRotation; // Applying the new rotation to the sunLight
    }


    // Update is called once per frame
    void Update()
    {

    }
}
