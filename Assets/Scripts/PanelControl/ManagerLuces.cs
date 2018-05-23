using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerLuces : MonoBehaviour
{
    public bool ACTIVADO;
	public GameObject CPrincipal, CLuces;
    public GameObject[] Lamparas;
    public ConArduino arduino;
    public Luces Luz;

    public string port;
    public string lectura;

    public GameObject botonOriginal;

    private bool CambioEnVariables;

    // Use this for initialization
    void Awake ()
    {
        if (!ACTIVADO)
        {
            return;
        }
        Conectar();
    }

    void Start()
    {
        Luz = new Luces();
        CambioEnVariables = false;
        AjustaBotones();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ACTIVADO)
        {
            return;
        }
        string textoDesdeArduino = arduino.ReadFromArduino(100);
        if (textoDesdeArduino != null)
        {
            //Debug.Log(textoDesdeArduino);
            Luz.readLine(textoDesdeArduino);
            AccionarLuces();
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

    public void AccionarLuces()
    {
        Lamparas[0].GetComponent<Light>().enabled = (DameBoleano(Luz.vars[0]));
        Lamparas[1].GetComponent<Light>().enabled = (DameBoleano(Luz.vars[1]));
        Lamparas[2].GetComponent<Light>().enabled = (DameBoleano(Luz.vars[2]));
        //var2 = Comedor
        //var1 = Cocina
        //var0 = Cochera
    }

    bool DameBoleano(string numero)
    {
        int n = int.Parse(numero);
        if (n == 1)
            return true;
        else
            return false;
    }

    public void AjustaBotones()
    {
        int xInicial = 220;
        int yInicial = 100;
        int x = xInicial;
        int y = yInicial;

        GameObject papafocos = GameObject.FindGameObjectWithTag("PapaFocos");
        if (papafocos == null)
        {
            return;
        }
        for (int i = 0; i < Lamparas.Length; i++)
        {
            x += 40;
            if (i % 5 == 0)
            {
                y -= 50;
                x = xInicial;
            }
            GameObject m = Instantiate(botonOriginal, new Vector3(x, y, 1), Quaternion.identity);
            m.transform.SetParent(papafocos.transform);
            m.transform.localScale = (new Vector3(2, 2, 2));
            m.name = "Button:"+Lamparas[i].name;
            string nombre = Lamparas[i].name;
            m.GetComponentInChildren<TextMeshProUGUI>().text = Lamparas[i].name;
            m.GetComponent<Button>().onClick.AddListener(delegate () { ApagarEncenderFoco(nombre); });
        }
    }

    public void ApagarEncenderFoco(string nombre_foco)
    {
        //(GameObject.Find(nombre_foco).active)
        GameObject luz = GameObject.Find(nombre_foco);
        luz.GetComponent<Light>().enabled = (!luz.GetComponent<Light>().enabled);
    }
}
