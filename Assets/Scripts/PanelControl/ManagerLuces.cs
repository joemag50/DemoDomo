using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLuces : MonoBehaviour
{
	public GameObject CPrincipal, CLuces;
    public GameObject[] Lamparas;
    public ConArduino arduino;
    public Luces Luz;

    public IEnumerator lectura;

    // Use this for initialization
    void Start ()
    {
        arduino = new ConArduino();
        Conectar();
    }
	
	// Update is called once per frame
	void Update ()
    {
		lectura = arduino.AsynchronousReadFromArduino(Luz.ReadLine);
	}

    public void Conectar()
    {
        arduino.port = "COM3";
        arduino.Open();
    }

    //public void 

    public void Regresar()
	{
		CPrincipal.SetActive(true);
		CLuces.SetActive(false);
	}
}
