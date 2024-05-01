using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class Gobo : MonoBehaviour
{

    private Light spotlight;
    private GameObject dmxProtocolObject;
    private DMXProtocol dmxProtocol;
    private static Texture2D[] gobos; // Array para almacenar las texturas de los gobos
    private int selectedGoboIndex = 0; // Índice del gobo seleccionado en el Dropdown
    public int goboChannel = 0;

    // Start is called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
        dmxProtocolObject = GameObject.Find("GameManager");
        importGobos(); // Importa las texturas de los gobos
        // Verifica si se encontro el objeto y el script
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
        if (dmxProtocol.getDMXChannel() == goboChannel)
        {
            if (dmxProtocol.getDMXValue() == 0) spotlight.cookie = null;
            if (dmxProtocol.getDMXValue() == 1) spotlight.cookie = gobos[1];
            if (dmxProtocol.getDMXValue() == 2) spotlight.cookie = gobos[2];
            if (dmxProtocol.getDMXValue() == 3) spotlight.cookie = gobos[3];
            if (dmxProtocol.getDMXValue() == 4) spotlight.cookie = gobos[4];
            if (dmxProtocol.getDMXValue() == 5) spotlight.cookie = gobos[5];
            if (dmxProtocol.getDMXValue() == 6) spotlight.cookie = gobos[6];
            if (dmxProtocol.getDMXValue() == 7) spotlight.cookie = gobos[7];
            //if (dmxProtocol.getDMXValue() == 8) spotlight.cookie = gobos[8];
        }
    }
    // Método estático para importar las texturas de los gobos
    static void importGobos()
    {
        gobos = new Texture2D[10]; // Inicializa el array de texturas de los gobos
        for (int i = 0; i < 10; i++)
        {
            gobos[i] = Resources.Load<Texture2D>("Gobos/Gobo" + i); // Carga las texturas de los gobos desde Resources
        }
    }
}

/*   private Light spotlight;
   public TMP_Dropdown goboDropdown; // Referencia al Dropdown que contiene las opciones de gobo

   private static Texture2D[] gobos; // Array para almacenar las texturas de los gobos
   private int selectedGoboIndex = 0; // Índice del gobo seleccionado en el Dropdown

   // Start is called before the first frame update
   void Start()
   {
       spotlight = GetComponent<Light>();
       importGobos(); // Importa las texturas de los gobos
       goboDropdown.onValueChanged.AddListener(OnGoboDropdownValueChanged); // Agrega un listener para detectar cambios en el Dropdown
   }

   // Método que se ejecuta cuando cambia la selección del Dropdown
   void OnGoboDropdownValueChanged(int newValue)
   {
       selectedGoboIndex = newValue; // Actualiza el índice del gobo seleccionado
       ApplySelectedGobo(); // Aplica el gobo seleccionado
   }

   // Método para aplicar el gobo seleccionado al spotlight
   void ApplySelectedGobo()
   {
       if (selectedGoboIndex >= 0 && selectedGoboIndex < gobos.Length)
       {
           spotlight.cookie = gobos[selectedGoboIndex]; // Asigna el gobo correspondiente al spotlight
       }
       else
       {
           Debug.LogError("¡Índice de gobo fuera de rango!");
       }
   }

   // Método estático para importar las texturas de los gobos
   static void importGobos()
   {
       gobos = new Texture2D[10]; // Inicializa el array de texturas de los gobos
       for (int i = 0; i < 10; i++)
       {
           gobos[i] = Resources.Load<Texture2D>("Gobos/Gobo" + i); // Carga las texturas de los gobos desde Resources
       }
   }
}
*/

