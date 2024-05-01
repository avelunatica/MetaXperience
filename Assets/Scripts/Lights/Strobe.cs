using UnityEngine;

public class Strobe : MonoBehaviour
{
    public Light light;
    public int intensityChannelStrobe = 500;
    public int frequencyChannelStrobe = 501;
    public Material strobeOFF;
    public Material strobeON;
    public GameObject cube;
    public static float maxFrequency = 5f;    //Hz
    private DMXProtocol dmxProtocol;
    private float timer;
    private float oldFlashingValue = 0f;

    void Start()
    {
        // Find the DMXProtocol component
        GameObject dmxProtocolObject = GameObject.Find("GameManager");
        if (dmxProtocolObject != null)
        {
            dmxProtocol = dmxProtocolObject.GetComponent<DMXProtocol>();
        }
        else
        {
            Debug.LogError("DMXProtocol object not found.");
        }

        // Initialize timer
        timer = 1 / maxFrequency;

        // Ensure light is off initially
        light.intensity = 0;
    }

    void Update()
    {
        // Check if DMX channel for frequency matches
        if (dmxProtocol.getDMXChannel() == frequencyChannelStrobe)
        {
            oldFlashingValue = dmxProtocol.getDMXValue();
        }

        // Check if DMX channel for intensity matches
        if (dmxProtocol.getDMXChannel() == intensityChannelStrobe)
        {
            // Update light intensity based on DMX value
            light.intensity = (float)dmxProtocol.getDMXValue() / 255;
        }

        flash();
    }

    void flash()
    {
        // Decrement timer
        timer -= Time.deltaTime;

        // Check if it's time to toggle the light
        if (timer <= 0 && oldFlashingValue != 255)
        {
            // Reset timer based on frequency and DMX value
            timer = (1 / maxFrequency) * oldFlashingValue / 255;

            // Toggle the light
            light.enabled = !light.enabled;

            // Optionally, change material based on light state
            if (light.enabled)
            {
                // Apply ON material
                cube.GetComponent<Renderer>().material = strobeON;
            }
            else
            {
                // Apply OFF material
                cube.GetComponent<Renderer>().material = strobeOFF;
            }
        }
        if (oldFlashingValue == 255)
        {
            if (dmxProtocol.getDMXChannel() == frequencyChannelStrobe)
            {
                // Update light intensity based on DMX value
                light.enabled = true;
                light.intensity = oldFlashingValue / 255;
            }
        }

        // else(dmxProtocol.getDMXValue() == 0)
        // {

        // }
    }
}