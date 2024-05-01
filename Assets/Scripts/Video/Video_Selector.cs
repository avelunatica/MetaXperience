using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VVideoSelector : MonoBehaviour
{
    public Toggle lMainToggle;
    public Toggle rMainToggle;
    public Toggle lSecToggle;
    public Toggle rSecToggle;
    public Button[] cameraButtons;
    public Button[] videoButtons;

    public Button OnOff;
    public GameObject LEDPanelL;
    public GameObject LEDPanelR;
    public GameObject LEDsecL;
    public GameObject LEDsecR;
     public GameObject MovingCamera1;
    public GameObject MovingCamera2;


    public Material[] proyeccionMaterials; // Materiales 1 al 4

    private int selectedMaterialIndex = 0; // Índice del material seleccionado

    private VideoPlayer ledPanelLVideoPlayer;
    private VideoPlayer ledPanelRVideoPlayer;
    private VideoPlayer ledSecLVideoPlayer;
    private VideoPlayer ledSecRVideoPlayer;
    private bool clickedOnce = false;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public float speed = 0.5f;

    private float t1 = 0.0f;
    private float t2 = 0.0f;

    void Start()
    {

        // Desactivar las pantallas LEDsecL y LEDsecR al inicio
        LEDsecL.SetActive(false);
        LEDsecR.SetActive(false);


        // Asignar métodos de eventos para el toggle L-MAIN
        lMainToggle.onValueChanged.AddListener(OnLMainToggleValueChanged);
        rMainToggle.onValueChanged.AddListener(OnRMainToggleValueChanged);
        lSecToggle.onValueChanged.AddListener((bool isOn) => OnLSecToggleValueChanged(isOn));
        rSecToggle.onValueChanged.AddListener((bool isOn) => OnRSecToggleValueChanged(isOn));

        OnOff.onClick.AddListener(turnOff);

        // Asignar métodos de eventos para los botones de cámara
        for (int i = 0; i < cameraButtons.Length; i++)
        {
            int index = i + 1; // Índice del botón (1-based)
            cameraButtons[i].onClick.AddListener(() => OnCameraButtonClicked(index));
        }
        // Asignar métodos de eventos para los botones de video
        for (int i = 0; i < videoButtons.Length; i++)
        {
            int index = i;
            videoButtons[i].onClick.AddListener(() => OnVideoButtonClicked(index));
        }

        // Obtener los VideoPlayers de cada pantalla LED
        ledPanelLVideoPlayer = LEDPanelL.GetComponent<VideoPlayer>();
        ledPanelRVideoPlayer = LEDPanelR.GetComponent<VideoPlayer>();
        ledSecLVideoPlayer = LEDsecL.GetComponent<VideoPlayer>();
        ledSecRVideoPlayer = LEDsecR.GetComponent<VideoPlayer>();

        if (ledPanelLVideoPlayer == null || ledPanelRVideoPlayer == null || ledSecLVideoPlayer == null || ledSecRVideoPlayer == null)
        {
            Debug.LogError("No se encontró el componente VideoPlayer en este GameObject.");
        }

        ledPanelLVideoPlayer.enabled = false;
        ledPanelRVideoPlayer.enabled = false;
        ledSecLVideoPlayer.enabled = false;
        ledSecRVideoPlayer.enabled = false;


    }

    void turnOff()
    {
        if(rSecToggle.isOn)
        {
            LEDsecR.SetActive(false);
        }
        if(lSecToggle.isOn)
        {
            LEDsecL.SetActive(false);
        }
    }

    void OnLMainToggleValueChanged(bool value)
    {
        if (value)
        {
            // Si el toggle L-MAIN se activa, aplicar el material seleccionado
            ApplyMaterialLMain(selectedMaterialIndex);
        }
    }
    void OnRMainToggleValueChanged(bool value)
    {
        if (value)
        {
            // Si el toggle R-MAIN se activa, aplicar el material seleccionado
            ApplyMaterialRMain(selectedMaterialIndex);
        }
    }
    void OnLSecToggleValueChanged(bool isOn)
    {
        if (lSecToggle.isOn)
        {
            LEDsecL.SetActive(true);ApplyMaterialLSec(selectedMaterialIndex);
            
        }
    }
    void OnRSecToggleValueChanged(bool isOn)
    {
        if (rSecToggle.isOn)
        {
            LEDsecR.SetActive(true);ApplyMaterialRSec(selectedMaterialIndex);
        }
        }
    

    void OnCameraButtonClicked(int buttonIndex)
    {
        // Actualizar el índice del material seleccionado según el botón de cámara presionado
        selectedMaterialIndex = buttonIndex - 1;
        
        // Si el toggle L-MAIN está activado, aplicar el material seleccionado
        if (lMainToggle.isOn)
        {
            ledPanelLVideoPlayer.enabled = false;
            ApplyMaterialLMain(selectedMaterialIndex);
        }
        if (rMainToggle.isOn)
        {
            ledPanelRVideoPlayer.enabled = false;
            ApplyMaterialRMain(selectedMaterialIndex);
        }
        if (lSecToggle.isOn)
        {
            
            ledSecLVideoPlayer.enabled = false;
            ApplyMaterialLSec(selectedMaterialIndex);
        }
        if (rSecToggle.isOn)
        {
            
            ledSecRVideoPlayer.enabled = false;
            ApplyMaterialRSec(selectedMaterialIndex);
        }

    }

    void OnVideoButtonClicked(int buttonIndex)
    {
        // Reproducir el video correspondiente al botón de video seleccionado en cada pantalla LED
        if (lMainToggle.isOn)
        {
            ledPanelLVideoPlayer.enabled = true;
            PlayVideoOnLED(ledPanelLVideoPlayer, buttonIndex);
        }
        if (rMainToggle.isOn)
        {
            ledPanelRVideoPlayer.enabled = true;
            PlayVideoOnLED(ledPanelRVideoPlayer, buttonIndex);
        }
        if (lSecToggle.isOn)
        {
            LEDsecL.SetActive(true);
            ledSecLVideoPlayer.enabled = true;
            PlayVideoOnLED(ledSecLVideoPlayer, buttonIndex);
        }
        if (rSecToggle.isOn)
        {
            LEDsecR.SetActive(true);
            ledSecRVideoPlayer.enabled = true;
            PlayVideoOnLED(ledSecRVideoPlayer, buttonIndex);
        }
    }


    void ApplyMaterialLMain(int materialIndex)
    {
        // Verificar que el índice del material esté dentro del rango de materiales disponibles
        if (materialIndex >= 0 && materialIndex < proyeccionMaterials.Length)
        {
            // Obtener el componente Renderer del panel LEDPanelL
            Renderer ledPanelLRenderer = LEDPanelL.GetComponent<Renderer>();

            // Aplicar el material seleccionado al panel LEDPanelL
            ledPanelLRenderer.material = proyeccionMaterials[materialIndex];
        }
        else
        {
            Debug.LogError("Índice de material seleccionado fuera de rango.");
        }
    }

    void ApplyMaterialRMain(int materialIndex)
    {
        // Verificar que el índice del material esté dentro del rango de materiales disponibles
        if (materialIndex >= 0 && materialIndex < proyeccionMaterials.Length)
        {
            // Obtener el componente Renderer del panel LEDPanelR
            Renderer ledPanelRRenderer = LEDPanelR.GetComponent<Renderer>();

            // Aplicar el material seleccionado al panel LEDPanelR
            ledPanelRRenderer.material = proyeccionMaterials[materialIndex];
        }
        else
        {
            Debug.LogError("Índice de material seleccionado fuera de rango.");
        }
    }

    void ApplyMaterialLSec(int materialIndex)
    {
        // Verificar que el índice del material esté dentro del rango de materiales disponibles
        if (materialIndex >= 0 && materialIndex < proyeccionMaterials.Length)
        {
            // Obtener el componente Renderer del panel LEDSecL
            Renderer LEDSecLRenderer = LEDsecL.GetComponent<Renderer>();

            // Aplicar el material seleccionado al panel LEDSecL
            LEDSecLRenderer.material = proyeccionMaterials[materialIndex];
        }
        else
        {
            Debug.LogError("Índice de material seleccionado fuera de rango.");
        }
    }

    void ApplyMaterialRSec(int materialIndex)
    {
        // Verificar que el índice del material esté dentro del rango de materiales disponibles
        if (materialIndex >= 0 && materialIndex < proyeccionMaterials.Length)
        {
            // Obtener el componente Renderer del panel LEDSecR
            Renderer LEDsecRRenderer = LEDsecR.GetComponent<Renderer>();

            // Aplicar el material seleccionado al panel LEDSecR
            LEDsecRRenderer.material = proyeccionMaterials[materialIndex];
        }
        else
        {
            Debug.LogError("Índice de material seleccionado fuera de rango.");
        }
    }


    // Método para activar el VideoPlayer
    void PlayVideoOnLED(VideoPlayer videoPlayer, int buttonIndex)
    {
        // Reproducir el video correspondiente al botón de video seleccionado
        if (buttonIndex == 0)
        {
            videoPlayer.clip = Resources.Load<VideoClip>("Video1");
        }
        else if (buttonIndex == 1)
        {
            videoPlayer.clip = Resources.Load<VideoClip>("Video2");
        }
        videoPlayer.Play();
    }

    void Update()
    {
        // Incrementar t basado en la velocidad y el tiempo transcurrido
        t1 += speed * Time.deltaTime;
        t2 += speed * Time.deltaTime;

        // Asegurarse de que t esté en el rango [0, 1]
        t1 = Mathf.Clamp01(t1);
        t2 = Mathf.Clamp01(t2);

        // Interpolar la posición entre pointA y pointB
        MovingCamera1.transform.position = Vector3.Lerp(pointA.position, pointB.position, t1);
        MovingCamera2.transform.position = Vector3.Lerp(pointC.position, pointD.position, t2);

        // Si alcanzamos el punto B, invertir la dirección
        if (t1 >= 1.0f)
        {
            // Reiniciar t para empezar desde el punto A
            t1 = 0.0f;

            // Intercambiar los puntos A y B para invertir la dirección
            Transform temp1 = pointA;
            pointA = pointB;
            pointB = temp1;
        }
        if (t2 >= 1.0f)
        {
            // Reiniciar t para empezar desde el punto A
            t2 = 0.0f;

            // Intercambiar los puntos A y B para invertir la dirección
            Transform temp2 = pointC;
            pointC = pointD;
            pointD = temp2;
        }
    }
} 

