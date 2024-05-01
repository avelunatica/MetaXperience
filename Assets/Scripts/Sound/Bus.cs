using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private FMOD.Studio.Bus bus;
    public FMODUnity.EventReference myEvent; 
    private FMOD.Studio.EventInstance myEventInstance;

    //Llamada a los GO que contienen los paneles de EQ y Dynamics

    public GameObject CH1Control;
    public GameObject CH2Control;
    public GameObject CH3Control;
    public GameObject CH4Control;
    public GameObject CH5Control;
    public GameObject CH6Control;
    public GameObject ControlPanel;


    //Botones de play/stop
    public Button Play;
    public Button Stop;

    //Botones seleccion:

    public Toggle Chanel1;
    public Toggle Chanel2;
    public Toggle Chanel3;
    public Toggle Chanel4;
    public Toggle Chanel5;
    public Toggle Chanel6;


    //Sliders de volumen, reverb, y mezcla de canales 
    public Slider masterSlider;
    public Slider reverbValue;
    public Slider CH1Slider;
    public Slider CH2Slider;
    public Slider CH3Slider;
    public Slider CH4Slider;
    public Slider CH5Slider;
    public Slider CH6Slider;
    
    //Sliders Compresion:
    public Slider threshold1Slider, threshold2Slider, threshold3Slider, threshold4Slider, threshold5Slider, threshold6Slider;
    public Slider ratio1Slider, ratio2Slider, ratio3Slider, ratio4Slider, ratio5Slider, ratio6Slider;

    //Sliders Ecualizacion:
    public Slider LowGain1Slider, LowGain2Slider, LowGain3Slider, LowGain4Slider, LowGain5Slider, LowGain6Slider;
    public Slider LowFreq1Slider, LowFreq2Slider, LowFreq3Slider, LowFreq4Slider, LowFreq5Slider, LowFreq6Slider;
    public Slider MidGain1Slider, MidGain2Slider, MidGain3Slider, MidGain4Slider, MidGain5Slider, MidGain6Slider;
    public Slider MidFreq1Slider, MidFreq2Slider, MidFreq3Slider, MidFreq4Slider, MidFreq5Slider, MidFreq6Slider;
    public Slider HiGain1Slider, HiGain2Slider, HiGain3Slider, HiGain4Slider, HiGain5Slider, HiGain6Slider;
    public Slider HiFreq1Slider, HiFreq2Slider, HiFreq3Slider, HiFreq4Slider, HiFreq5Slider, HiFreq6Slider;

    //Botones Mute/Solo;
    public Toggle Mute1;
    public Toggle Mute2;
    public Toggle Mute3;
    public Toggle Mute4;
    public Toggle Mute5;
    public Toggle Mute6;
    public Toggle MuteR;
    public Toggle MuteM;

    //Solos:
    public Toggle Solo1;
    public Toggle Solo2;
    public Toggle Solo3;
    public Toggle Solo4;
    public Toggle Solo5;
    public Toggle Solo6;

    void Start()
    {
        // Obtener el bus Master
        bus = RuntimeManager.GetBus("bus:/Master");

        // Crear una instancia del evento
        myEventInstance = RuntimeManager.CreateInstance(myEvent);

        // Agregar listeners a los botones
        Play.onClick.AddListener(OnClickPlay);
        Stop.onClick.AddListener(OnClickStop);
        
        // Agregar un listener al slider para actualizar el volumen
        masterSlider.onValueChanged.AddListener(OnVolumeChanged);
        reverbValue.onValueChanged.AddListener(OnReverbValueChanged);
        CH1Slider.onValueChanged.AddListener(OnCH1Changed);
        CH2Slider.onValueChanged.AddListener(OnCH2Changed);
        CH3Slider.onValueChanged.AddListener(OnCH3Changed);
        CH4Slider.onValueChanged.AddListener(OnCH4Changed);
        CH5Slider.onValueChanged.AddListener(OnCH5Changed);
        CH6Slider.onValueChanged.AddListener(OnCH6Changed);
        


        // Actualizar los parámetros de compresion
        threshold1Slider.onValueChanged.AddListener(OnThreshold1Changed);
        threshold2Slider.onValueChanged.AddListener(OnThreshold2Changed);
        threshold3Slider.onValueChanged.AddListener(OnThreshold3Changed);
        threshold4Slider.onValueChanged.AddListener(OnThreshold4Changed);
        threshold5Slider.onValueChanged.AddListener(OnThreshold5Changed);
        threshold6Slider.onValueChanged.AddListener(OnThreshold6Changed);

        ratio1Slider.onValueChanged.AddListener(OnRatio1Changed);
        ratio2Slider.onValueChanged.AddListener(OnRatio2Changed);
        ratio3Slider.onValueChanged.AddListener(OnRatio3Changed);
        ratio4Slider.onValueChanged.AddListener(OnRatio4Changed);
        ratio5Slider.onValueChanged.AddListener(OnRatio5Changed);
        ratio6Slider.onValueChanged.AddListener(OnRatio6Changed);


        //Actualizar parámetros de la EQ
        LowGain1Slider.onValueChanged.AddListener(OnLowGain1Changed);
        LowGain1Slider.onValueChanged.AddListener(OnLowGain2Changed);
        LowGain1Slider.onValueChanged.AddListener(OnLowGain3Changed);
        LowGain1Slider.onValueChanged.AddListener(OnLowGain4Changed);
        LowGain1Slider.onValueChanged.AddListener(OnLowGain5Changed);
        LowGain1Slider.onValueChanged.AddListener(OnLowGain6Changed);

        LowFreq1Slider.onValueChanged.AddListener(OnLowFreq1Changed);
        LowFreq2Slider.onValueChanged.AddListener(OnLowFreq2Changed);
        LowFreq3Slider.onValueChanged.AddListener(OnLowFreq3Changed);
        LowFreq4Slider.onValueChanged.AddListener(OnLowFreq4Changed);
        LowFreq5Slider.onValueChanged.AddListener(OnLowFreq5Changed);
        LowFreq6Slider.onValueChanged.AddListener(OnLowFreq6Changed);

        MidGain1Slider.onValueChanged.AddListener(OnMidGain1Changed);
        MidGain2Slider.onValueChanged.AddListener(OnMidGain2Changed);
        MidGain3Slider.onValueChanged.AddListener(OnMidGain3Changed);
        MidGain4Slider.onValueChanged.AddListener(OnMidGain4Changed);
        MidGain5Slider.onValueChanged.AddListener(OnMidGain5Changed);
        MidGain6Slider.onValueChanged.AddListener(OnMidGain6Changed);
        
        MidFreq1Slider.onValueChanged.AddListener(OnMidFreq1Changed);
        MidFreq2Slider.onValueChanged.AddListener(OnMidFreq2Changed);
        MidFreq3Slider.onValueChanged.AddListener(OnMidFreq3Changed);
        MidFreq4Slider.onValueChanged.AddListener(OnMidFreq4Changed);
        MidFreq5Slider.onValueChanged.AddListener(OnMidFreq5Changed);
        MidFreq6Slider.onValueChanged.AddListener(OnMidFreq6Changed);

        HiGain1Slider.onValueChanged.AddListener(OnHiGain1Changed);
        HiGain2Slider.onValueChanged.AddListener(OnHiGain2Changed);
        HiGain3Slider.onValueChanged.AddListener(OnHiGain3Changed);
        HiGain4Slider.onValueChanged.AddListener(OnHiGain4Changed);
        HiGain5Slider.onValueChanged.AddListener(OnHiGain5Changed);
        HiGain6Slider.onValueChanged.AddListener(OnHiGain6Changed);

        HiFreq1Slider.onValueChanged.AddListener(OnHiFreq1Changed);
        HiFreq2Slider.onValueChanged.AddListener(OnHiFreq2Changed);
        HiFreq3Slider.onValueChanged.AddListener(OnHiFreq3Changed);
        HiFreq4Slider.onValueChanged.AddListener(OnHiFreq4Changed);
        HiFreq5Slider.onValueChanged.AddListener(OnHiFreq5Changed);
        HiFreq6Slider.onValueChanged.AddListener(OnHiFreq6Changed);



        //Llamadas a funcion Mute
        Mute1.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute1, "Drum_Mute", 1));
        Mute2.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute2, "Bass_Mute", 1));
        Mute3.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute3, "Guit_Mute", 1));
        Mute4.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute4, "Hamm_Mute", 1));
        Mute5.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute5, "Voz_Mute", 1));
        Mute6.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute6, "Chor_Mute", 1));


        //Llamadas a funcion Solo
        Solo1.onValueChanged.AddListener((bool isOn) => Solo1Function(isOn));
        Solo2.onValueChanged.AddListener((bool isOn) => Solo2Function(isOn));
        Solo3.onValueChanged.AddListener((bool isOn) => Solo3Function(isOn));
        Solo4.onValueChanged.AddListener((bool isOn) => Solo4Function(isOn));
        Solo5.onValueChanged.AddListener((bool isOn) => Solo5Function(isOn));
        Solo6.onValueChanged.AddListener((bool isOn) => Solo6Function(isOn));

        //Llamadas a seleccion canal
        Chanel1.onValueChanged.AddListener((bool isOn) => ChanelControl(isOn));
        Chanel2.onValueChanged.AddListener((bool isOn) => ChanelControl(isOn));
        Chanel3.onValueChanged.AddListener((bool isOn) => ChanelControl(isOn));
        Chanel4.onValueChanged.AddListener((bool isOn) => ChanelControl(isOn));
        Chanel5.onValueChanged.AddListener((bool isOn) => ChanelControl(isOn));
        Chanel6.onValueChanged.AddListener((bool isOn) => ChanelControl(isOn));

        CH1Control.SetActive(false);
        CH2Control.SetActive(false);
        CH3Control.SetActive(false);
        CH4Control.SetActive(false);
        CH5Control.SetActive(false);
        CH6Control.SetActive(false);
        ControlPanel.SetActive(true);



    }

//---------------------------------------------------------------------------------------------------------- 

    //Start/Stop de la reproduccion
        void OnClickPlay()
    {
        // Inicia la instancia del evento
        myEventInstance.start();
    }

    void OnClickStop()
    {
        // Detiene la instancia del evento inmediatamente
        myEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

//----------------------------------------------------------------------------------------------------------

    // Métodos para cambiar los volumenes
    void OnVolumeChanged(float volume)
    {
        // Actualiza el volumen del bus según el valor del slider
        bus.setVolume(DecibelToLinear(volume));
    }
    void OnCH1Changed(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Drums", volume);
    }
    void OnCH2Changed(float volume)
    {
        myEventInstance.setParameterByName("Volume_Bass", volume);
    }
    void OnCH3Changed(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Guit", volume);
    }
    void OnCH4Changed(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Hamm", volume);
    }
    void OnCH5Changed(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Voz", volume);
    }
    void OnCH6Changed(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Chor", volume);
    }
//----------------------------------------------------------------------------------------------------------
        void OnReverbValueChanged(float volume)
    {
        myEventInstance.setParameterByName("Reverb_Send", volume);
    }
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
    void OnThreshold1Changed(float value)
    {
            myEventInstance.setParameterByName("Drum_Threshold", value);
    }
    void OnThreshold2Changed(float value)
    {
            myEventInstance.setParameterByName("Bass_Threshold", value);
    }
    void OnThreshold3Changed(float value)
    {
            myEventInstance.setParameterByName("Guit_Threshold", value);
    }
    void OnThreshold4Changed(float value)
    {
            myEventInstance.setParameterByName("Hamm_Threshold", value);
    }
    void OnThreshold5Changed(float value)
    {
            myEventInstance.setParameterByName("Voz_Threshold", value);
    }
    void OnThreshold6Changed(float value)
    {
            myEventInstance.setParameterByName("Chor_Threshold", value);
    }
//----------------------------------------------------------------------------------------------------------
    void OnRatio1Changed(float value)
    {
        myEventInstance.setParameterByName("Drum_Ratio", value);
    }
    void OnRatio2Changed(float value)
    {
        myEventInstance.setParameterByName("Bass_Ratio", value);
    }
    void OnRatio3Changed(float value)
    {
        myEventInstance.setParameterByName("Guit_Ratio", value);
    }
    void OnRatio4Changed(float value)
    {
        myEventInstance.setParameterByName("Hamm_Ratio", value);
    }
    void OnRatio5Changed(float value)
    {
        myEventInstance.setParameterByName("Voz_Ratio", value);
    }
    void OnRatio6Changed(float value)
    {
        myEventInstance.setParameterByName("Chor_Ratio", value);
    }
//----------------------------------------------------------------------------------------------------------
    void OnLowGain1Changed(float value)
    {
        myEventInstance.setParameterByName("Drum_LFG", value);
    }
    void OnLowGain2Changed(float value)
    {
        myEventInstance.setParameterByName("Bass_LFG", value);
    }
    void OnLowGain3Changed(float value)
    {
        myEventInstance.setParameterByName("Guit_LFG", value);
    }
    void OnLowGain4Changed(float value)
    {
        myEventInstance.setParameterByName("Hamm_LFG", value);
    }
    void OnLowGain5Changed(float value)
    {
        myEventInstance.setParameterByName("Voz_LFG", value);
    }
    void OnLowGain6Changed(float value)
    {
        myEventInstance.setParameterByName("Chor_LFG", value);
    }
//-----------------------------------------------------------------------------------------------------------
    void OnLowFreq1Changed(float value)
    {
        myEventInstance.setParameterByName("Drum_LF", value);
    }
    void OnLowFreq2Changed(float value)
    {
        myEventInstance.setParameterByName("Bass_LF", value);
    }
    void OnLowFreq3Changed(float value)
    {
        myEventInstance.setParameterByName("Guit_LF", value);
    }
    void OnLowFreq4Changed(float value)
    {
        myEventInstance.setParameterByName("Hamm_LF", value);
    }
    void OnLowFreq5Changed(float value)
    {
        myEventInstance.setParameterByName("Voz_LF", value);
    }
    void OnLowFreq6Changed(float value)
    {
        myEventInstance.setParameterByName("Chor_LF", value);
    }
//----------------------------------------------------------------------------------------------------------

    void OnMidGain1Changed(float value)
    {
        myEventInstance.setParameterByName("Drum_MFG", value);
    }
    void OnMidGain2Changed(float value)
    {
        myEventInstance.setParameterByName("Bass_MFG", value);
    }
    void OnMidGain3Changed(float value)
    {
        myEventInstance.setParameterByName("Guit_MFG", value);
    }
    void OnMidGain4Changed(float value)
    {
        myEventInstance.setParameterByName("Hamm_MFG", value);
    }
    void OnMidGain5Changed(float value)
    {
        myEventInstance.setParameterByName("Voz_MFG", value);
    }
    void OnMidGain6Changed(float value)
    {
        myEventInstance.setParameterByName("Chor_MFG", value);
    }
//----------------------------------------------------------------------------------------------------------

    void OnMidFreq1Changed(float value)
    {
        myEventInstance.setParameterByName("Drum_MF", value);
    }
    void OnMidFreq2Changed(float value)
    {
        myEventInstance.setParameterByName("Bass_MF", value);
    }
    void OnMidFreq3Changed(float value)
    {
        myEventInstance.setParameterByName("Guit_MF", value);
    }
    void OnMidFreq4Changed(float value)
    {
        myEventInstance.setParameterByName("Hamm_MF", value);
    }
    void OnMidFreq5Changed(float value)
    {
        myEventInstance.setParameterByName("Voz_MF", value);
    }
    void OnMidFreq6Changed(float value)
    {
        myEventInstance.setParameterByName("Chor_MF", value);
    }
//----------------------------------------------------------------------------------------------------------

    void OnHiGain1Changed(float value)
    {
        myEventInstance.setParameterByName("Drum_HFG", value);
    }
    void OnHiGain2Changed(float value)
    {
        myEventInstance.setParameterByName("Bass_HFG", value);
    }
    void OnHiGain3Changed(float value)
    {
        myEventInstance.setParameterByName("Guit_HFG", value);
    }
    void OnHiGain4Changed(float value)
    {
        myEventInstance.setParameterByName("Hamm_HFG", value);
    }
    void OnHiGain5Changed(float value)
    {
        myEventInstance.setParameterByName("Voz_HFG", value);
    }
    void OnHiGain6Changed(float value)
    {
        myEventInstance.setParameterByName("Chor_HFG", value);
    }
//----------------------------------------------------------------------------------------------------------

    void OnHiFreq1Changed(float value)
    {
        myEventInstance.setParameterByName("Drum_HF", value);
    }
    void OnHiFreq2Changed(float value)
    {
        myEventInstance.setParameterByName("Bass_HF", value);
    }
    void OnHiFreq3Changed(float value)
    {
        myEventInstance.setParameterByName("Guit_HF", value);
    }
    void OnHiFreq4Changed(float value)
    {
        myEventInstance.setParameterByName("Hamm_HF", value);
    }
    void OnHiFreq5Changed(float value)
    {
        myEventInstance.setParameterByName("Voz_HF", value);
    }
    void OnHiFreq6Changed(float value)
    {
        myEventInstance.setParameterByName("Chor_HF", value);
    }
//----------------------------------------------------------------------------------------------------------
    //Metodo de selección de canal

void ChanelControl(bool isOn)
{
    // Obtener el Toggle que activó el evento
    Toggle toggle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Toggle>();

    // Comprobar qué canal se activó
    switch (toggle.gameObject.name)
    {
        case "Select1":
            if (isOn)
            {
                CH1Control.SetActive(true);
                CH2Control.SetActive(false);
                CH3Control.SetActive(false);
                CH4Control.SetActive(false);
                CH5Control.SetActive(false);
                CH6Control.SetActive(false);
                ControlPanel.SetActive(false);

            }
            break;
        case "Select2":
            if (isOn)
            {
                CH1Control.SetActive(false);
                CH2Control.SetActive(true);
                CH3Control.SetActive(false);
                CH4Control.SetActive(false);
                CH5Control.SetActive(false);
                CH6Control.SetActive(false);
                ControlPanel.SetActive(false);
            }
            break;
        case "Select3":
            if (isOn)
            {
                CH1Control.SetActive(false);
                CH2Control.SetActive(false);
                CH3Control.SetActive(true);
                CH4Control.SetActive(false);
                CH5Control.SetActive(false);
                CH6Control.SetActive(false);
                ControlPanel.SetActive(false);
            }
            break;
        case "Select4":
            if (isOn)
            {
                CH1Control.SetActive(false);
                CH2Control.SetActive(false);
                CH3Control.SetActive(false);
                CH4Control.SetActive(true);
                CH5Control.SetActive(false);
                CH6Control.SetActive(false);
                ControlPanel.SetActive(false);
            }
            break;
        case "Select5":
            if (isOn)
            {
                CH1Control.SetActive(false);
                CH2Control.SetActive(false);
                CH3Control.SetActive(false);
                CH4Control.SetActive(false);
                CH5Control.SetActive(true);
                CH6Control.SetActive(false);
                ControlPanel.SetActive(false);
            }
            break;
        case "Select6":
            if (isOn)
            {
                CH1Control.SetActive(false);
                CH2Control.SetActive(false);
                CH3Control.SetActive(false);
                CH4Control.SetActive(false);
                CH5Control.SetActive(false);
                CH6Control.SetActive(true);
                ControlPanel.SetActive(false);
            }
            break;
        // Agregar más casos para los otros canales si es necesario
        default:
                CH1Control.SetActive(false);
                CH2Control.SetActive(false);
                CH3Control.SetActive(false);
                CH4Control.SetActive(false);
                CH5Control.SetActive(false);
                CH6Control.SetActive(false);
                ControlPanel.SetActive(true);
            break;
    }
}




//----------------------------------------------------------------------------------------------------------
    //Método para los mutes:
    void SetInstrumentMute(Toggle toggle, string paramName, int muteValue)
    {
        if (toggle.isOn)
        {
            myEventInstance.setParameterByName(paramName, muteValue);
        }
        else
        {
            myEventInstance.setParameterByName(paramName, 0);
        }
    }


//----------------------------------------------------------------------------------------------------------
    //Metodo para los solos:
    void Solo1Function(bool isOn)
    {
        if (Solo1.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo2Function(bool isOn)
    {
        if (Solo2.isOn)
        {
            Mute1.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute1.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo3Function(bool isOn)
    {
        if (Solo3.isOn)
        {
            Mute2.isOn = true;
            Mute1.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute1.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo4Function(bool isOn)
    {
        if (Solo4.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute1.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute1.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo5Function(bool isOn)
    {
        if (Solo5.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute1.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute1.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo6Function(bool isOn)
    {
        if (Solo6.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute1.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute1.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
        }
    }


    // Método para convertir decibelios a lineales
    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20f);
        return linear;
    }
}



/* using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private FMOD.Studio.Bus bus;
    public FMODUnity.EventReference myEvent; 
    private FMOD.Studio.EventInstance myEventInstance;

    //Botones de play/stop
    public Button Play;
    public Button Stop;

    //Botones mute;

    //Botones seleccion:

    public Toggle Chanel1;
    public Toggle Chanel2;
    public Toggle Chanel3;
    public Toggle Chanel4;
    public Toggle Chanel5;
    public Toggle Chanel6;


    //Sliders de volumen, reverb, y mezcla de canales 
    public Slider volumeSlider;
    public Slider drumVolumeSlider;
    public Slider bassVolumeSlider;
    public Slider guitVolumeSlider;
    public Slider hammondVolumeSlider;
    public Slider voiceVolumeSlider;
    public Slider chordsVolumeSlider;
    public Slider reverbValue;
    //Sliders Compresion:
    public Slider thresholdSlider;
    public Slider ratioSlider;

    //Sliders Ecualizacion:
    public Slider LowGainSlider;
    public Slider LowFreqSlider;
    public Slider MidGainSlider;
    public Slider MidFreqSlider;
    public Slider HiGainSlider;
    public Slider HiFreqSlider;

    //Botones Mute/Solo;

    public Toggle Mute1;
    public Toggle Mute2;
    public Toggle Mute3;
    public Toggle Mute4;
    public Toggle Mute5;
    public Toggle Mute6;
    public Toggle MuteR;
    public Toggle MuteM;
    //Solos:
    public Toggle Solo1;
    public Toggle Solo2;
    public Toggle Solo3;
    public Toggle Solo4;
    public Toggle Solo5;
    public Toggle Solo6;

    void Start()
    {
        // Obtener el bus Master
        bus = RuntimeManager.GetBus("bus:/Master");

        // Crear una instancia del evento
        myEventInstance = RuntimeManager.CreateInstance(myEvent);

        // Agregar listeners a los botones
        Play.onClick.AddListener(OnClickPlay);
        Stop.onClick.AddListener(OnClickStop);
        
        // Agregar un listener al slider para actualizar el volumen
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        drumVolumeSlider.onValueChanged.AddListener(OnDrumsVolumeChanged);
        bassVolumeSlider.onValueChanged.AddListener(OnBassVolumeChanged);
        guitVolumeSlider.onValueChanged.AddListener(OnGuitVolumeChanged);
        hammondVolumeSlider.onValueChanged.AddListener(OnHammVolumeChanged);
        voiceVolumeSlider.onValueChanged.AddListener(OnVoiceVolumeChanged);
        chordsVolumeSlider.onValueChanged.AddListener(OnChordsVolumeChanged);
        reverbValue.onValueChanged.AddListener(OnReverbValueChanged);


        // Actualizar los parámetros de compresion
        thresholdSlider.onValueChanged.AddListener(OnThresholdChanged);
        ratioSlider.onValueChanged.AddListener(OnRatioChanged);


        //Actualizar parámetros de la EQ
        LowGainSlider.onValueChanged.AddListener(OnLowGainChanged);
        LowFreqSlider.onValueChanged.AddListener(OnLowFreqChanged);
        MidGainSlider.onValueChanged.AddListener(OnMidGainChanged);
        MidFreqSlider.onValueChanged.AddListener(OnMidFreqChanged);
        HiGainSlider.onValueChanged.AddListener(OnHiGainChanged);
        HiFreqSlider.onValueChanged.AddListener(OnHiFreqChanged);


        //Llamadas a funcion Mute
        Mute1.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute1, "Drum_Mute", 1));
        Mute2.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute2, "Bass_Mute", 1));
        Mute3.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute3, "Guit_Mute", 1));
        Mute4.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute4, "Hamm_Mute", 1));
        Mute5.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute5, "Voz_Mute", 1));
        Mute6.onValueChanged.AddListener((bool isOn) => SetInstrumentMute(Mute6, "Chor_Mute", 1));


        //Llamadas a funcion Solo
        Solo1.onValueChanged.AddListener((bool isOn) => Solo1Function(isOn));
        Solo2.onValueChanged.AddListener((bool isOn) => Solo2Function(isOn));
        Solo3.onValueChanged.AddListener((bool isOn) => Solo3Function(isOn));
        Solo4.onValueChanged.AddListener((bool isOn) => Solo4Function(isOn));
        Solo5.onValueChanged.AddListener((bool isOn) => Solo5Function(isOn));
        Solo6.onValueChanged.AddListener((bool isOn) => Solo6Function(isOn));


    }

    //------------------------------------------------------------------------------------------------------------------------------------------------------------- <summary>
 

    //Start/Stop de la reproduccion
        void OnClickPlay()
    {
        // Inicia la instancia del evento
        myEventInstance.start();
    }

    void OnClickStop()
    {
        // Detiene la instancia del evento inmediatamente
        myEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    ///-------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Métodos para cambiar los volumenes
    void OnVolumeChanged(float volume)
    {
        // Actualiza el volumen del bus según el valor del slider
        bus.setVolume(DecibelToLinear(volume));
    }
    void OnDrumsVolumeChanged(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Drums", volume);
    }

    void OnBassVolumeChanged(float volume)
    {
        myEventInstance.setParameterByName("Volume_Bass", volume);
    }
    void OnGuitVolumeChanged(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Guit", volume);
    }
    void OnHammVolumeChanged(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Hamm", volume);
    }
    void OnVoiceVolumeChanged(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Voz", volume);
    }
    void OnChordsVolumeChanged(float volume)
    {
        myEventInstance.setParameterByName("Volumen_Chor", volume);
    }
        void OnReverbValueChanged(float volume)
    {
        myEventInstance.setParameterByName("Reverb_Send", volume);
    }
    ///-------------------------------------------------------------------------------------------------------------------------------------------------------------

    void OnThresholdChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_Threshold", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_Threshold", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_Threshold", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_Threshold", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_Threshold", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_Threshold", value);
        }
    }
    
    void OnRatioChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_Ratio", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_Ratio", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_Ratio", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_Ratio", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_Ratio", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_Ratio", value);
        }
    }


    void OnLowGainChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_LFG", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_LFG", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_LFG", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_LFG", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_LFG", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_LFG", value);
        }
    }

    void OnLowFreqChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_LF", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_LF", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_LF", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_LF", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_LF", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_LF", value);
        }
    }

    void OnMidGainChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_MFG", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_MFG", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_MFG", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_MFG", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_MFG", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_MFG", value);
        }
    }

    void OnMidFreqChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_MF", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_MF", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_MF", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_MF", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_MF", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_MF", value);
        }
    }

    void OnHiGainChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_HFG", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_HFG", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_HFG", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_HFG", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_HFG", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_HFG", value);
        }
    }

    void OnHiFreqChanged(float value)
    {
        if (Chanel1.isOn)
        {
            myEventInstance.setParameterByName("Drum_HF", value);
        }
        else if (Chanel2.isOn)
        {
            myEventInstance.setParameterByName("Bass_HF", value);
        }
        else if (Chanel3.isOn)
        {
            myEventInstance.setParameterByName("Guit_HF", value);
        }
        else if (Chanel4.isOn)
        {
            myEventInstance.setParameterByName("Hamm_HF", value);
        }
        else if (Chanel5.isOn)
        {
            myEventInstance.setParameterByName("Voz_HF", value);
        }
        else if (Chanel6.isOn)
        {
            myEventInstance.setParameterByName("Chor_HF", value);
        }
    }

    //Método para los mutes:
    void SetInstrumentMute(Toggle toggle, string paramName, int muteValue)
    {
        if (toggle.isOn)
        {
            myEventInstance.setParameterByName(paramName, muteValue);
        }
        else
        {
            myEventInstance.setParameterByName(paramName, 0);
        }
    }

    //Metodo para los solos:
    void Solo1Function(bool isOn)
    {
        if (Solo1.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo2Function(bool isOn)
    {
        if (Solo2.isOn)
        {
            Mute1.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute1.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo3Function(bool isOn)
    {
        if (Solo3.isOn)
        {
            Mute2.isOn = true;
            Mute1.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute1.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo4Function(bool isOn)
    {
        if (Solo4.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute1.isOn = true;
            Mute5.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute1.isOn = false;
            Mute5.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo5Function(bool isOn)
    {
        if (Solo5.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute1.isOn = true;
            Mute6.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
            SetInstrumentMute(Mute6, "Chor_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute1.isOn = false; 
            Mute6.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
            SetInstrumentMute(Mute6, "Chor_Mute", 0);
        }
    }
    void Solo6Function(bool isOn)
    {
        if (Solo6.isOn)
        {
            Mute2.isOn = true;
            Mute3.isOn = true;
            Mute4.isOn = true;
            Mute5.isOn = true;
            Mute1.isOn = true;
            // Poner en mute los canales correspondientes al Solo1
            SetInstrumentMute(Mute2, "Bass_Mute", 1);
            SetInstrumentMute(Mute3, "Guit_Mute", 1);
            SetInstrumentMute(Mute4, "Hamm_Mute", 1);
            SetInstrumentMute(Mute5, "Voz_Mute", 1);
            SetInstrumentMute(Mute1, "Drum_Mute", 1);
        }
        else
        {
            Mute2.isOn = false;
            Mute3.isOn = false;
            Mute4.isOn = false;
            Mute5.isOn = false; 
            Mute1.isOn = false;
            // Restaurar los mutes de los canales que no están en solo
            SetInstrumentMute(Mute2, "Bass_Mute", 0);
            SetInstrumentMute(Mute3, "Guit_Mute", 0);
            SetInstrumentMute(Mute4, "Hamm_Mute", 0);
            SetInstrumentMute(Mute5, "Voz_Mute", 0);
            SetInstrumentMute(Mute1, "Drum_Mute", 0);
        }
    }


    // Método para convertir decibelios a lineales
    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10.0f, dB / 20f);
        return linear;
    }
}

 */