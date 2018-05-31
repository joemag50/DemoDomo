using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCerrarPuerta : MonoBehaviour
{
    public bool Abierta;
    JointMotor motorPuerta;
	float tiempoOriginal = 4;
	float tiempo = 4;
	bool ActivarTiempo = false;
	// Use this for initialization
	void Start ()
    {
        motorPuerta = GetComponent<HingeJoint>().motor;
        Abierta = true;
        abrircerrar();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void abrircerrar()
    {
        if (Abierta)
        {
            motorPuerta.targetVelocity = -100;
            Abierta = false;
        }
        else
        {
            motorPuerta.targetVelocity = 100;
            Abierta = true;
        }

        GetComponent<HingeJoint>().motor = motorPuerta;
    }

    public void abrircerrar(bool abrir)
    {
        if (abrir)
        {
            motorPuerta.targetVelocity = -100;
            Abierta = false;
        }
        else
        {
            motorPuerta.targetVelocity = 100;
            Abierta = true;
        }

        GetComponent<HingeJoint>().motor = motorPuerta;
    }
}
