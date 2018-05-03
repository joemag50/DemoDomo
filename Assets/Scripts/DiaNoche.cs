using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaNoche : MonoBehaviour
{
    public float ciclo;

    Light luzSol;
    float tiempo;
    bool AmanAnoch; //Amanecer = true, Anochecer = false

	// Use this for initialization
	void Start ()
    {
        tiempo = ciclo;
        luzSol = GetComponent<Light>();
        AmanAnoch = false; 

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (AmanAnoch)
            tiempo += Time.deltaTime;
        else
            tiempo -= Time.deltaTime;

        if (tiempo <= 0 || tiempo >= ciclo)
            AmanAnoch = !AmanAnoch;

        luzSol.intensity = tiempo / ciclo;
    }
}
