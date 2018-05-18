using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AireAcondicionado : MonoBehaviour
{
    public GameObject ac;
    public bool acActivo;

    // Use this for initialization
    void Start()
    {
        ac.GetComponent<ParticleSystem>().Stop();
        acActivo = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopOrPlayClima()
    {
        if (acActivo)
        {
            ac.GetComponent<ParticleSystem>().Stop();
            acActivo = false;
        }
        else
        {
            ac.GetComponent<ParticleSystem>().Play();
            acActivo = true;
        }
    }
}
