using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerAspersores : MonoBehaviour
{
    public GameObject CAspersores, CPrincipal;
    public GameObject[] Ventanas, TextVentana;
    public GameObject TextNivelHumedad, TextEstatusAspersor;

    public ConArduino arduino;
    public Aspersores asp;

    public string port;

    void Awake()
    {
        Conectar();
    }

    // Use this for initialization
    void Start ()
    {
        asp = new Aspersores();
	}

    // Update is called once per frame
    void Update()
    {
        return;
        string textoDesdeArduino = arduino.ReadFromArduino(70);
        if (textoDesdeArduino != null)
        {
            Debug.Log(textoDesdeArduino);
            asp.readLine(textoDesdeArduino);
            string var0 = asp.vars[0]; //Humedad
            string var1 = asp.vars[1]; //Ventana
            string var2 = asp.vars[2]; //Alarma

            if (true) //Revisamos el nivel de humedad
            {
                GameObject.FindWithTag("AspersoresJardin").GetComponent<ActivarParticulas>().StopOrPlay();
            }

            //foreach (GameObject go in TextVentana)
            //{
            //    go.GetComponent<TextMeshProUGUI>().text = var1;
            //}
        }
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

    public void ActivarAlarmaLocaALV()
    {
        //Prendemos y apagamos las luces

    }
}
