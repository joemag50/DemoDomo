using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerClimas : MonoBehaviour
{
    public GameObject CPrincipal,
                      CClimas,
                      TextTempActual,
                      TextEstatusClima,
                      TextEstatusAlarma,
                      TextTempMax,
                      TextTempMin;

    //Aqui tenemos lo necesario para conectarnos al arduino
    public ClimasAlarma ClimsAlrm;

    //Con esto nos vamos a conectar
    public ConArduino arduino;
    public string port;

    //ESTAS WEAS
    public string TempActual;
    public string EstatusClima;
    public string TempMax;
    public string TempMin;
    public string Alarma;

    void Awake()
    {
        //this.Conectar();
    }

    // Use this for initialization
    void Start() {
        ClimsAlrm = new ClimasAlarma();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(arduino.ReadFromArduino(100));
        return;
        string textoDesdeArduino = arduino.ReadFromArduino(100);
        if (textoDesdeArduino != null)
        {
            ClimsAlrm.readLine(textoDesdeArduino);
            Debug.Log(textoDesdeArduino);
            if (object.Equals(ClimsAlrm.metodo, "cambio"))
            {
                string var0 = ClimsAlrm.vars[0]; //Clima
                string var1 = ClimsAlrm.vars[1]; //Alarma
                string var2 = ClimsAlrm.vars[2]; //Actual
                string var3 = ClimsAlrm.vars[3]; //Min
                string var4 = ClimsAlrm.vars[4]; //Max

                //Vamos a poner una metirita piadosa, cuando llegue a cierta temp... vamos a encender el clima
                if (int.Parse(var2) >= 25)
                {
                    var1 = "true";
                }

                TextEstatusAlarma.GetComponent<TextMeshProUGUI>().text = var0;
                TextEstatusClima.GetComponent<TextMeshProUGUI>().text = var1;
                TextTempActual.GetComponent<TextMeshProUGUI>().text = var2;
                TextTempMin.GetComponent<TextMeshProUGUI>().text = var4;
                TextTempMax.GetComponent<TextMeshProUGUI>().text = var3;

                if (bool.Parse(var0))
                {
                    //Encendemos la regadera
                    GameObject.FindWithTag("AspersorIncendio").GetComponent<ActivarParticulas>().StopOrPlay();
                }

                if (bool.Parse(var1))
                {
                    //Encendemos el Clima
                    GameObject.FindWithTag("Clima").GetComponent<ActivarParticulas>().StopOrPlay();
                }
            }
        }
    }

    public void Regresar()
    {
        CPrincipal.SetActive(true);
        CClimas.SetActive(false);
    }

    public void Conectar()
    {
        arduino = new ConArduino();
        arduino.port = port;
        arduino.Open();
    }
}
