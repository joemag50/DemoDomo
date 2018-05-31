using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimasAlarma
{
    /* Atributos generales */
    public string linea;
    public int equipo;
    public int actualizacion;
    public string metodo;

    /* Atributos para el cambio*/
    public string[] vars;

    /* Atributos para el get*/
    public string variable;
    public string valor;

    public ClimasAlarma()
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
            else if (object.Equals(metodo, "get"))
            {
                //Debug.Log(this.vars[4]);
                variable = this.vars[3].Split('=')[1];
                valor = this.vars[3].Split('=')[1];
            }
            else if (object.Equals(metodo, "set"))
            {
                //Debug.Log(this.vars[4]);
            }
        }
    }
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

    public string Get(int variable)
    {
        return string.Format("[equipo=0;actualizacion={0};metodo=get;variable={1}]", actualizacion, variable);
    }

    public string Set(int variable, string valor)
    {
        return string.Format("[equipo=0;actualizacion={0};metodo=set;variable={1},valor={2}]", actualizacion, variable, valor);
    }
}
