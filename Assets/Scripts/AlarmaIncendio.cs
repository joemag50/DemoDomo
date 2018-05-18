using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmaIncendio : MonoBehaviour
{
    public GameObject aspersor;
    public bool AlarmaActiva;

    // Use this for initialization
    void Start()
    {
        aspersor.GetComponent<ParticleSystem>().Stop();
        AlarmaActiva = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopOrPlayRegadera()
    {
        if (AlarmaActiva)
        {
            aspersor.GetComponent<ParticleSystem>().Stop();
            AlarmaActiva = false;
        }
        else
        {
            aspersor.GetComponent<ParticleSystem>().Play();
            AlarmaActiva = true;
        }
    }
}
