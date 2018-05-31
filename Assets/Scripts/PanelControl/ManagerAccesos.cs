using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Data;
using Mono.Data.SqliteClient;
using TMPro;

public class ManagerAccesos : MonoBehaviour
{
    public GameObject prefabElementoLista, contenido;
    public GameObject CAccesos, CPrincipal;
	public GameObject puertabonita;
    public bool ACTIVADO;
    public ConArduino arduino;
    public Accesos acc;

    public string port;
    public string lectura;

    private string nombre;
    private string idtarjeta;
    private string ultimoacceso;

	private bool cerrarPuerta = false;
	private float tiempoOriginal = 3;
	private float tiempo;

    // Use this for initialization
    void Awake()
    {
        if (!ACTIVADO)
        {
            return;
        }
        Conectar();
    }

    void Start()
    {
        acc = new Accesos();
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
            acc.readLine(textoDesdeArduino);
            this.nombre = acc.vars[0];
            this.idtarjeta = acc.vars[1];
            this.ultimoacceso = acc.vars[2];
            //GuardarAcceso();

			puertabonita.GetComponent<AbrirCerrarPuerta> ().abrircerrar ();
			cerrarPuerta = true;
			tiempo = tiempoOriginal;
        }

		if (cerrarPuerta)
		{
			Debug.Log (tiempo);
			tiempo -= Time.deltaTime;
			if (tiempo < 0)
			{
				puertabonita.GetComponent<AbrirCerrarPuerta> ().abrircerrar ();
				cerrarPuerta = false;
			}
		}
    }

    public void GuardarAcceso()
    {
        BaseDatos.SqlCommand(string.Format("INSERT INTO accesos (nombre,idtarjeta,fechahora) VALUES ('{0}', '{1}', '{2}') ", this.nombre, this.idtarjeta, this.ultimoacceso));
    }

    public void RellenarLista(GameObject content)
    {
        IDataReader reader = BaseDatos.SqlCommand(string.Format(" SELECT * FROM accesos ORDER BY idaccesos "));

        while (reader.Read())
        {
            string idacceso = reader.GetInt32(0)+"";
            string nombre = reader.GetString(1);
            string idtarjeta = reader.GetString(2);
            string ultimoacc = reader.GetString(3);

            GameObject e = Instantiate(prefabElementoLista, content.transform);
            string texto = string.Format("{0}: {1} {2} {3} ", idacceso, nombre, idtarjeta, ultimoacc);
            e.GetComponentInChildren<TextMeshProUGUI>().text = texto;
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
        CAccesos.SetActive(false);
        CPrincipal.SetActive(true);
    }
}
