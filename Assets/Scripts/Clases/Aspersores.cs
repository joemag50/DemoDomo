﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspersores
{
    public float humedad;
    public float temperatura;
    public int aspersor;
    public int hic;
    public int alertaVentana;
    public int estadoVentana;
    public int activarAlarma;

    /* Atributos generales */
    public string linea;
    public int equipo;
    public int actualizacion;
    public string metodo;

    /* Atributos para el cambio*/
    public string[] vars;

    public Aspersores()
    {

    }

    public void readLine(string l)
    {
        //Obtenemos la linea
        this.linea = l;
        //Limpiamos la linea
        this.linea = this.linea.Replace("[", "").Replace("]", "");
        //Almacenamos toda la linea
        this.vars = this.linea.Split(';');

        //Guardamos las variables "fijas"
        equipo = int.Parse(this.vars[0].Split('=')[1]);
        //Si encontramos que somos nosotros mismos, pues no tenemos que leernos
        if (equipo != 0)
        {
            actualizacion = int.Parse(this.vars[1].Split('=')[1]);
            metodo = this.vars[2].Split('=')[1];

            if (object.Equals(metodo, "cambio"))
            {
                guardarVarsCambio();
            }
        }
    }

    public void printVars()
    {
        foreach (string s in vars)
        {
            Debug.Log(s);
        }
    }

    //Guarda las variables cuando es metodo cambio
    private void guardarVarsCambio()
    {
        string[] v = new string[11];
        int i = 0;
        foreach (string s in vars)
        {
            if (s.Substring(0, 3) == "var")
            {
                if (s.Split('=')[1] != "null")
                {
                    v[i] = s.Split('=')[1];
                    i++;
                }
            }
        }
        this.vars = v;
    }
}
