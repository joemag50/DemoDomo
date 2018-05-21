using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLuces : MonoBehaviour
{
	public GameObject CPrincipal, CLuces;
    public GameObject[] Lamparas;
    public ConArduino arduino;
    public Luces Luz;

    private bool[] luz1 = { false, false };
    private bool[] luz2 = { false, false };
    private bool[] luz3 = { false, false };

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
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
