using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLogic : MonoBehaviour
{
    public GameObject irisControl;
    public GameObject shutterControl;
    public GameObject gobosControl;
    public GameObject colorControl;
    public GameObject onoffControl;
    public GameObject strobeControl;
    public GameObject pantiltControl;
    public GameObject smokeControl;
    public GameObject intensityControl;
    public Slider mainSlider, irisSlider, shutterSlider;
    public string groupPressed = "", previousGroupPressed = "";
    public Button spot1Button, spot2Button, beam1Button, wash1Button, wash2Button, wash3Button, strobeButton, blinder1Button, blinder2Button, fogButton;
    private float spot1Intensity=0f, spot2Intensity=0f, wash1Intensity=0f, wash2Intensity=0f, wash3Intensity=0f, beam1Intensity=0f, blinder1Intensity=0f, blinder2Intensity=0f, strobeIntensity=0f, spot1Iris=0f, spot1Shutter=0f, spot2Iris=0f, spot2Shutter=0f;

    
    public Button rec, load,stop_rec;
    public GameObject recControl, stopRecControl;
    
    public Button offGobo, gobo1, gobo2, gobo3, gobo4, gobo5, gobo6, gobo7;
    // Start is called before the first frame update
    void Start()
    {
        irisControl.SetActive(false);
        shutterControl.SetActive(false);
        gobosControl.SetActive(false);
        colorControl.SetActive(false);
        strobeControl.SetActive(false);
        pantiltControl.SetActive(false);
        smokeControl.SetActive(false);
        intensityControl.SetActive(false);
        onoffControl.SetActive(false);
        stopRecControl.SetActive(false);

        spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);

        offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
        gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);

        rec.GetComponent<Image>().color = new Color(236f / 255f, 157f / 255f, 157f / 255f);
        load.GetComponent<Image>().color = new Color(170f / 255f, 255f / 255f, 170f / 255f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("group pressed: " + groupPressed);

        Debug.Log("spot1 " + spot1Intensity + ",spot2 " + spot2Intensity + ", wash1 " + wash1Intensity + ",wash2 " + wash2Intensity + ", wash3 " + 
        wash3Intensity + ", beam1 " + beam1Intensity + ", blinder1 " + blinder1Intensity + ", blinder2 " + blinder2Intensity + ", strobe " + strobeIntensity);

        switch (groupPressed)
        {
            case "spot1":
                if(previousGroupPressed != "spot1")
                {
                    mainSlider.value = spot1Intensity;
                    irisSlider.value = spot1Iris;
                    shutterSlider.value = spot1Shutter;
                }
                irisControl.SetActive(true);
                shutterControl.SetActive(true);
                gobosControl.SetActive(true);
                colorControl.SetActive(true);
                onoffControl.SetActive(true);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(true);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "spot2":
                if(previousGroupPressed != "spot2")
                {
                    mainSlider.value = spot2Intensity;
                    irisSlider.value = spot2Iris;
                    shutterSlider.value = spot2Shutter;
                }
                irisControl.SetActive(true);
                shutterControl.SetActive(true);
                gobosControl.SetActive(true);
                colorControl.SetActive(true);
                onoffControl.SetActive(true);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(true);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "wash1":
                if(previousGroupPressed != "wash1")  mainSlider.value = wash2Intensity;
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(true);
                onoffControl.SetActive(true);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(true);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "wash2":
                if(previousGroupPressed != "wash2") mainSlider.value = wash2Intensity;
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(true);
                onoffControl.SetActive(true);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(true);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "wash3":
                if(previousGroupPressed != "wash3") mainSlider.value = wash3Intensity;
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(true);
                onoffControl.SetActive(true);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(true);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "beam1":
                if(previousGroupPressed != "beam1") mainSlider.value = beam1Intensity;
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(false);
                onoffControl.SetActive(true);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(true);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "strobe":
                if(previousGroupPressed != "strobe") mainSlider.value = strobeIntensity;
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(false);
                onoffControl.SetActive(false);
                strobeControl.SetActive(true);
                pantiltControl.SetActive(false);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "blinder1":
                if(previousGroupPressed != "blinder1") mainSlider.value = blinder1Intensity;
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(false);
                onoffControl.SetActive(false);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(false);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "blinder2":
                if(previousGroupPressed != "blinder2") mainSlider.value = blinder2Intensity;
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(false);
                onoffControl.SetActive(false);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(false);
                smokeControl.SetActive(false);
                intensityControl.SetActive(true);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                fogButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "fog":
                irisControl.SetActive(false);
                shutterControl.SetActive(false);
                gobosControl.SetActive(false);
                colorControl.SetActive(false);
                onoffControl.SetActive(false);
                strobeControl.SetActive(false);
                pantiltControl.SetActive(false);
                smokeControl.SetActive(true);
                intensityControl.SetActive(false);
                spot1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                spot2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                wash3Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                beam1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                strobeButton.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder1Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                blinder2Button.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                fogButton.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                break;

            case "rec":
                
                stop_rec.GetComponent<Image>().color = new Color(255f / 255f, 35f / 255f, 35f / 255f);
                load.GetComponent<Image>().color = new Color(144f / 255f, 255f / 255f, 144f / 255f);
                stopRecControl.SetActive(true);
                recControl.SetActive(false);
                break;

            case "load":
                rec.GetComponent<Image>().color = new Color(251f / 255f, 143f / 255f, 143f / 255f);
                load.GetComponent<Image>().color = new Color(20f / 255f, 255f / 255f, 20f / 255f);

                break;
            
            case "stop_rec":
               
                rec.GetComponent<Image>().color = new Color(251f / 255f, 143f / 255f, 143f / 255f);
                stopRecControl.SetActive(false);
                recControl.SetActive(true);
                load.GetComponent<Image>().color = new Color(144f / 255f, 250f / 255f, 143f / 255f);





                load.GetComponent<Image>().color = new Color(144f / 255f, 255f / 255f, 144f / 255f);

                break;

            default:
               // Debug.LogError("No se encontro el grupo: " + groupPressed);
                break;
        }

        previousGroupPressed = groupPressed;

        if (groupPressed == "spot1") 
        {
            spot1Intensity = mainSlider.value;
            spot1Iris = irisSlider.value;
            spot1Shutter = shutterSlider.value;
        }
        if (groupPressed == "spot2") 
        {
            spot2Intensity = mainSlider.value;
            spot2Iris = irisSlider.value;
            spot2Shutter = shutterSlider.value;
        }
        if (groupPressed == "wash1") {wash1Intensity = mainSlider.value; }
        if (groupPressed == "wash2") {wash2Intensity = mainSlider.value; }
        if (groupPressed == "wash3") {wash3Intensity = mainSlider.value; }
        if (groupPressed == "beam1") {beam1Intensity = mainSlider.value; }
        if (groupPressed == "blinder1") {blinder1Intensity = mainSlider.value; }
        if (groupPressed == "blinder2") {blinder2Intensity = mainSlider.value; }
        if (groupPressed == "strobe") {strobeIntensity = mainSlider.value; }
    }

    public void pressedLight(string group)
    {
        groupPressed = group;
    }

    public void quit()
    {
        Application.Quit();
    }


   

    public void gobos(string group)
    {
        switch (group)
        {
            case "off":
                offGobo.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "1":
                offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo1.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "2":
                offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo2.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "3":
                offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo3.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "4":
                offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo4.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "5":
                offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo5.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "6":
                offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo6.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                gobo7.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                break;
            case "7":
                offGobo.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo1.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo2.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo3.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo4.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo5.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo6.GetComponent<Image>().color = new Color(102f/255f, 102f/255f, 102f/255f);
                gobo7.GetComponent<Image>().color = new Color(100f/255f, 198f/255f, 189f);
                break;
        }
    }
}
