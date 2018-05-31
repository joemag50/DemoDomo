using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarParticulas : MonoBehaviour
{
    public GameObject Particulas;
    public bool Activo;

    // Use this for initialization
    void Start()
    {
        Particulas.GetComponent<ParticleSystem>().Stop();
        Activo = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopOrPlay()
    {
        if (Activo)
        {
            Particulas.GetComponent<ParticleSystem>().Stop();
            Activo = false;
        }
        else
        {
            Particulas.GetComponent<ParticleSystem>().Play();
            Activo = true;
        }
    }
}
