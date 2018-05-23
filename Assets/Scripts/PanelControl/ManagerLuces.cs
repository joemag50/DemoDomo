using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLuces : MonoBehaviour
{
	public GameObject CPrincipal, CLuces;
    public GameObject[] Lamparas;
    public ConArduino arduino;
    public Luces Luz;

    public string port;
    public string lectura;

    // Use this for initialization
    void Awake ()
    {
        Conectar();
    }

    void Start()
    {
        Luz = new Luces();
    }

    // Update is called once per frame
    void Update()
    {
        //return;
        string textoDesdeArduino = arduino.ReadFromArduino(100);
        if (textoDesdeArduino != null)
        {
            Debug.Log(textoDesdeArduino);
            //Luz.readLine(textoDesdeArduino);
            //Luz.lucesChidas = Lamparas;
            //Luz.EncenderApagarCambio();

            //Nos Falta actualizar el panel de control
        }
    }
    public void Conectar()
    {
        arduino = new ConArduino();
        arduino.port = port;
        arduino.Open();
    }

    //public void 

    public void Regresar()
	{
		CPrincipal.SetActive(true);
		CLuces.SetActive(false);
	}
}
