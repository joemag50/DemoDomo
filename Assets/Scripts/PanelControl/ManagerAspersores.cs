using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAspersores : MonoBehaviour
{
    public GameObject CAspersores, CPrincipal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Regresar()
    {
        CAspersores.SetActive(false);
        CPrincipal.SetActive(true);
    }
}
