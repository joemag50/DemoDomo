using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lluvia : MonoBehaviour
{
    public GameObject lluvia;
    public bool LluviaActiva;

    // Use this for initialization
    void Start()
    {
        lluvia.GetComponent<ParticleSystem>().Stop();
        LluviaActiva = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopOrPlayLluvia()
    {
        if (LluviaActiva)
        {
            lluvia.GetComponent<ParticleSystem>().Stop();
            LluviaActiva = false;
        }
        else
        {
            lluvia.GetComponent<ParticleSystem>().Play();
            LluviaActiva = true;
        }
    }
}
