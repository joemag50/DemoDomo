using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerAspersores : MonoBehaviour
{
    public bool ACTIVADO;
    public GameObject CAspersores, CPrincipal;
    public GameObject[] Ventanas, TextVentana, Lamparas;
    public GameObject TextNivelHumedad, TextEstatusAspersor, TextEstatusAlarma;

    public ConArduino arduino;
    public Aspersores asp;

    public string port;


    public bool encenderAspersor;
    public bool activarAlarmaVentana;
    public bool activarAlarmaRobo;

    private bool ultimaAlarmaRobo;

    private const float intervalo = 0.2f;
    private float IntervaloAlarma;
    private int conteo = 0;
    private List<bool> lamparasActivasAntesDeAlarma;
    private string ultimoVar5;
    private string var0, var5;

    void Awake()
    {
        if (!ACTIVADO)
        {
            return;
        }
        Conectar();
    }

    // Use this for initialization
    void Start ()
    {
        asp = new Aspersores();
        encenderAspersor = false;
        activarAlarmaVentana = false;
        activarAlarmaRobo = false;
        IntervaloAlarma = intervalo;
        lamparasActivasAntesDeAlarma = new List<bool>();
        var5 = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!ACTIVADO)
        {
            return;
        }
        string textoDesdeArduino = arduino.ReadFromArduino(70);
        if (textoDesdeArduino != null)
        {
            //Debug.Log(textoDesdeArduino);
            asp.readLine(textoDesdeArduino);
            var0 = asp.vars[0];//humedad;
            string var1 = asp.vars[1];//temperatura;
            string var2 = asp.vars[2];//aspersor;
            string var3 = asp.vars[3];//hic;
            string var4 = asp.vars[4];//alertaVentana;
            ultimoVar5 = var5;
            var5 = asp.vars[5];//estadoVentana;
            string var6 = asp.vars[6];//activarAlarma;

            //Aspersor
            encenderAspersor = object.Equals(var2, "1");
            Debug.Log(activarAlarmaVentana);

            if (activarAlarmaVentana)
                var6 = "1";
            else
                var6 = "0";

            //La alarma esta desactivada, vamos a modificar la alarma de la ventana
            if (object.Equals(var6, "0"))
                var4 = "0";


            ultimaAlarmaRobo = activarAlarmaRobo;

            activarAlarmaRobo = object.Equals(var4, "1");

            //Hacemos esto para que cuando inicie la alarma guardamos las ultimas luces activas o inactivas
            //Para que cuando acabe la alarma, regresarlas a su estado normal
            if (!ultimaAlarmaRobo && activarAlarmaRobo)
            {
                int i = 0;
                lamparasActivasAntesDeAlarma = new List<bool>();
                foreach (GameObject go in Lamparas)
                {
                    lamparasActivasAntesDeAlarma.Add(go.active);
                    i++;
                }
            }

            if (!object.Equals(var5, ultimoVar5) && var5 != "" && !activarAlarmaRobo)
            {
                bool abrir = object.Equals(var5, "1");
                AbrirCerrarVentanas(abrir);
            }


            //Debug.Log(activarAlarmaRobo);
        }

        if (encenderAspersor && !GameObject.FindWithTag("AspersoresJardin").GetComponent<ActivarParticulas>().Activo)
        {
            GameObject.FindWithTag("AspersoresJardin").GetComponent<ActivarParticulas>().StopOrPlay();
        }
        
        if (!encenderAspersor && GameObject.FindWithTag("AspersoresJardin").GetComponent<ActivarParticulas>().Activo)
        {
            GameObject.FindWithTag("AspersoresJardin").GetComponent<ActivarParticulas>().StopOrPlay();
        }

        if (activarAlarmaRobo)
        {
            //SOBRES!! JUEGO DE LUCES
            IntervaloAlarma -= Time.deltaTime;
            //Debug.Log(IntervaloAlarma);
            if (IntervaloAlarma < 0)
            {
                int i = 0;
                foreach (GameObject go in Lamparas)
                {
                    if (conteo % 2 == 0)
                    {
                        if (i % 2 == 0)
                        {
                            go.SetActive(false);
                        }
                        else
                        {
                            go.SetActive(true);
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            go.SetActive(true);
                        }
                        else
                        {
                            go.SetActive(false);
                        }
                    }
                    i++;
                }
                conteo++;
                IntervaloAlarma = intervalo;
            }
        }
        else
        {
            conteo = 0;

            if (ultimaAlarmaRobo)
            {
                int i = 0;
                if (lamparasActivasAntesDeAlarma != null)
                {
                    foreach (GameObject go in Lamparas)
                    {

                        go.SetActive(lamparasActivasAntesDeAlarma[i]);
                        i++;
                    }
                }
            }
        }
        ActualizarTextos(var0, encenderAspersor + "", activarAlarmaVentana + "");
    }

    public void Conectar()
    {
        arduino = new ConArduino();
        arduino.port = port;
        arduino.Open();
    }

    public void Regresar()
    {
        CAspersores.SetActive(false);
        CPrincipal.SetActive(true);
    }

    public void AbrirCerrarVentanas(bool abrir)
    {
        List<bool> activos = new List<bool>();
        foreach (GameObject go in Ventanas)
        {
            go.GetComponentInChildren<AbrirCerrarPuerta>().abrircerrar(abrir);
            activos.Add(go.GetComponentInChildren<AbrirCerrarPuerta>().Abierta);
        }

        int i = 0;
        foreach (GameObject go in TextVentana)
        {
            string status;
            if (activos[i])
            {
                status = "Abierta";
            }
            else
            {
                status = "Cerrada";
            }
            go.GetComponent<TextMeshProUGUI>().text = status;
        }
    }

    public void ActivarDesactivarAlarma()
    {
        //Debug.Log("Me presionaste");
        this.activarAlarmaVentana = !this.activarAlarmaVentana;
    }

    public void ActualizarTextos(string h, string asp, string alarm)
    {
        TextNivelHumedad.GetComponent<TextMeshProUGUI>().text = h;
        TextEstatusAspersor.GetComponent<TextMeshProUGUI>().text = asp;
        TextEstatusAlarma.GetComponent<TextMeshProUGUI>().text = alarm;
    }
}
