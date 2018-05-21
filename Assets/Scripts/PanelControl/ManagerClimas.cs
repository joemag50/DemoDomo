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
                      TextTempMax,
                      TextTempMin;

    //Aqui tenemos lo necesario para conectarnos al arduino
    public ClimasAlarma ClimsAlrm;

    //Con esto nos vamos a conectar
    public ConArduino arduino;
    public string port;

    //Boleanos para andar leyendo el arduino pedorro jodido del demonio
    //Les voy a llamar señales

    public bool isGetTempActual;
    public bool isGetClima;
    public bool isGetTempMax;
    public bool isGetTempMin;
    public bool isGetAlarma;

    //ESTAS WEAS
    public string TempActual;
    public string EstatusClima;
    public string TempMax;
    public string TempMin;
    public string Alarma;

    // Use this for initialization
    void Start() {
        ClimsAlrm = new ClimasAlarma();
        isGetTempActual = false;
        isGetClima = false;
        isGetTempMax = false;
        isGetTempMin = false;
        isGetAlarma = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGetAlarma)
        {
            Alarma = arduino.ReadFromArduino(100);
            if (Alarma != null)
            {
                //Aqui encendemos la regadera para apagar el incendio
                ClimsAlrm.readLine(Alarma);
                isGetAlarma = false;
            }
        }
        if (isGetTempMin)
        {
            TempMin = arduino.ReadFromArduino(100);
            if (TempMin != null)
            {
                //Para el panel de control
                isGetTempMin = false;
                TextTempMin.GetComponent<TextMeshProUGUI>().text = TempMin;
            }
        }

        if (isGetTempMax)
        {
            TempMax = arduino.ReadFromArduino(100);
            if (TempMax != null)
            {
                //Para el panel de control
                isGetTempMax = false;
                TextTempMax.GetComponent<TextMeshProUGUI>().text = TempMax;
            }
        }

        if (isGetClima)
        {
            EstatusClima = arduino.ReadFromArduino(100);
            if (EstatusClima != null)
            {
                //Aqui vamos a encender y apagar las particulas del clima
                isGetClima = false;
                TextEstatusClima.GetComponent<TextMeshProUGUI>().text = EstatusClima;
            }
        }

        if (isGetTempActual)
        {
            TempActual = arduino.ReadFromArduino(100);
            if (TempActual != null)
            {
                //Aqui si llegamos a una temperatura muy alta, encendemos el incendio
                isGetTempActual = false;
                TextTempActual.GetComponent<TextMeshProUGUI>().text = TempActual;
            }
        }

        /* AQUI VAMOS A LEER LA LINEA DE CAMBIOS */
    }

    public void Regresar()
    {
        CPrincipal.SetActive(true);
        CClimas.SetActive(false);
    }

    public void Conectar()
    {
        arduino.port = "COM3";
        arduino.Open();
    }

    //Encendio Apagado
    public void GetClima()
    {
        arduino.WriteToArduino(ClimsAlrm.Get(0));
        isGetClima = true;
    }

    public void GetAlarma()
    {
        arduino.WriteToArduino(ClimsAlrm.Get(1));
        isGetAlarma = true;
    }

    public void GetTempActual()
    {
        arduino.WriteToArduino(ClimsAlrm.Get(2));
        isGetTempActual = true;
    }

    public void GetTempMax()
    {
        arduino.WriteToArduino(ClimsAlrm.Get(3));
        isGetTempMax = true;
    }

    public void GetTempMin()
    {
        arduino.WriteToArduino(ClimsAlrm.Get(4));
        isGetTempMin = true;
    }

    //Ajustar la temperatura Maxima
    public void SetTempMax()
    {

    }

    public void SetTempMin()
    {

    }
}
