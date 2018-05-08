using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAccesos : MonoBehaviour
{
    public GameObject CAccesos, CPrincipal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Regresar()
    {
        CAccesos.SetActive(false);
        CPrincipal.SetActive(true);
    }
}
