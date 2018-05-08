using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerVentanas : MonoBehaviour
{
    public GameObject CVentanas, CPrincipal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Regresar()
    {
        CVentanas.SetActive(false);
        CPrincipal.SetActive(true);
    }
}
