using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO.Ports;

public class PruebaComunicacionSerial : MonoBehaviour
{
    SerialPort seri = new SerialPort("COM3", 9600);
    float ciclo = 10;
    float tiempo;
    bool idaRegreso;

    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start () {
        seri.Open();
        tiempo = ciclo;
        idaRegreso = false;

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (idaRegreso)
        {
            tiempo += Time.deltaTime;
            seri.WriteLine("0");
        }
        else
        {
            tiempo -= Time.deltaTime;
            seri.WriteLine("1");
        }

        if (tiempo <= 0 || tiempo >= ciclo)
        {
            idaRegreso = !idaRegreso;
            seri.BaseStream.Flush();
        }
        Debug.Log(tiempo);

	}
}
