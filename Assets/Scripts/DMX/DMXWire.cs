using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using HSVPicker;

//using UnityEngine.UIElements; // Asegúrate de agregar esta línea para acceder a la clase Slider

public class DMXWire : MonoBehaviour
{
    // Referencia al objeto que contiene el script DMXProtocol
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    private CanvasLogic canvasLogic;

    private GameObject colorPickerObject;
    private ColorPicker colorPicker;

    float redCopy, greenCopy, blueCopy = 0.0f;
    float red, green, blue = 0.0f;

    public Button UP;
    public Button DW;
    public Button LH;
    public Button RH;
    public Button ST;
    //public Button GoboButton;
    public Slider intensitySlider;
    //public Slider smokeSlider;
    public Button onButton, offButton;
    private float valor_viejo_on;

    private bool stPressed, rhPressed, lhPressed, upPressed, dwPressed;

    //private int channelForMoving = 99999;

    //canales para seleccionar cada grupo
    private int intensityChannel, irisChannel, redChannel, greenChannel, blueChannel, shutterChannel, panTiltChannel, goboChannel;

    //Strobe 
    [Header("Strobe channels")]
    public int intensityChannelStrobe = 500;
    public int frequencyChannelStrobe = 501;

    //SMOKE 
    [Header("Smoke channels")]
    public int smokeChannel = 200;
    public int smokeSpeedChannel = 201;

    //Blinder 
    [Header("Blinder1 channels")]
    public int intensityChannelBlinder1 = 400;

    [Header("Blinder2 channels")]
    public int intensityChannelBlinder2 = 401;

    //SPOT 
    [Header("Spot 1 channels")]
    public int intensityChannelSpot1 = 0;
    public int redChannelSpot1 = 1;
    public int greenChannelSpot1 = 2;
    public int blueChannelSpot1 = 3;
    public int shutterChannelSpot1 = 4;
    public int panTiltChannelSpot1 = 5;
    public int goboChannelSpot1 = 6;
    public int irisChannelSpot1 = 7;
    public Slider redSliderSpot1;
    public Slider greenSliderSpot1;
    public Slider blueSliderSpot1;

    //WASH 
    [Header("Spot 2 channels")]
    public int intensityChannelSpot2 = 20;
    public int redChannelSpot2 = 21;
    public int greenChannelSpot2 = 22;
    public int blueChannelSpot2 = 23;
    public int shutterChannelSpot2 = 24;
    public int panTiltChannelSpot2 = 25;
    public int goboChannelSpot2 = 26;
    public int irisChannelSpot2 = 27;
    public Slider redSliderSpot2;
    public Slider greenSliderSpot2;
    public Slider blueSliderSpot2;

    //BEAM 1
    [Header("Beam 1 channels")]
    public int OnOffChannelBeam1 = 40;
    public int panTiltChannelBeam1 = 41;
    public int redChannelBeam1 = 42;
    public int greenChannelBeam1 = 43;
    public int blueChannelBeam1 = 44;

    //WASH 1
    [Header("Wash 1 channels")]
    public int intensityChannelWash1 = 100;
    public int panTiltChannelWash1 = 105;
    public int redChannelWash1 = 101;
    public int greenChannelWash1 = 102;
    public int blueChannelWash1 = 103;

    //WASH 2
    [Header("Wash 2 channels")]
    public int intensityChannelWash2 = 120;
    public int panTiltChannelWash2 = 125;
    public int redChannelWash2 = 121;
    public int greenChannelWash2 = 122;
    public int blueChannelWash2 = 123;

    //WASH 3
    [Header("Wash 3 channels")]
    public int intensityChannelWash3 = 140;
    public int panTiltChannelWash3 = 145;
    public int redChannelWash3 = 141;
    public int greenChannelWash3 = 142;
    public int blueChannelWash3 = 143;

    // Start is called before the first frame update
    void Start()
    {
        // Encuentra el objeto por su nombre. Asegúrate de que el nombre sea correcto.
        dmxProtocolObject = GameObject.Find("GameManager");
        colorPickerObject = GameObject.Find("Picker");

        // Verifica si se encontró el objeto y el script
        if (dmxProtocolObject != null)
        {
            dmxProtocol = dmxProtocolObject.GetComponent<DMXProtocol>();
            canvasLogic = dmxProtocolObject.GetComponent<CanvasLogic>();
            colorPicker = colorPickerObject.GetComponent<ColorPicker>();
        }
        else
        {
            Debug.LogError("Objeto DMXProtocol o CanvasLogic no encontrado.");
        }

        // Añadir listener para el evento OnPointerDown (presionar)
        UP.onClick.AddListener(() => panTiltButtons("UP"));
        DW.onClick.AddListener(() => panTiltButtons("DW"));
        LH.onClick.AddListener(() => panTiltButtons("LH"));
        RH.onClick.AddListener(() => panTiltButtons("RH"));
        ST.onClick.AddListener(() => panTiltButtons("IN"));
    }

    // Update is called once per frame
    void Update()
    {
        ChangeChannels();

        // Obtener valores actuales del color picker
        red = colorPicker.R;
        green = colorPicker.G;
        blue = colorPicker.B;

        // Verificar si se está presionando algún botón de pan/tilt
        if (upPressed || dwPressed || lhPressed || rhPressed || stPressed)
        {
            switch (panTiltDirection)
            {
                case PanTiltDirection.Up:
                    panTiltButtons("UP");
                    break;
                case PanTiltDirection.Down:
                    panTiltButtons("DW");
                    break;
                case PanTiltDirection.Left:
                    panTiltButtons("LH");
                    break;
                case PanTiltDirection.Right:
                    panTiltButtons("RH");
                    break;
                case PanTiltDirection.Init:
                    panTiltButtons("IN");
                    break;
                default:
                    panTiltButtons("ST");
                    break;
            }
        }
        else // Verificar si el color ha cambiado
        {
            if (red != redCopy || green != greenCopy || blue != blueCopy)
            {
                ChangeColor(red, green, blue);
                Debug.Log("Cambio de color: " + red + ", " + green + ", " + blue);
            }
        }

        // Actualizar las variables de copia al final de Update
        redCopy = red;
        greenCopy = green;
        blueCopy = blue;

        // Restablecer las variables de estado de botón y dirección de pan/tilt
        upPressed = dwPressed = lhPressed = rhPressed = stPressed = false;
        panTiltDirection = PanTiltDirection.None;

        if(intensitySlider.value > 0){
            onButton.gameObject.SetActive(false);
            offButton.gameObject.SetActive(true);
            Debug.Log("off");
        }
        else{
            onButton.gameObject.SetActive(true);
            offButton.gameObject.SetActive(false);
            Debug.Log("on");
        }
        
    }

    public void smoke(float value)
    {
        Debug.Log("Smoke: " + value);
        dmxProtocol.setDMXChannel(smokeChannel);
        dmxProtocol.setDMXValue((int)value);
    }

    public void smokeSpeed(float value)
    {
        Debug.Log("Smoke speed: " + value);
        dmxProtocol.setDMXChannel(smokeSpeedChannel);
        dmxProtocol.setDMXValue((int)value);
    }

    public void blinder(float value)
    {
        Debug.Log("Blinder: " + value);
        dmxProtocol.setDMXChannel(intensityChannel);
        dmxProtocol.setDMXValue((int)value);
    }

    public void strobe(float value)
    {
        Debug.Log("Strobe: " + value);
        dmxProtocol.setDMXChannel(frequencyChannelStrobe);
        dmxProtocol.setDMXValue((int)value);
    }

    public void panTiltButtons(string message)
    {
        //Debug.Log(message);
        if (message.Equals("UP"))
        {
            //Debug.Log("up aqui");
            dmxProtocol.setDMXChannel(panTiltChannel);
            dmxProtocol.setDMXValue(0);
        }
        if (message.Equals("DW"))
        {
            //Debug.Log("dw aqui");
            dmxProtocol.setDMXChannel(panTiltChannel);
            dmxProtocol.setDMXValue(1);
        }
        if (message.Equals("LH"))
        {
            //Debug.Log("lh aqui");  
            dmxProtocol.setDMXChannel(panTiltChannel);
            dmxProtocol.setDMXValue(2);
        }
        if (message.Equals("RH"))
        {
            //Debug.Log("rh aqui");
            dmxProtocol.setDMXChannel(panTiltChannel);
            dmxProtocol.setDMXValue(3);
        }
        if (message.Equals("ST"))
        {
            //Debug.Log("st aqui");
            dmxProtocol.setDMXChannel(panTiltChannel);
            dmxProtocol.setDMXValue(4);
        }
        if (message.Equals("IN")) //valor inicial, por defecto
        {
            //Debug.Log("in aqui");
            dmxProtocol.setDMXChannel(panTiltChannel);
            dmxProtocol.setDMXValue(5);
        }
    }

    //selecciono que luz quiero mover


    //--------------General scripts-----------------------------------------------------------
    private void ChangeChannels()
    {
        if (canvasLogic.groupPressed == "spot1")
        {
            intensityChannel = intensityChannelSpot1;
            redChannel = redChannelSpot1;
            greenChannel = greenChannelSpot1;
            blueChannel = blueChannelSpot1;
            shutterChannel = shutterChannelSpot1;
            panTiltChannel = panTiltChannelSpot1;
            goboChannel = goboChannelSpot1;
            irisChannel = irisChannelSpot1;
        }

        if (canvasLogic.groupPressed == "spot2")
        {
            intensityChannel = intensityChannelSpot2;
            redChannel = redChannelSpot2;
            greenChannel = greenChannelSpot2;
            blueChannel = blueChannelSpot2;
            shutterChannel = shutterChannelSpot2;
            panTiltChannel = panTiltChannelSpot2;
            goboChannel = goboChannelSpot2;
            irisChannel = irisChannelSpot2;
        }

        if (canvasLogic.groupPressed == "beam1")
        {
            intensityChannel = OnOffChannelBeam1;
            panTiltChannel = panTiltChannelBeam1;
        }

        if (canvasLogic.groupPressed == "wash1")
        {
            intensityChannel = intensityChannelWash1;
            panTiltChannel = panTiltChannelWash1;
            redChannel = redChannelWash1;
            greenChannel = greenChannelWash1;
            blueChannel = blueChannelWash1;
        }
        if (canvasLogic.groupPressed == "wash2")
        {
            intensityChannel = intensityChannelWash2;
            panTiltChannel = panTiltChannelWash2;
            redChannel = redChannelWash2;
            greenChannel = greenChannelWash2;
            blueChannel = blueChannelWash2;
        }
        if (canvasLogic.groupPressed == "wash3")
        {
            intensityChannel = intensityChannelWash3;
            panTiltChannel = panTiltChannelWash3;
            redChannel = redChannelWash3;
            greenChannel = greenChannelWash3;
            blueChannel = blueChannelWash3;
        }
        if (canvasLogic.groupPressed == "strobe")
        {
            intensityChannel = intensityChannelStrobe;
            panTiltChannel = 999;
            redChannel = 999;
            greenChannel = 999;
            blueChannel = 999;
        }
        if (canvasLogic.groupPressed == "blinder1")
        {
            intensityChannel = intensityChannelBlinder1;
        }
        if (canvasLogic.groupPressed == "blinder2")
        {
            intensityChannel = intensityChannelBlinder2;
        }
    }

    public void ChangeIntensitySlider(float value)
    {
        dmxProtocol.setDMXChannel(intensityChannel);
        dmxProtocol.setDMXValue((int)(value * 1)); //x10 porque tiene poca intensidad
        //Debug.Log("Valor de la intensidad " + canvasLogic.groupPressed + ": " + value);
    }

    public void ChangeShutterSlider(float value)
    {
        dmxProtocol.setDMXChannel(shutterChannel);
        dmxProtocol.setDMXValue((int)value);
        //Debug.Log("Valor del shutter " + canvasLogic.groupPressed + ": " + value);
    }

    public void ChangeIrisSlider(float value)
    {
        dmxProtocol.setDMXChannel(irisChannel);
        dmxProtocol.setDMXValue((int)(value));
        //Debug.Log("Valor del iris " + canvasLogic.groupPressed + ": " + value);
    }

    //funcion general, primero hay que cambiar el canal DMX para cada luz
    public void ChangeGobos(string message)
    {
        dmxProtocol.setDMXChannel(goboChannel);
        //Debug.Log("gobos aqui");
        if (message.Equals("0")) dmxProtocol.setDMXValue(0);
        if (message.Equals("1")) dmxProtocol.setDMXValue(1);
        if (message.Equals("2")) dmxProtocol.setDMXValue(2);
        if (message.Equals("3")) dmxProtocol.setDMXValue(3);
        if (message.Equals("4")) dmxProtocol.setDMXValue(4);
        if (message.Equals("5")) dmxProtocol.setDMXValue(5);
        if (message.Equals("6")) dmxProtocol.setDMXValue(6);
        if (message.Equals("7")) dmxProtocol.setDMXValue(7);
        if (message.Equals("8")) dmxProtocol.setDMXValue(8);
    }

    // public void ChangeColor(float red, float green, float blue)
    public void ChangeColor(float red, float green, float blue)
    {
        StartCoroutine(ChangeColorWithDelay(red, green, blue));
    }
    private IEnumerator ChangeColorWithDelay(float red, float green, float blue)
    {

        dmxProtocol.setDMXChannel(redChannel);
        dmxProtocol.setDMXValue((int)((float)red * 255));
        //Debug.Log("Valor en wait: "+ red + " (" + (int)((float)red*255) + ")");
        yield return new WaitForSeconds(0.01f);

        dmxProtocol.setDMXChannel(greenChannel);
        dmxProtocol.setDMXValue((int)((float)green * 255));
        //Debug.Log("Valor en wait: "+ red + " (" + (int)((float)green*255) + ")");
        yield return new WaitForSeconds(0.01f);

        dmxProtocol.setDMXChannel(blueChannel);
        dmxProtocol.setDMXValue((int)((float)blue * 255));
        //Debug.Log("Valor en wait: "+ red + " (" + (int)((float)blue*255) + ")");
        yield return new WaitForSeconds(0.01f);

        // Debug.Log("Valor del color " + canvasLogic.groupPressed + ": " + red + ", " + green + ", " + blue);
        //Debug.Log("Valor del color " + canvasLogic.groupPressed + ": " + value);
    }

    // public void selectChannelPanTiltSpot1()
    // {
    //     dmxProtocol.setDMXChannel(PantTiltChannelSpot1);
    //     Debug.Log("Poniendo spot1 canal tilt-pan");
    // }



    //--------------PAN Y TILT-----------------------------------------------------------


    private PanTiltDirection panTiltDirection = PanTiltDirection.None;

    private enum PanTiltDirection
    {
        None,
        Up,
        Down,
        Left,
        Right,
        Init
    }

    //--------------PAN Y TILT :SPOTLIGHT-----------------------------------------------------------
    public void clickUp()
    {
        upPressed = true;
        panTiltDirection = PanTiltDirection.Up;
    }

    public void releaseUp()
    {
        upPressed = true;
        if (panTiltDirection == PanTiltDirection.Up)
            panTiltDirection = PanTiltDirection.None;
    }

    public void clickDw()
    {
        dwPressed = true;
        panTiltDirection = PanTiltDirection.Down;
        //Debug.Log("clickDw");
    }

    public void releaseDw()
    {
        dwPressed = true;
        if (panTiltDirection == PanTiltDirection.Down)
            panTiltDirection = PanTiltDirection.None;
    }

    public void clickLh()
    {
        lhPressed = true;
        panTiltDirection = PanTiltDirection.Left;
    }

    public void releaseLh()
    {
        lhPressed = true;
        if (panTiltDirection == PanTiltDirection.Left)
            panTiltDirection = PanTiltDirection.None;
    }

    public void clickRh()
    {
        rhPressed = true;
        panTiltDirection = PanTiltDirection.Right;
    }

    public void releaseRh()
    {
        rhPressed = true;
        if (panTiltDirection == PanTiltDirection.Right)
            panTiltDirection = PanTiltDirection.None;
    }

    public void clickInit()
    {
        stPressed = true;
        panTiltDirection = PanTiltDirection.Init;
    }

    public void releaseInit()
    {
        stPressed = true;
        if (panTiltDirection == PanTiltDirection.Init)
            panTiltDirection = PanTiltDirection.None;
    }

    public void on()
    {
        if(valor_viejo_on != 0)
        {
            intensitySlider.value = valor_viejo_on;
        }
        else{
            intensitySlider.value = 255;
        }
        //onButton.gameObject.SetActive(false);
    }

    public void off()
    {
        valor_viejo_on = intensitySlider.value;
        intensitySlider.value = 0;
        //offButton.gameObject.SetActive(false);
    }
}